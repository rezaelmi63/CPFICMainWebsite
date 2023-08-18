using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteManagement.Application.Contracts.NewsCategoryAC;
using WebsiteManagement.Domain.NewsCategoryAgg;

namespace WebSitemanagement.Application
{
    public class NewsCategoryApplication : INewsCategoriApplication
    {
        private readonly INewsCategoryRepository _newsCategoryRepository;

        public NewsCategoryApplication(INewsCategoryRepository newsCategoryRepository)
        {
            _newsCategoryRepository = newsCategoryRepository;
        }

        public OperationResult Create(CreateNewsCategory command)
        {
            var operation = new OperationResult();
            if (_newsCategoryRepository.Exist(x => x.NewsHeader == command.NewsHeader))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();

            var newscategory = new NewsCategoryDomain(command.NewsHeader, command.NewsHeaderDescription,
                command.NewsHeaderPictureTitle, command.NewsHeaderPictureAlt,
            command.NewsHeaderPictureUrl, command.KeyWords, command.MetaDescription, slug);

            _newsCategoryRepository.Create(newscategory);
            _newsCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditNewsCategory command)
        {
            var operation = new OperationResult();
            var newscategory = _newsCategoryRepository.Get(command.id);
            if (newscategory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_newsCategoryRepository.Exist(x => x.NewsHeader == command.NewsHeader && x.Id != command.id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();


            newscategory.Edit(command.NewsHeader, command.NewsHeaderDescription,
                command.NewsHeaderPictureTitle, command.NewsHeaderPictureAlt,
            command.NewsHeaderPictureUrl, command.KeyWords, command.MetaDescription, slug);
            _newsCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditNewsCategory GetDetails(long id)
        {
            return _newsCategoryRepository.GetDetails(id);
        }

        public List<NewscategoryViewModel> Search(NewsCategorySearchModel searchModel)
        {
            return _newsCategoryRepository.Search(searchModel);
        }
    }
}