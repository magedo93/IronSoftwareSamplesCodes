using Docker5IronOCRLinuxCentOS7.Models;
using IronOcr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;

namespace Docker5IronOCRLinuxCentOS7.Controllers
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
