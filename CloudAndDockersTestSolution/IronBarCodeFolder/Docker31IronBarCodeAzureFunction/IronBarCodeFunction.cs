using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using IronBarCode;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System;

namespace Docker31IronBarCodeAzureFunction
{
    public static class IronBarCodeFunction
    {
        [FunctionName("barcode")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            IronBarCode.License.LicenseKey = "IRONBARCODE.ELEKTRORAZPREDELENIEYUGEAD.30927-9D6D2F4BCD-FZH2BN-TMXIX66PKBKC-3T4XQOLQGYJT-N6JWJGF2GPBF-OBUGMZLVMQ5G-IEHTIQ6PZJZ4-UDYRWQ-TQSYWTZ2MRSEEA-DEPLOYMENT.TRIAL-EFTYLP.TRIAL.EXPIRES.24.FEB.2022";
            var MyBarCode = BarcodeWriter.CreateBarcode("IronBarcode Test", BarcodeEncoding.QRCode);
            var result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(MyBarCode.ToJpegBinaryData());
            result.Content.Headers.ContentDisposition =
                new ContentDispositionHeaderValue("attachment") { FileName = $"{DateTime.Now.ToString("yyyyMMddmm")}.jpg" };
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue("image/jpeg");
            return result;
        }
    }
}
