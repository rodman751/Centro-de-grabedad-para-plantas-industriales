using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stalin
{
    public class ExcelDataReader
    {
        public static List<decimal> ReadColumnDataFromExcel(string filePath, string sheetName, int columnIndex)
        {
            // Creamos un stream para leer el archivo Excel
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Utilizamos ExcelDataReader para leer el archivo
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Configuramos el lector para leer todo el contenido del archivo Excel
                    var dataSet = reader.AsDataSet();

                    // Accedemos a la hoja específica
                    var dataTable = dataSet.Tables[sheetName];

                    // Creamos una lista para almacenar los datos de la columna
                    List<decimal> columnData = new List<decimal>();

                    // Iteramos sobre las filas de la hoja de trabajo
                    for (int i = 1; i < dataTable.Rows.Count; i++) // Comenzamos desde 1 para omitir el encabezado
                    {
                        // Obtenemos el valor de la celda en la columna específica
                        decimal cellValue;
                        if (decimal.TryParse(dataTable.Rows[i][columnIndex]?.ToString(), out cellValue))
                        {
                            // Agregamos el valor a la lista
                            columnData.Add(cellValue);
                        }
                        else
                        {
                            // Manejo de errores si la conversión falla
                            Console.WriteLine("No se pudo convertir el valor en la fila " + (i + 1) + " a decimal.");
                        }
                    }

                    return columnData;
                }
            }
        }
    }
}
