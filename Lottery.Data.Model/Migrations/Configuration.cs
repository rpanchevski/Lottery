using System.Data.Entity.Migrations;

namespace Lottery.Data.Model.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LotteryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LotteryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Codes.AddOrUpdate(x => x.Id, new Code {Winning = true, CodeValue = "CXC33C"},
                new Code {Winning = false, CodeValue = "CXC34X"}, new Code {Winning = false, CodeValue = "YY4SCX"},
                new Code {Winning = false, CodeValue = "ZZ22ZZ"}, new Code {Winning = false, CodeValue = "TT0012"},
                new Code {Winning = false, CodeValue = "Z1Z2Z3"}, new Code {Winning = true, CodeValue = "CT4321"});

            context.Awards.AddOrUpdate(x => x.Id,
                new Award
                {
                    AwardName = "Beer",
                    AwardDescription = "You won beer",
                    NumberOfAwards = 100,
                    RuffledType = (byte) RuffledType.Immediate
                }, new Award
                {
                    AwardName = "iPhoneX",
                    AwardDescription = "You won iPhoneX",
                    NumberOfAwards = 1,
                    RuffledType = (byte)RuffledType.PerDay
                },
                new Award
                {
                    AwardName = "VW Polo",
                    AwardDescription = "You won VW Polo",
                    NumberOfAwards = 1,
                    RuffledType = (byte)RuffledType.Final
                });

            context.SaveChanges();
        }
    }
}
