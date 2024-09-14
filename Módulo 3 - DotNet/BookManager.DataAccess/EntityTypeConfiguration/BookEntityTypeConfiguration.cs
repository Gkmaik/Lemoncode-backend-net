using BookManager.DataAccess.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.DataAccess.EntityTypeConfigurations;

public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasMany(p => p.Authors)
            .WithMany(p => p.Books);
        builder.Property(p => p.Title)
            .HasMaxLength(100)
            .IsRequired(true);
        builder.Property(p => p.Description)
            .HasMaxLength(1000)
            .IsRequired(true);
    }
}