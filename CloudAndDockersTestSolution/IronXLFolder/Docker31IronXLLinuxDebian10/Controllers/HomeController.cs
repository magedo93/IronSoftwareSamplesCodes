using Docker31IronXLLinuxDebian10.Models;
using IronXL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace Docker31IronXLLinuxDebian10.Controllers
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

            Response.Headers.Add("Content-Disposition", $"inline; filename={DateTime.Now.ToString("yyyyMMddmm")}.xls");
            return File(workBook.ToByteArray(), "application/octet-stream");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public void TestXL()
        //{
        //    WorkBook workBook = WorkBook.Load("File.xlsx");
        //    var newSheet = workBook.DefaultWorkSheet;
        //    string ColumnsNames = "ABCDE";
            
        //    for (int row = 3; row <= 5; row++)
        //    {
        //        var DataBaseRowModel = new DataBaseRowModel();
        //        foreach (char col in ColumnsNames)
        //        {
        //            var cellName = $"{col}{row}";

        //            switch (col)
        //            {
        //                case 'A': DataBaseRowModel.Name = newSheet[cellName].Value; break;
        //                case 'B': DataBaseRowModel.MarsProduced = newSheet[cellName].Value; break;
        //                case 'C': DataBaseRowModel.MarsSold = newSheet[cellName].Value; break;
        //                case 'D': DataBaseRowModel.VenusProduced = newSheet[cellName].Value; break;
        //                case 'E': DataBaseRowModel.MarsSold = newSheet[cellName].Value; break;
        //                default: break;
        //            }
        //        }
        //        DataBaseContext.CreateNewRow(DataBaseRowModel);
        //    }
        //}
    }
}
