using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebsiteManagement.Domain.NewsCategoryAgg;

namespace Websitemanagement.Infrastructure.EFCore.Mapping
{
	public class NewsCategoryMapping : IEntityTypeConfiguration<NewsCategoryDomain>
	{
		public void Configure(EntityTypeBuilder<NewsCategoryDomain> builder)
		{
			builder.ToTable("Newscategories");
			builder.HasKey(x=>x.Id);

			builder.Property(x => x.NewsHeader).HasMaxLength(255).IsRequired();
			builder.Property(x => x.NewsHeaderDescription).HasMaxLength(1000);
			builder.Property(x => x.NewsMainDescryption).HasMaxLength(6000);
            builder.Property(x => x.NewsHeaderPictureTitle).HasMaxLength(500);
			builder.Property(x => x.NewsHeaderPictureAlt).HasMaxLength(255);
			builder.Property(x => x.NewsHeaderPictureUrl).HasMaxLength(1000);
			builder.Property(x => x.KeyWords).HasMaxLength(80).IsRequired();
			builder.Property(x => x.MetaDescription).HasMaxLength(120).IsRequired();
			builder.Property(x => x.Slug).HasMaxLength(300);

	}
	}
}
