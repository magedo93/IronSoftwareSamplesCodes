using Docker31IronXlLinuxCentOS8.Models;
using IronXL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace Docker31IronXlLinuxCentOS8.Controllers
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
    }
}
