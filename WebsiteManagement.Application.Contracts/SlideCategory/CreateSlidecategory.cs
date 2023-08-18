using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WebsiteManagement.Application.Contracts.SlideCategory
{
    public class CreateSlidecategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get; set; }

        //[Required(ErrorMessage = validationMessages.IsRequired)]
        
        [FileExtentionLimitation(new string[] { ".jpeg",".jpg",".png"},ErrorMessage =ValidationMessages.InvaliFileFormat)]
        [MaxFileSize(3 * 1024 * 1024,ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile PictureUrl { get;  set; }

        public bool HavePriceInfo { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Heading { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ShowLastPriceHead { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ShowLastPrice { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string HeadingDescryption { get;  set; }
    }
}
