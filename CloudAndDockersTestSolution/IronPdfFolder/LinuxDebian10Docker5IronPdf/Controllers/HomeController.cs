using IronPdf;
using LinuxDebian10Docker5IronPdf.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace LinuxDebian10Docker5IronPdf.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IWebHostEnvironment Environment;
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment _environment)
        {
            _logger = logger;
            Environment = _environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            Installation.Initialize();
            Installation.ChromeGpuMode = IronPdf.Engines.Chrome.ChromeGpuModes.Disabled;
            var Renderer = new ChromePdfRenderer();
            //var doc = rend.RenderHtmlAsPdf(@"<h1> This is IronPdf Test Core 3.1 </h1>");

            Renderer.LoginCredentials = new ChromeHttpLoginCredentials();

            Renderer.RenderingOptions = new ChromePdfRenderOptions()
            {

                PaperSize = IronPdf.Rendering.PdfPaperSize.A4,
                PaperOrientation = IronPdf.Rendering.PdfPaperOrientation.Portrait,
                CssMediaType = IronPdf.Rendering.PdfCssMediaType.Print

            };
            var filePath = Path.Combine(this.Environment.WebRootPath, "invoice.html");
            var PDF = Renderer.RenderHTMLFileAsPdf(filePath);
            var footer = new HtmlHeaderFooter();
            footer.HtmlFragment = "<div><span style='float:left; padding:10px; margin-left:40px; color: #4632d8; font-family: 'Open Sans', sans-serif; font-size:12px; font-style: italic;'>help@ladun.com.sa</span><span style='float:right; padding:10px; margin-right:40px; color: #4632d8; font-family:Helvetica; font-size:12px; font-style: italic;'>https://ladun.com.sa</span></div>";

            var allPageIndexes = Enumerable.Range(0, PDF.PageCount);

            PDF.AddHtmlFooters(footer, 1, allPageIndexes);

            Response.Headers.Add("Content-Disposition", "inline; filename=test.pdf");
            return File(PDF.BinaryData, "application/pdf");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
