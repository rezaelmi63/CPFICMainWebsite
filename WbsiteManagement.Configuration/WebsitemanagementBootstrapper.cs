using _0_Framework.Application;
using _01_WebsitemanagementQuery.Contracts.Slide;
using _01_WebsitemanagementQuery.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Websitemanagement.Infrastructure.EFCore;
using Websitemanagement.Infrastructure.EFCore.Repository;
using WebsiteManagement.Application.Contracts.NewsCategoryAC;
using WebsiteManagement.Application.Contracts.SlideCategory;
using WebsiteManagement.Domain.NewsCategoryAgg;
using WebsiteManagement.Domain.SlideCategoryAgg;
using WebSitemanagement.Application;

namespace WbsiteManagement.Configuration
{
    public class WebsitemanagementBootstrapper
    {
        public static void Configure(IServiceCollection services,string connectionString)
        {
            services.AddTransient<ISlidecategoryApplication, SlidecategoryApplication>();
            services.AddTransient<ISlideCategoryRepository, SlidecategoryRepository>();

            services.AddTransient<INewsCategoriApplication, NewsCategoryApplication>();
            services.AddTransient<INewsCategoryRepository, NewsCategoryRepository>();

            services.AddTransient<ISlideQuery, SlideQuery>();

            services.AddDbContext<WebsiteContext>(x => x.UseSqlServer(connectionString));
        }
    }
}