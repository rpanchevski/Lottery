using Lottery.Data;
using Lottery.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Service
{
    public class LotteryManager : ILotteryManager
    {
        private readonly IRepository<Award> _awardRepository;
        private readonly IRepository<UserCodeAward> _userCodeAwardRepository;
        private readonly IRepository<UserCode> _userCodeRepository;

        public LotteryManager(IRepository<Award> awardRepository,
            IRepository<UserCodeAward> userCodeAwardRepository,
            IRepository<UserCode> userCodeRepository)
        {
            _awardRepository = awardRepository;
            _userCodeAwardRepository = userCodeAwardRepository;
            _userCodeRepository = userCodeRepository;
        }

        public void ProcessAwards(RaffledType type)
        {
            var numberOfAwards = GetAwardQuantityPerType(type);

            for (var i = 0; i < numberOfAwards; i++)
            {
                GiveAward(type);
            }
        }

        private int GetAwardQuantityPerType(RaffledType type)
        {
            var awardsQuantity =
                _awardRepository.GetAll().Where(x => x.RuffledType == (byte)type).Sum(x => x.Quantity);

            return awardsQuantity;
        }

        private void GiveAward(RaffledType type)
        {
            var users = _userCodeRepository.GetAll().Include(x => x.Code).Where(x => !x.Code.IsWinning);

            if (type == RaffledType.PerDay)
            {
                users = users.Where(x => x.SentAt.Date == DateTime.Now.Date);
            }

            var usersList = users.ToList();

            var userCodeAward = _userCodeAwardRepository.GetAll().ToList();

            usersList = usersList.Where(x => userCodeAward.All(y => y.UserCodeId != x.Id)).ToList();

            if (!usersList.Any()) return;

            var rnd = new Random();
            var randomUserIndex = rnd.Next(0, usersList.Count - 1);
            var winningUser = usersList[randomUserIndex];

            var randomAward = GetRandomAward(type);

            _userCodeAwardRepository.Insert(new UserCodeAward
            {
                UserCode = winningUser,
                Award = randomAward,
                WonAt = DateTime.Now
            });
        }

        private Award GetRandomAward(RaffledType type)
        {
            var awards = _awardRepository.GetAll().Where(x => x.RuffledType == (byte)type).ToList();
            var awardedAwards = _userCodeAwardRepository
                .GetAll()
                .Where(x => x.Award.RuffledType == (byte)type)
                .Select(x => x.Award)
                .GroupBy(x => x.Id)
                .ToList();

            var availableAwards = new List<Award>();

            foreach (var award in awards)
            {
                var numberOfAwardedAwards = awardedAwards
                    .FirstOrDefault(x => x.Key == award.Id)?.Count() ?? 0;
                var awardsLeft = award.Quantity - numberOfAwardedAwards;
                availableAwards.AddRange(Enumerable.Repeat(award, awardsLeft));
            }

            if (availableAwards.Count == 0)
                throw new ApplicationException("We are out of awards. Sorry!");

            var rnd = new Random();
            var randomAwardIndex = rnd.Next(0, availableAwards.Count);
            return availableAwards[randomAwardIndex];
        }
    }
}
