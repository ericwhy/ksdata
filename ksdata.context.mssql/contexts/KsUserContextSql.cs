using ksdata.context.configuration;
using ksdata.models;
using Microsoft.EntityFrameworkCore;

namespace ksdata.context {
    public class KsUserContextSql: DbContext {
        public KsUserContextSql() {  }
        public KsUserContextSql(DbContextOptions<KsUserContextSql> options)
        : base(options) { }
        public DbSet<KsUserEntity> Users {get;set;}
        public DbSet<KsLoginFailureEntity> LoginFailures {get;set;}
        public DbSet<KsUserRoleEntity> UserRoles {get;set;}
        public DbSet<KsUserTokenEntity> UserTokens {get;set;}
        public DbSet<PasswordHistoryEntity> PasswordHistories {get;set;}

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