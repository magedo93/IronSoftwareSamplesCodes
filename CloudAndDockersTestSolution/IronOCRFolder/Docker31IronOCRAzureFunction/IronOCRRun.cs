using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using IronOcr;

namespace Docker31IronOCRAzureFunction
{
    public static class IronOCRRun
    {
        [FunctionName("IronOCRRun")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log,ExecutionContext context)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string responseMessage = "";
            var Ocr = new IronTesseract();
            var fileImage = Path.Combine(context.FunctionAppDirectory,  "testOCR.PNG");
            var filePdf = Path.Combine(context.FunctionAppDirectory, "IronOCRText.pdf");
            try
            {
                using (OcrInput inputImage = new OcrInput(fileImage))
                {
                    var Results = Ocr.Read(inputImage);
                    responseMessage += $"Image Text=> {Results.Text}"; 
                }
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message);
            }

            try
            {
                using (OcrInput inputPDF = new OcrInput(filePdf))
                {
                    var Results = Ocr.Read(inputPDF);
                    responseMessage += $"PDF Text=> {Results.Text}";
                }
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message);
            }



            return new OkObjectResult(responseMessage);
        }
    }
}
