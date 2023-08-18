

using _0_Framework.Application;
using WebsiteManagement.Application.Contracts.SlideCategory;
using WebsiteManagement.Domain.SlideCategoryAgg;

namespace WebSitemanagement.Application
{
    public class SlidecategoryApplication : ISlidecategoryApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly ISlideCategoryRepository _slideCategoryrepository;

        public SlidecategoryApplication(ISlideCategoryRepository slideCategoryrepository, IFileUploader fileUploader)
        {
            _slideCategoryrepository = slideCategoryrepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Creat(CreateSlidecategory command)
        {
            var operation = new OperationResult();
            if (_slideCategoryrepository.Exist(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);


            var fileNameUniqe = CreateFileName().ToString();
            var picturePath = $"{command.Name}";


            var fileName = _fileUploader.Upload(command.PictureUrl, picturePath, fileNameUniqe, 1);


            var slidecategory = new SlideCategory(command.Name, command.PictureTitle, command.PictureAlt, fileName,
                command.HavePriceInfo, command.Heading, command.ShowLastPriceHead, command.ShowLastPrice, command.HeadingDescryption);

            _slideCategoryrepository.Create(slidecategory);
            _slideCategoryrepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditSlidecategory command)
        {
            var operation = new OperationResult();
            var slidecategory = _slideCategoryrepository.Get(command.Id);

            if (slidecategory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_slideCategoryrepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var fileNameUniqe = CreateFileName().ToString();
            var picturePath = $"{command.Name}";


            var fileName = _fileUploader.Upload(command.PictureUrl, picturePath, fileNameUniqe, 1);

            slidecategory.Edit(command.Name, command.PictureTitle, command.PictureAlt, fileName,
                command.HavePriceInfo, command.Heading, command.ShowLastPriceHead, command.ShowLastPrice, command.HeadingDescryption);

            _slideCategoryrepository.SaveChanges();
            return operation.Succedded();
        }


        public string CreateFileName()
        {

            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            GuidString = GuidString.Replace("/", "");
            GuidString = GuidString.Replace(@"\", "");
            return GuidString;
        }

        public EditSlidecategory GetDetails(long id)
        {
            return _slideCategoryrepository.GetDetailes(id);
        }

        public List<SlidecategoryViewModel> Serach(SlideCategorySearchModel searchModel)
        {
            return _slideCategoryrepository.Search(searchModel);
        }

        public List<SlidecategoryViewModel> GetList()
        {
            return _slideCategoryrepository.GetList();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var slide = _slideCategoryrepository.Get(id);
            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            slide.Remove();
            _slideCategoryrepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var slide = _slideCategoryrepository.Get(id);
            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            slide.Restore();
            _slideCategoryrepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult IshavePrice(long id)
        {
            var operation = new OperationResult();
            var slide = _slideCategoryrepository.Get(id);
            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            slide.IshavePrice();
            _slideCategoryrepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult RemovePrice(long id)
        {
            var operation = new OperationResult();
            var slide = _slideCategoryrepository.Get(id);
            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            slide.RemovePrice();
            _slideCategoryrepository.SaveChanges();
            return operation.Succedded();
        }
    }
}
