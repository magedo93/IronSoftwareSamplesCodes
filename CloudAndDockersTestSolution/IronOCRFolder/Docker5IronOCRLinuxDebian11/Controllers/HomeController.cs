using Docker5IronOCRLinuxDebian11.Models;
using IronOcr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;

namespace Docker5IronOCRLinuxDebian11.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            var licenseKey = "IRONOCR.ROBERTNORMAN.2597-DA50396A17-CW2H2QGDBWWFN4D-EZHM4T2O7W7P-Z3EKJGSX654N-GQWXK6LSPR5W-OMTODAI35LZU-L6M2X3-TZILDGRYNT2EEA-DEPLOYMENT.TRIAL-OSWKWG.TRIAL.EXPIRES.26.FEB.2022";
            License.LicenseKey = licenseKey;
            var Ocr = new IronTesseract();
            var fileImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "testOCR.PNG");
            var filePdf = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "IronOCRText.pdf");
            try
            {
                using (OcrInput inputImage = new OcrInput(fileImage))
                {
                    var Results = Ocr.Read(inputImage);
                    ViewBag.ResultImageData = Results.Text;
                }
            }
            catch (Exception ex)
            {
                ViewBag.ResultImageData = ex.Message;
            }

            try
            {
                using (OcrInput inputPDF = new OcrInput(filePdf))
                {
                    var Results = Ocr.Read(inputPDF);
                    ViewBag.ResultPdfData = Results.Text;
                }
            }
            catch (Exception ex)
            {
                ViewBag.ResultPdfData = ex.Message;
            }

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
