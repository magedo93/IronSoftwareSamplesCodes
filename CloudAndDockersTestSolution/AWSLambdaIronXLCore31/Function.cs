using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using IronXL;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambdaIronXLCore31
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

            return Convert.ToBase64String( workBook.ToByteArray());
        }
    }
}
