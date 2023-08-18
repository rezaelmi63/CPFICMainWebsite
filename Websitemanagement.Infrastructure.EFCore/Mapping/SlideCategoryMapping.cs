using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebsiteManagement.Domain.SlideCategoryAgg;

namespace Websitemanagement.Infrastructure.EFCore.Mapping
{
    public class SlideCategoryMapping : IEntityTypeConfiguration<SlideCategory>
    {
        public void Configure(EntityTypeBuilder<SlideCategory> builder)
        {
            builder.ToTable("SlideCategories");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.PictureTitle).HasMaxLength(500).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(500).IsRequired();
            builder.Property(x => x.PictureUrl).HasMaxLength(250);
            builder.Property(x => x.HavePriceInfo).IsRequired();
            builder.Property(x => x.Heading).HasMaxLength(500).IsRequired();
            builder.Property(x => x.ShowLastPriceHead).HasMaxLength(250).IsRequired();
            builder.Property(x => x.ShowLastPrice).HasMaxLength(500).IsRequired();
            builder.Property(x => x.HeadingDescryption).HasMaxLength(500).IsRequired();
        }
    }
}
