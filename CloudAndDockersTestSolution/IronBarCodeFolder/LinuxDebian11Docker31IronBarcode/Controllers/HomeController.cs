using IronBarCode;
using LinuxDebian11Docker31IronBarcode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace LinuxDebian11Docker31IronBarcode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var label = new Label(Enums.Alignment.CENTER);

            //// label.AddText("Nr.     " + index.ToString("000000"), "Verdana", 12, embedFont: true); // YEAH this works fine

            //var qrcode = QRCodeWriter.CreateQrCode(index.ToString(), 100);
            //qrcode.Image
            //var image = qrcode.GetInstance();
            //image.ScaleToFitHeight = false;
            //label.AddImage(image);

            //labelCreator.AddLabel(label);
            return View();
        }

        public IActionResult Privacy()
        {
            var MyBarCode = BarcodeWriter.CreateBarcode("IronBarcode Test", BarcodeEncoding.QRCode);
           
            Response.Headers.Add("Content-Disposition", "inline; filename=test.pdf");
            return File(MyBarCode.ToJpegBinaryData(), "image/jpeg");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
