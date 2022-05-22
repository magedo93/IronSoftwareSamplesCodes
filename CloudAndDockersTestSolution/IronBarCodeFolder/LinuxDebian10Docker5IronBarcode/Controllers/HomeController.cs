using IronBarCode;
using LinuxDebian10Docker5IronBarcode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LinuxDebian10Docker5IronBarcode.Controllers
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
