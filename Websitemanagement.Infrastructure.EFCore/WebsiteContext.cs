using Microsoft.EntityFrameworkCore;
using Websitemanagement.Infrastructure.EFCore.Mapping;
using WebsiteManagement.Domain.NewsCategoryAgg;
using WebsiteManagement.Domain.SlideCategoryAgg;

namespace Websitemanagement.Infrastructure.EFCore
{
	public class WebsiteContext : DbContext
    {
        public WebsiteContext(DbContextOptions<WebsiteContext> options) : base(options) 
        { 
        
        }

		public DbSet<SlideCategory> SlideCategories { get; set; }
		public DbSet<NewsCategoryDomain> Newscategories { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly =  typeof(SlideCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
 