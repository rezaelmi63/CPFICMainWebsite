using _0_Framework.Doamain;
using WebsiteManagement.Application.Contracts.SlideCategory;

namespace WebsiteManagement.Domain.SlideCategoryAgg
{
    public interface ISlideCategoryRepository : IRepository<long, SlideCategory>
    {
        EditSlidecategory GetDetailes(long id);
		List<SlidecategoryViewModel> GetList();
		List<SlidecategoryViewModel> Search(SlideCategorySearchModel searchModel);
    }
} 
