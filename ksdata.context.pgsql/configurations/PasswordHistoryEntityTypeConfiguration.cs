using ksdata.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ksdata.context.configuration {
    public class PasswordHistoryEntityTypeConfiguration : IEntityTypeConfiguration<PasswordHistoryEntity> {
        public void Configure(EntityTypeBuilder<PasswordHistoryEntity> typeBuilder) {
            typeBuilder.HasKey(e => new { e.KsUserId, e.Password }).HasName("password_history_PK");

            typeBuilder.ToTable("password_history", "ks");

            typeBuilder.Property(e => e.KsUserId)
                .HasMaxLength(60)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ks_user_id");
            typeBuilder.Property(e => e.Password)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("password");
            typeBuilder.Property(e => e.CreateDt)
                //.HasColumnType("datetime")
                .HasColumnName("create_dt");
            typeBuilder.Property(e => e.PasswordSalt)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("password_salt");

            typeBuilder.HasOne(d => d.User).WithMany(p => p.PasswordHistories)
                .HasForeignKey(d => d.KsUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ks_user_password_history_FK1");
        }
    }
}
