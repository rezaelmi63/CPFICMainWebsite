
using _0_Framework.Doamain;

namespace WebsiteManagement.Domain.SlideCategoryAgg
{
    public class SlideCategory : EntityBase
    {

        //public long Id { get;private set; }
        public string Name { get; private set; }
        public string PictureTitle { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureUrl { get; private set; }
        public bool HavePriceInfo { get; private set; }
        public string Heading { get; private set; }
        public string ShowLastPriceHead { get; private set; }
        public string ShowLastPrice { get; private set; }
        public string HeadingDescryption { get; private set; }
        public bool IsRemoved { get; private set; }
		//public DateTime CreationDate { get; private set; }

		public SlideCategory(string name, string pictureTitle, string pictureAlt, string pictureUrl,
            bool havePriceInfo, string heading, string showLastPriceHead, string showLastPrice, string headingDescryption)
        {
            Name = name;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            PictureUrl = pictureUrl;
            HavePriceInfo = havePriceInfo;
            Heading = heading;
            ShowLastPriceHead = showLastPriceHead;
            ShowLastPrice = showLastPrice;
            HeadingDescryption = headingDescryption;
            IsRemoved = false;
            //CreationDate = DateTime.Now;

		}


        public void Edit(string name, string pictureTitle, string pictureAlt, string pictureUrl,
            bool havePriceInfo, string heading, string showLastPriceHead, string showLastPrice, string headingDescryption)
        {
            Name = name;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;

            if(!string.IsNullOrWhiteSpace(pictureUrl))
                PictureUrl = pictureUrl;

            HavePriceInfo = havePriceInfo;
            Heading = heading;
            ShowLastPriceHead = showLastPriceHead;
            ShowLastPrice = showLastPrice;
            HeadingDescryption = headingDescryption;
        }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = false; 
        }

        public void IshavePrice()
        {
            HavePriceInfo = true;
        }

        public void RemovePrice()
        {
            HavePriceInfo = false;
        }
    }
}
