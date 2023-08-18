using _0_Framework.Doamain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebsiteManagement.Application.Contracts.NewsCategoryAC;

namespace WebsiteManagement.Domain.NewsCategoryAgg
{
	public interface INewsCategoryRepository : IRepository<long ,NewsCategoryDomain>
	{
		//void CreateNewsCategory(NewsCategoryDomain entity);
		//NewsCategoryDomain Get(long id);
		//List<NewsCategoryDomain> GetAll();
		//bool Exists(Expression<Func<NewsCategoryDomain,bool>> expression);
		//void SaveChanges();
		EditNewsCategory GetDetails(long id);
		List<NewscategoryViewModel> Search(NewsCategorySearchModel searchmodel);
	}
}
