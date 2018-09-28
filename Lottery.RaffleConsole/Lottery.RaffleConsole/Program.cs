using System;
using System.IO;
using System.Threading;
using Lottery.Data;
using Lottery.Data.Model;
using Lottery.Scheduler;
using Lottery.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Lottery.RaffleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = Configure();

            var cronScheduleTask = serviceProvider.GetService<IHostedService>();
            cronScheduleTask.StartAsync(new CancellationToken());

            while (true)
            {
            }
        }

        static ServiceProvider Configure()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton(provider => configuration)
                .AddSingleton<DbContext, LotteryContext>()
                .AddSingleton<ILotteryManager, LotteryManager>()
                .AddSingleton(typeof(IRepository<>), typeof(Repository<>))
                .AddSingleton<IHostedService, ScheduleTask>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
