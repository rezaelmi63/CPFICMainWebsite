using _0_Framework.Doamain;

namespace WebsiteManagement.Domain.NewsCategoryAgg
{
	public  class NewsCategoryDomain : EntityBase
	{
		public NewsCategoryDomain(string newsHeader, string newsHeaderDescription, string newsHeaderPictureTitle, string newsHeaderPictureAlt,
			string newsHeaderPictureUrl, string keyWords, string metaDescription, string slug)
		{
			NewsHeader = newsHeader;
			NewsHeaderDescription = newsHeaderDescription;
			NewsHeaderPictureTitle = newsHeaderPictureTitle;
			NewsHeaderPictureAlt = newsHeaderPictureAlt;
			NewsHeaderPictureUrl = newsHeaderPictureUrl;
			KeyWords = keyWords;
			MetaDescription = metaDescription;
			Slug = slug;
			IsRemoved = false;
		}

		public void Edit(string newsHeader, string newsHeaderDescription, string newsHeaderPictureTitle, string newsHeaderPictureAlt,
			string newsHeaderPictureUrl, string keyWords, string metaDescription, string slug)
		{

			NewsHeader = newsHeader;
			NewsHeaderDescription = newsHeaderDescription;
			NewsHeaderPictureTitle = newsHeaderPictureTitle;
			NewsHeaderPictureAlt = newsHeaderPictureAlt;

			if (!string.IsNullOrWhiteSpace(newsHeaderPictureUrl))
				NewsHeaderPictureUrl = newsHeaderPictureUrl;

			KeyWords = keyWords;
			MetaDescription = metaDescription;
			Slug = slug;
			

		}

		public void Remove()
		{
			IsRemoved = true;
		}

		public string  NewsHeader { get;private set; }
		public string NewsHeaderDescription { get;private set; }
		public string NewsHeaderPictureTitle { get; private set; }
		public string NewsHeaderPictureAlt { get; private set; }
		public string NewsHeaderPictureUrl { get; private set; }
		public string KeyWords { get; private set; }
        public string MetaDescription  { get;private set; }
        public string Slug { get; private set; }
        public bool IsRemoved { get; private set; }



	}
}
