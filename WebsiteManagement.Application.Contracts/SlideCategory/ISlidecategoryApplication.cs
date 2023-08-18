using _0_Framework.Application;

namespace WebsiteManagement.Application.Contracts.SlideCategory
{
    public interface ISlidecategoryApplication
    {
        OperationResult Creat(CreateSlidecategory command);
        OperationResult Edit(EditSlidecategory command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);

        OperationResult IshavePrice(long id);
        OperationResult RemovePrice(long id);

        EditSlidecategory GetDetails(long id);
        List<SlidecategoryViewModel> Serach(SlideCategorySearchModel searchModel);

		List<SlidecategoryViewModel> GetList();
	}
}
