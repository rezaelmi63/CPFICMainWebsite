using _01_WebsitemanagementQuery.Contracts.Slide;
using Microsoft.EntityFrameworkCore;
using Websitemanagement.Infrastructure.EFCore;

namespace _01_WebsitemanagementQuery.Query
{
	public class SlideQuery : ISlideQuery
	{
		private readonly WebsiteContext _WContext;


		public SlideQuery(WebsiteContext websiteContext)
		{
			_WContext = websiteContext;
		}
		public List<SlideQueryModel> GetSlides()
		{
			return _WContext.SlideCategories
				.Where(x => x.IsRemoved == false)
				.Select(x => new SlideQueryModel
				{
					Name = x.Name,
					PictureTitle = x.PictureTitle,
					PictureAlt = x.PictureAlt,
					PictureUrl = x.PictureUrl,
					HavePriceInfo = x.HavePriceInfo,
					Heading = x.Heading,
					ShowLastPriceHead = x.ShowLastPriceHead,
					ShowLastPrice = x.ShowLastPrice,
					HeadingDescryption = x.HeadingDescryption
				}).AsNoTracking().ToList();
		}
	}
}
