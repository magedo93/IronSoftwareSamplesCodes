using IronPdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WindowsDocker5IronPdf.Models;

namespace WindowsDocker5IronPdf.Controllers
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
            //Installation.Initialize();
            //Installation.ChromeGpuMode = IronPdf.Engines.Chrome.ChromeGpuModes.Disabled;
            var rend = new ChromePdfRenderer();
            var doc = rend.RenderHtmlAsPdf(@"<h1> This is IronPdf Test Core 3.1 </h1> <h1>こんにちは世界</h1> <h1>مرحبا</h1>");

            Response.Headers.Add("Content-Disposition", "inline; filename=test.pdf");
            return File(doc.BinaryData, "application/pdf");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
