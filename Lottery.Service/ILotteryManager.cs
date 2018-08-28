﻿using System.Collections.Generic;
using Lottery.View.Model;

namespace Lottery.Service
{
    public interface ILotteryManager
    {
        AwardModel CheckCode(UserCodeModel userCode);
        List<UserCodeAwardModel> GetWinnerList();
    }
}
