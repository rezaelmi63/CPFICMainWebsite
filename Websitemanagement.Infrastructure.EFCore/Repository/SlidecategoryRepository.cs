using _0_Framework.Application;
using _0_Framework.Infrastructure;
using WebsiteManagement.Application.Contracts.SlideCategory;
using WebsiteManagement.Domain.SlideCategoryAgg;

namespace Websitemanagement.Infrastructure.EFCore.Repository
{
    public class SlidecategoryRepository : RepositoryBase<long,SlideCategory>, ISlideCategoryRepository
    {
        private readonly WebsiteContext _context;

        public SlidecategoryRepository(WebsiteContext context) : base(context) 
        {
            _context = context;
        }


        public EditSlidecategory GetDetailes(long id)
        {
            return _context.SlideCategories.Select(x => new EditSlidecategory()
            { 
                Id=x.Id,
                Name=x.Name,
                PictureTitle=x.PictureTitle,    
                PictureAlt=x.PictureAlt,
                HavePriceInfo = x.HavePriceInfo,
                Heading = x.Heading,
                ShowLastPriceHead=x.ShowLastPriceHead,
                ShowLastPrice=x.ShowLastPrice,
                HeadingDescryption=x.HeadingDescryption
        }).FirstOrDefault(x => x.Id == id);
        }

		public List<SlidecategoryViewModel> GetList()
		{
			return _context.SlideCategories.Select(x => new SlidecategoryViewModel
			{
				Id = x.Id,
				Name = x.Name,
				PictureTitle = x.PictureTitle,
				PictureUrl = x.PictureUrl,
				HavePriceInfo = x.HavePriceInfo,
				Heading = x.Heading,
				ShowLastPriceHead = x.ShowLastPriceHead,
				ShowLastPrice = x.ShowLastPrice,
				HeadingDescryption = x.HeadingDescryption,
				CreationDate = x.CreationDate.ToFarsi(),
				IsRemoved = x.IsRemoved
			}).OrderByDescending(x => x.Id).ToList();
		}

		public List<SlidecategoryViewModel> Search(SlideCategorySearchModel searchModel)
        {
            var query = _context.SlideCategories.Select(x => new SlidecategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                PictureTitle = x.PictureTitle,
                PictureUrl = x.PictureUrl,
                HavePriceInfo = x.HavePriceInfo,
                Heading = x.Heading,
                ShowLastPriceHead = x.ShowLastPriceHead,
                ShowLastPrice = x.ShowLastPrice,
                HeadingDescryption = x.HeadingDescryption,
                CreationDate = x.CreationDate.ToFarsi(),
                IsRemoved = x.IsRemoved
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            //if (!string.IsNullOrWhiteSpace(searchModel.Title))
            //    query = query.Where(x => x.Name.Contains(searchModel.Title));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
