using Grpc.Core;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QRCoder;
using System.DrawingCore;
using System.DrawingCore.Imaging;
using System.IO;
using System.Web;


namespace Edigama.UI.Controllers
{
    public class HomeController:Controller
    {
        public string? CoockieName { get; set; }
        public const string cookieKey = "initialName";
        private const int pixelsPerModule = 200;

        [HttpGet]
        public IActionResult Index()
        {
            CoockieName = Request.Cookies[cookieKey];
            return View("/UI/Views/Home/Index.cshtml",this);
        }


        public IActionResult ConvertToQr([FromQuery(Name = "userText")] string text)
        {
            if(text.IsNullOrEmpty())
                return Content("/images/trouble.png");


            using(QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {                
                try
                {
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(text,QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    Bitmap qrCodeImage = qrCode.GetGraphic(pixelsPerModule);
                    string folderPath = "C:\\Users\\kosho\\source\\repos\\Edigama\\Edigama\\wwwroot\\images\\"; // root directory
                    string fileName = this.GetHashCode().ToString() + "_qr-code.jpeg";
                    string filePath = Path.Combine(folderPath,fileName);
                    qrCodeImage.Save(filePath,ImageFormat.Png);
                    string imageUrl = "/images/" + fileName;


                    return Content(imageUrl);
                }
                catch(Exception e)
                {
                    return Content("/images/trouble.png");
                }   
            }
        }
    }

}
