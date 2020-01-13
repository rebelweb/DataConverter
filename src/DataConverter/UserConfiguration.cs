using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataConverter
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.Property(prop => prop.Id)
                .HasColumnName("id");

            builder.Property(prop => prop.FirstName)
                .HasColumnName("first_name");

            builder.Property(prop => prop.LastName)
                .HasColumnName("last_name");

            builder.Property(prop => prop.Username)
                .HasColumnName("username");

            builder.Property(prop => prop.Password)
                .HasColumnName("password");

            builder.Property(prop => prop.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(prop => prop.UpdatedAt)
                .HasColumnName("updated_at");
        }
    }
}