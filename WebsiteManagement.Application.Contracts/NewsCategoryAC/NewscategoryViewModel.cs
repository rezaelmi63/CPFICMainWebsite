namespace WebsiteManagement.Application.Contracts.NewsCategoryAC
{
	public class NewscategoryViewModel
	{
		public long id { get; set; }
		public string NewsHeader { get; set; }
		public string NewsHeaderDescription { get; set; }
        public string NewsMainDescryption { get;  set; }
        public string NewsHeaderPictureUrl { get; set; }
		public string CreationDate { get; set; }
		public long NewsCount { get; set; }
	}
}
