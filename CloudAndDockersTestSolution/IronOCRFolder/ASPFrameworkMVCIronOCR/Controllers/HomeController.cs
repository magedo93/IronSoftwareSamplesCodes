using IronOcr;
using System;
using System.Web.Mvc;

namespace ASPFrameworkMVCIronOCR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var Ocr = new IronTesseract();
            var fileImage = Server.MapPath("~/testOCR.PNG");
            var filePdf = Server.MapPath("~/IronOCRText.pdf");
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
                ViewBag.Message = ex.Message;
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
                ViewBag.Message = ex.Message;
            }

            return View();
        }
 
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}