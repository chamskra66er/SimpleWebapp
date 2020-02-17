using CarServise.Models.ForumViewModels;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarServise.Models.File
{
    public class Excel
    {
        public static IHostingEnvironment _hosting;

        public string GetPath(ReportModel model)
        {
            return  _hosting.WebRootPath + $"\\images\\forum\\{model.Pat}";
        }
        
        public FileStreamResult CreateNewFile(ReportModel model)
        {           
                XLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Information");

                worksheet.Cell(1, 1).SetValue(model.FIO);
                worksheet.Cell(1, 2).SetValue(model.Name);
                worksheet.Cell(1, 3).SetValue(model.Val);
                worksheet.Cell(1, 4).SetValue(model.Finish);

                MemoryStream MS = new MemoryStream();
                workbook.SaveAs(MS);
                MS.Position = 0;

            return new FileStreamResult(MS, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {FileDownloadName = $"{model.Pat}" };
           
        }
    }
}
