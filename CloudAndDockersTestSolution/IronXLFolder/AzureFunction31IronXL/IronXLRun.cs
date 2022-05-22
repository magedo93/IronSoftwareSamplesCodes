using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using IronXL;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

namespace AzureFunction31IronXL
{
    public static class IronXLRun
    {
        [FunctionName("IronXLRun")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            IronXL.License.LicenseKey = "IRONXL.NEWELLBRANDS.IRO210624.2137.64128.426012-BB5EA5D080-AW4RNQ4OTGL6K3Q-RC5N43AOC3FX-C66MZXUBOIW4-PJRSWIZYG44C-A7DG7J6LVY32-2BVMZW-LBLRTBWPJJWGEA-PROFESSIONAL.1YR-CAV22O.RENEW.SUPPORT.24.JUN.2022";
            WorkBook workBook = WorkBook.Create(ExcelFileFormat.XLS);

            var newSheet = workBook.CreateWorkSheet("new_sheet");
            string ColumnsNames = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            foreach (char col in ColumnsNames)
            {
                for (int row = 1; row <= 50; row++)
                {
                    var cellName = $"{col}{row}";
                    newSheet[cellName].Value = $"Cell : {cellName}";
                }
            }

            //Response.Headers.Add("Content-Disposition", $"inline; filename={DateTime.Now.ToString("yyyyMMddmm")}.xls");
            //return File(workBook.ToByteArray(), "application/octet-stream");

            //return new OkObjectResult(responseMessage);



            var result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(workBook.ToByteArray());
            result.Content.Headers.ContentDisposition =
                new ContentDispositionHeaderValue("attachment") { FileName = $"{DateTime.Now.ToString("yyyyMMddmm")}.xls" };
            //result.Content.Headers.ContentType =
            //    new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            return result;
        }
    }
}
