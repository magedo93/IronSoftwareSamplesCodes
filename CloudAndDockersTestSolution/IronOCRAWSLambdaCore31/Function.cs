using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using IronOcr;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace IronOCRAWSLambdaCore31
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(string input, ILambdaContext context)
        {
            IronOcr.Installation.LicenseKey = "IRONOCR.SVENSTUPELER.26520-77B2F8AD3D-PN2LISURTB4HEFI7-UYNS7FOVCJ2F-57IGMTN7VAGU-QGDJRB4WSTFO-RYCUVPGAYV6M-TXUNHY-TIIWJXBV26WDEA-DEPLOYMENT.TRIAL-FZRONE.TRIAL.EXPIRES.04.JAN.2022";
            string responseMessage = "";
            var Ocr = new IronTesseract();
            var fileImage = "testOCR.PNG";// Path.Combine(context.FunctionName, "testOCR.PNG");
            var filePdf = "IronOCRText.pdf";// Path.Combine(context.FunctionName, "IronOCRText.pdf");
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
                return ex.Message;
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
                return ex.Message;
            }
            return responseMessage;
            //return input?.ToUpper();
        }
    }
}
