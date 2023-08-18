using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace WebsiteManagement.Application.Contracts.NewsCategoryAC
{
    public class CreateNewsCategory
	{
		//User Send Us
		[Required(ErrorMessage =ValidationMessages.IsRequired)]
		public string NewsHeader { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string NewsHeaderDescription { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string NewsMainDescryption { get;  set; }

        public string NewsHeaderPictureTitle { get;  set; }
		public string NewsHeaderPictureAlt { get;  set; }
		public string NewsHeaderPictureUrl { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string KeyWords { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get;  set; }
	}
}
