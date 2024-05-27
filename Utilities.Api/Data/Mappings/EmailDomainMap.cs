using Api.Utilities.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Utilities.Data.Mappings
{
    public class EmailDomainMap : IEntityTypeConfiguration<EmailProvider>
    {
        public void Configure(EntityTypeBuilder<EmailProvider> builder)
        {
            builder.ToTable("EmailDomains");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.Name)
                    .IsUnique();

            builder.Property(a => a.Name)
                    .IsRequired();
        }
    }

}