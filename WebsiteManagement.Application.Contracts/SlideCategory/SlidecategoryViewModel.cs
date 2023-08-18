namespace WebsiteManagement.Application.Contracts.SlideCategory
{
    public class SlidecategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get;  set; }
        public string PictureTitle { get;  set; }
        public string PictureUrl { get;  set; }
        public bool HavePriceInfo { get;  set; }
        public string Heading { get;  set; }
        public string ShowLastPriceHead { get;  set; }
        public string ShowLastPrice { get;  set; }
        public string HeadingDescryption { get;  set; }
        public string CreationDate { get; set; }
        public bool IsRemoved { get; set; } 
    }
}
