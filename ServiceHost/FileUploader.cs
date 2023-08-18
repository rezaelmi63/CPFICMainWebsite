using _0_Framework.Application;
namespace ServiceHost
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _environment;

        public FileUploader(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public string Upload(IFormFile file,string path, string UniqFileName,int FormId)
        {
            if(file==null) return "";

            FileInfo fi = new FileInfo(file.FileName);

            //var path = _environment.WebRootPath + "//Pics//SlidePics" + file.FileName;  


            if(FormId == 1)
                path = $"{_environment.WebRootPath}//Pics//SlidePics//{UniqFileName}{fi.Extension}";

            if (FormId == 2)
                path = $"{_environment.WebRootPath}//Pics//ProfilePics//{UniqFileName}{fi.Extension}";

            using var output = System.IO.File.Create(path);
            file.CopyTo(output);
            
            return $"{UniqFileName}{fi.Extension}";
        }

    }
}
