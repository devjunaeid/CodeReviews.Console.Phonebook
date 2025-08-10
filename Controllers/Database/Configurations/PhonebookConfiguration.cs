using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Database.Configurations
{
    public class PhonebookConfiguration : IEntityTypeConfiguration<Phonebook>
    {

        public void Configure(EntityTypeBuilder<Phonebook> builder)
        {

            builder.ToTable("phonebooks");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(e => e.Name).IsRequired();

            builder.Property(e => e.Email).IsRequired(false).HasMaxLength(250);

            builder.Property(e => e.Address).IsRequired(false).HasMaxLength(500);

            builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(15);

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
        }
    }
}
