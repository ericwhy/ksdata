using ksdata.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ksdata.context.configuration {
    public class KsUserEntityTypeConfiguration : IEntityTypeConfiguration<KsUserEntity> {
        public void Configure(EntityTypeBuilder<KsUserEntity> typeBuilder) {
            typeBuilder.HasKey(e => e.KsUserId).HasName("ks_user_PK");

            typeBuilder.ToTable("ks_user", "ks");

            typeBuilder.HasIndex(e => e.EmailAddress, "UQ_ks_user__email_address").IsUnique();

            typeBuilder.Property(e => e.KsUserId)
                .HasMaxLength(60)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ks_user_id");
            typeBuilder.Property(e => e.AllowAccessFlg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("allow_access_flg");
            typeBuilder.Property(e => e.AuthPrompt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('Y')")
                .IsFixedLength()
                .HasColumnName("auth_prompt");
            typeBuilder.Property(e => e.DisplayName)
                .HasMaxLength(750)
                .IsUnicode(false)
                .HasColumnName("display_name");
            typeBuilder.Property(e => e.EmailAddress)
                .HasMaxLength(750)
                .IsUnicode(false)
                .HasColumnName("email_address");
            typeBuilder.Property(e => e.FailedLoginCnt).HasColumnName("failed_login_cnt");
            typeBuilder.Property(e => e.FailedLoginDt)
                //.HasColumnType("timestamp")
                .HasColumnName("failed_login_dt");
            typeBuilder.Property(e => e.IntegratedAuth)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .IsFixedLength()
                .HasColumnName("integrated_auth");
            typeBuilder.Property(e => e.Password)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("password");
            typeBuilder.Property(e => e.PasswordDt)
                .HasDefaultValueSql("(now())")
                //.HasColumnType("timestamp")
                .HasColumnName("password_dt");
            typeBuilder.Property(e => e.PasswordHints)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("password_hints");
            typeBuilder.Property(e => e.PasswordSalt)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("password_salt");
            typeBuilder.Property(e => e.PwresetFlg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .IsFixedLength()
                .HasColumnName("pwreset_flg");
        }
    }
}