using Microsoft.EntityFrameworkCore;
using ksdata.models;
using ksdata.context.configuration;

namespace ksdata.context
{
    public class KsUserContextPg : DbContext
    {
        private string connectionString = "@Host=localhost;Username=kore;Password=kraken;Database=kraken_dev";
        public KsUserContextPg() {}
        public KsUserContextPg(string connectionString) { }
        public KsUserContextPg(DbContextOptions<KsUserContextPg> options)
        : base(options) { }
        public DbSet<KsUserEntity> Users { get; set; }
        public DbSet<KsLoginFailureEntity> LoginFailures { get; set; }
        public DbSet<KsUserRoleEntity> UserRoles { get; set; }
        public DbSet<KsUserTokenEntity> UserTokens { get; set; }
        public DbSet<PasswordHistoryEntity> PasswordHistories { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options) {
        //    options.UseNpgsql("@Host=localhost;Username=kore;Password=kraken;Database=kraken_dev");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new KsUserEntityTypeConfiguration()
                .Configure(modelBuilder.Entity<KsUserEntity>());
            new KsLoginFailureEntityTypeConfiguration()
                .Configure(modelBuilder.Entity<KsLoginFailureEntity>());
            new KsUserRoleEntityTypeConfiguration()
                .Configure(modelBuilder.Entity<KsUserRoleEntity>());
            new KsUserTokenEntityTypeConfiguration()
                .Configure(modelBuilder.Entity<KsUserTokenEntity>());
            new PasswordHistoryEntityTypeConfiguration()
                .Configure(modelBuilder.Entity<PasswordHistoryEntity>());
        }
    }
}