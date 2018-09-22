using System;
using System.IO;
using Lottery.Data;
using Lottery.Data.Model;
using Lottery.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lottery.RaffleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = Configure();

            var lotteryManager = serviceProvider.GetService<ILotteryManager>();
            var configuration = serviceProvider.GetService<IConfigurationRoot>();

            var finalDate = DateTime.Parse(configuration.GetSection("FinalRaffle").Value);

            lotteryManager.ProcessAwards(RaffledType.PerDay);

            if (DateTime.Now.Date == finalDate.Date)
            {
                lotteryManager.ProcessAwards(RaffledType.Final);
            }
            
            Console.WriteLine("Hello World!");
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
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
