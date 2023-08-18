using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteManagement.Application.Contracts.SlideCategory;

namespace ServiceHost.Areas.Administration.Pages.WebSite.Slidecategories
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string message { get; set; } 


        public SlideCategorySearchModel SearchModel;
        public List<SlidecategoryViewModel> slideCategories;

        private readonly ISlidecategoryApplication _SlidecategoryApplication;

        public IndexModel(ISlidecategoryApplication application)
        {
            _SlidecategoryApplication = application;
        }

        //SlideCategorySearchModel SearchModel
        public void OnGet(SlideCategorySearchModel SearchModel)
        {
            slideCategories = _SlidecategoryApplication.Serach(SearchModel);
        }


        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateSlidecategory());
        }

        public JsonResult OnPostCreate(CreateSlidecategory command)
        {
            if (!command.HavePriceInfo)
            {
                command.ShowLastPriceHead = "";
                command.ShowLastPrice = "";
            }
            else
            {
                command.Heading = "";
                command.HeadingDescryption = "";
            }

            var resault = _SlidecategoryApplication.Creat(command);
            return new JsonResult(resault);
        }

        public IActionResult OnGetEdit(long id)
        {
            var slidecategory = _SlidecategoryApplication.GetDetails(id);

            return Partial("./Edit", slidecategory);
        }

        public JsonResult OnPostEdit(EditSlidecategory command)
        {
            if (!command.HavePriceInfo)
            {
                command.ShowLastPriceHead = "";
                command.ShowLastPrice = "";
            }
            else
            {
                command.Heading = "";
                command.HeadingDescryption = "";
            }

            if(ModelState.IsValid)
            {

            }

            var resualt = _SlidecategoryApplication.Edit(command);
            return new JsonResult(resualt);
        }

        public IActionResult OnGetRemove(long id)
        {
            var resualt =  _SlidecategoryApplication.Remove(id);
            if (resualt.IsSuccessed)
                return RedirectToPage("./Index");
            else
                message=resualt.Message;

            return RedirectToPage("./Index");

        }

        public IActionResult OnGetRestore(long id)
        {
            var resualt = _SlidecategoryApplication.Restore(id);
            if (resualt.IsSuccessed)
                return RedirectToPage("./Index");
            else
                message = resualt.Message;

            return RedirectToPage("./Index");
        }
    }
}
