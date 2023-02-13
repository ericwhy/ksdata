using ksdata.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ksdata.context.configuration {
    public class KsLoginFailureEntityTypeConfiguration : IEntityTypeConfiguration<KsLoginFailureEntity> {
        public void Configure(EntityTypeBuilder<KsLoginFailureEntity> typeBuilder) {
            typeBuilder.HasKey(e => new { e.KsUserId, e.FailDt }).HasName("ks_user_login_failure_PK");

            typeBuilder.ToTable("ks_user_login_failure", "ks");

            typeBuilder.Property(e => e.KsUserId)
                .HasMaxLength(60)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ks_user_id");
            typeBuilder.Property(e => e.FailDt)
                .HasColumnType("datetime")
                .HasColumnName("fail_dt");

            typeBuilder.HasOne(d => d.User).WithMany(p => p.LoginFailures)
                .HasForeignKey(d => d.KsUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ks_user_ks_user_login_failure_FK1");
        }
    }
}