using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OraRend
{
    internal class Excelizer
    {
        // Adunk egy tulajdonságot az osztálynak, ez lesz az elérési út
        public string Path { get; set; }
        // Konstruktorba ezt bekérjük és be is állítjuk
        public Excelizer(string path)
        {
            this.Path = path;
        }
        public void CreateTimeTable(List<UniClass> classes)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Órarend");

                int startHour = 8; // Innen indítjuk a napot
                int endHour = 21; // Itt fejezzük be

                for (int hour = startHour; hour <= endHour; hour++)
                {
                    for (int minute = 0; minute < 60; minute += 10)
                    {
                        int rowIndex = 2 + ((hour - startHour) * 6) + (minute / 10);
                        worksheet.Cells[rowIndex, 1].Value = $"{hour:D2}:{minute:D2}";
                    }
                }
                worksheet.Cells[1, 2].Value = "Hétfő";
                worksheet.Cells[1, 4].Value = "Kedd";
                worksheet.Cells[1, 6].Value = "Szerda";
                worksheet.Cells[1, 8].Value = "Csütörtök";
                worksheet.Cells[1, 10].Value = "Péntek";

                worksheet.Row(1).Height = 30;
                var font = worksheet.Cells["1:1"].Style.Font;
                font.Bold = true;
                for (int i = 0; i < classes.Count; i++)
                {
                    UniClass uniClass = classes[i];

                    int startRowIndex = 2 + (((uniClass.StartTime.Hours - startHour) * 6) + (uniClass.StartTime.Minutes / 10));
                    int endRowIndex = 2 + (((uniClass.EndTime.Hours - startHour) * 6) + (uniClass.EndTime.Minutes / 10));

                    worksheet.Cells[startRowIndex, 2 + uniClass.DayOfWeek * 2].Value = uniClass.Title;

                    worksheet.Cells[startRowIndex, 2 + uniClass.DayOfWeek * 2].Style.WrapText = true;

                    worksheet.Column(2 + uniClass.DayOfWeek * 2).Width = 12;
                    worksheet.Column(2 + uniClass.DayOfWeek * 2 + 1).Width = 2;

                    worksheet.Cells[startRowIndex, 2 + uniClass.DayOfWeek * 2].Style.VerticalAlignment = ExcelVerticalAlignment.Top;

                    var fill = worksheet.Cells[startRowIndex, 2 + uniClass.DayOfWeek * 2].Style.Fill;
                    fill.PatternType = ExcelFillStyle.LightTrellis;
                    fill.BackgroundColor.SetColor(Color.Fuchsia);

                    worksheet.Cells[startRowIndex, 2 + uniClass.DayOfWeek * 2, endRowIndex, 2 + uniClass.DayOfWeek * 2].Merge = true;

                }

                package.SaveAs(new FileInfo(System.IO.Path.Combine(this.Path, "Orarend.xlsx")));

            }
        }
    }
}
