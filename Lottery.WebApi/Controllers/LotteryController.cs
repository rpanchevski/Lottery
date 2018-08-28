﻿using System.Collections.Generic;
using System.Web.Http;
using Lottery.Service;
using Lottery.View.Model;

namespace Lottery.WebApi.Controllers
{
    public class LotteryController : ApiController
    {
        private readonly ILotteryManager _lotteryManager;

        public LotteryController(ILotteryManager lotteryManager)
        {
            _lotteryManager = lotteryManager;
        }

        [HttpPost]
        public AwardModel SubmitCode([FromBody] UserCodeModel userCodeModel)
        {
            return _lotteryManager.CheckCode(userCodeModel);
        }

        [HttpGet]
        public List<UserCodeAwardModel> GetAllWinners()
        {
            return _lotteryManager.GetWinnerList();
        }
    }
}
