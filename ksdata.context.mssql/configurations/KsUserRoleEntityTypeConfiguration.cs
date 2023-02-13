using ksdata.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ksdata.context.configuration {
    public class KsUserRoleEntityTypeConfiguration : IEntityTypeConfiguration<KsUserRoleEntity> {
        public void Configure(EntityTypeBuilder<KsUserRoleEntity> typeBuilder) {
            typeBuilder.HasKey(e => new { e.KsUserId, e.ResourceType, e.ResourceName, e.RoleNo }).HasName("pk_ks_user_role");

            typeBuilder.ToTable("ks_user_role", "ks");

            typeBuilder.Property(e => e.KsUserId)
                .HasMaxLength(60)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ks_user_id");
            typeBuilder.Property(e => e.ResourceType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("resource_type");
            typeBuilder.Property(e => e.ResourceName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("resource_name");
            typeBuilder.Property(e => e.RoleNo).HasColumnName("role_no");

            typeBuilder.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.KsUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ks_user_role_ks_user");
        }
    }
}