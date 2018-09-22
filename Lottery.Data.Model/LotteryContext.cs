using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Lottery.Data.Model
{
    public class LotteryContext : DbContext
    {
        public LotteryContext() : base("Data Source=192.168.0.22;Initial Catalog=LotteryDb;User ID=sa;Password=P@ssw0rd")
        {
        }

        public virtual DbSet<Code> Codes { get; set; }
        public virtual DbSet<UserCode> UserCodes { get; set; }
        public virtual DbSet<Award> Awards { get; set; }
        public virtual DbSet<UserCodeAward> UserCodeAwards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
