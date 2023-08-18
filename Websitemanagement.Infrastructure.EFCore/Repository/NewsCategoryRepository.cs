using _0_Framework.Infrastructure;
using WebsiteManagement.Application.Contracts.NewsCategoryAC;
using WebsiteManagement.Domain.NewsCategoryAgg;

namespace Websitemanagement.Infrastructure.EFCore.Repository
{
	public class NewsCategoryRepository : RepositoryBase<long,NewsCategoryDomain>, INewsCategoryRepository
	{
		private readonly WebsiteContext _siteContext;

		public NewsCategoryRepository(WebsiteContext siteContext) :base(siteContext) 
		{
			_siteContext = siteContext;
		}


		public EditNewsCategory GetDetails(long id)
		{
			return _siteContext.Newscategories.Select(x => new EditNewsCategory()
			{
				id=x.Id,
				NewsHeader = x.NewsHeader, 
				NewsHeaderDescription = x.NewsHeaderDescription,
                NewsMainDescryption= x.NewsMainDescryption,
                NewsHeaderPictureTitle = x.NewsHeaderPictureTitle,
				NewsHeaderPictureAlt = x.NewsHeaderPictureAlt,
				NewsHeaderPictureUrl = x.NewsHeaderPictureUrl,
				KeyWords = x.KeyWords,
				MetaDescription = x.MetaDescription,
				Slug = x.Slug
			}).FirstOrDefault(x => x.id == id);
		}



		public List<NewscategoryViewModel> Search(NewsCategorySearchModel searchmodel)
		{
			var query = _siteContext.Newscategories.Select(x => new NewscategoryViewModel
			{
				id = x.Id,
				NewsHeader = x.NewsHeader,
				NewsHeaderDescription = x.NewsHeaderDescription,
                NewsMainDescryption = x.NewsMainDescryption,
                NewsHeaderPictureUrl = x.NewsHeaderPictureUrl,
				CreationDate = x.CreationDate.ToString()
			});

			if (!string.IsNullOrWhiteSpace(searchmodel.NewsHeader))
				query = query.Where(x => x.NewsHeader.Contains(searchmodel.NewsHeader));

			return query.OrderByDescending(x => x.id).ToList();	
		}
	}
}
