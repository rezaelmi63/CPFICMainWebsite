

using _0_Framework.Application;


namespace WebsiteManagement.Application.Contracts.NewsCategoryAC
{
	public interface INewsCategoriApplication
	{
		OperationResult Create(CreateNewsCategory command);
		OperationResult Edit(EditNewsCategory command);
		EditNewsCategory GetDetails(long id);
		List<NewscategoryViewModel> Search(NewsCategorySearchModel searchModel);
	}
}
