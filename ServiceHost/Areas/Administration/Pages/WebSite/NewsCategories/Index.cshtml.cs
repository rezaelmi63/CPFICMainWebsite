using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteManagement.Application.Contracts.NewsCategoryAC;

namespace ServiceHost.Areas.Administration.Pages.WebSite.NewsCategories
{
    public class IndexModel : PageModel
    {
        public NewsCategorySearchModel SearchModel;
        public List<NewscategoryViewModel> NewsCategories;
        private readonly INewsCategoriApplication _newsCategoriApplication;

        public IndexModel(INewsCategoriApplication newsCategoriApplication)
        {
            this._newsCategoriApplication = newsCategoriApplication;
        }

        public void OnGet(NewsCategorySearchModel searchModel)
        {
            NewsCategories = _newsCategoriApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateNewsCategory());
        }

        public JsonResult OnPostCreate(CreateNewsCategory command)
        {
            var result = _newsCategoriApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var newsCategory = _newsCategoriApplication.GetDetails(id);
            return Partial("./Edit", newsCategory);
        }

        public JsonResult OnPostEdit(EditNewsCategory command)
        {
            var result = _newsCategoriApplication.Edit(command);    
            return new JsonResult(result);  
        }
    }
}
