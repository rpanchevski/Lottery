﻿using System;
using System.Threading.Tasks;
using Lottery.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Lottery.Scheduler
{
    public class ScheduleTask : ScheduledProcessor
    {
        private readonly ILotteryManager _lotteryManager;

        public ScheduleTask(IServiceScopeFactory serviceScopeFactory, ILotteryManager lotteryManager) : base(
            serviceScopeFactory)
        {
            _lotteryManager = lotteryManager;
        }

        public override Task ProcessInScope(IServiceProvider serviceProvider)
        {
            try
            {
                Console.WriteLine($"Codes processing starts at: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
                _lotteryManager.ProcessCodes();
                Console.WriteLine($"Codes processing finished at: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Task.CompletedTask;
        }

        protected override string Schedule => "* * * * *";
    }
}
