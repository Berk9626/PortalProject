namespace Portal.WEBUI.Models.EducationWithImage
{
    public class EducationWithImage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EducationWithImage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string GetFilePath(string EducationName)
        {
            return _webHostEnvironment.WebRootPath + "\\educationImages\\" + EducationName;
        }

        public string GetImagebyEducation(string educationname)
        {
            string ImageUrl = string.Empty;
            string HostUrl = "http://localhost:5004/"; 
            string Filepath = GetFilePath(educationname);
            //string Imagepath = Filepath + "\\image.png";
            //if (!System.IO.File.Exists(Filepath))
            //{
            //    ImageUrl = HostUrl + "/uploads/common/noimage.png";
            //}
            ImageUrl = HostUrl + "/educationImages/" + educationname /*+ "/image.png"*/;
            return ImageUrl;
        }
    }
}
