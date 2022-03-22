using Bookshare.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookshare.DomainServices.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasKey(_ => _.Id);

            builder
                .Property(_ => _.Name)
                .IsRequired();

            builder
                .Property(_ => _.PhotoPath)
                .IsRequired(false);

            builder
                .HasMany(_ => _.Authors)
                .WithMany(_ => _.Books);

            builder
                .HasOne(_ => _.Library)
                .WithMany(_ => _.Books);

            builder
                .Property(_ => _.DateModified)
                .IsRequired(false);

            builder
                .Property(_ => _.DateCreated)
                .IsRequired();
        }
    }
}