using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stalin
{
    public class ExcelExporter
    {
        public static void ExportarAExcel(decimal[] da, decimal[] costos, string nombreHoja)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Ruta del archivo de Excel
            var filePath = @"C:\Users\user\Documents\borrar\DYDDD.xlsx";

            // Crear un nuevo archivo de Excel si no existe
            FileInfo fileInfo = new FileInfo(filePath);
            ExcelPackage package;
            if (!fileInfo.Exists)
            {
                package = new ExcelPackage();
            }
            else
            {
                // Abrir el archivo existente
                package = new ExcelPackage(fileInfo);
            }

            // Verificar si la hoja ya existe
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault(sheet => sheet.Name == nombreHoja);
            if (worksheet == null)
            {
                // Agregar una nueva hoja de trabajo al libro de Excel solo si no existe
                worksheet = package.Workbook.Worksheets.Add(nombreHoja);
                // Encabezados
                worksheet.Cells[1, 1].Value = "Distancia";
                worksheet.Cells[1, 2].Value = "Costo";
            }

            // Escribir datos en las celdas
            int rowCount = worksheet.Dimension?.Rows ?? 1;
            for (int i = 0; i < da.Length; i++)
            {
                worksheet.Cells[rowCount + i, 1].Value = da[i];
                worksheet.Cells[rowCount + i, 2].Value = costos[i];
            }

            // Guardar el libro de Excel
            package.SaveAs(fileInfo);
        }
        public static void ExportarResultadosAExcel(decimal[] costo, string ruta)
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Crear un nuevo archivo de Excel
            var fileInfo = new FileInfo(ruta);
            using (var package = new ExcelPackage(fileInfo))
            {
                // Agregar una hoja de trabajo al libro de Excel
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Resultadosfiltrados");

                // Encabezados

                worksheet.Cells[1, 1].Value = "CostosFiltrados";

                // Escribir datos en las celdas
                for (int i = 0; i < costo.Length; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = costo[i];

                }

                // Guardar el libro de Excel
                package.Save();
            }
        }
    }
}
