using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExcelDataReader;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;

namespace Stalin
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath = "C:\\Users\\user\\Documents\\borrar\\3. CASO UBICACIÓN DE CEDI.xlsx";
            //string filePath = "C:\\Users\\user\\Downloads\\DATOSIMPORTAR.xlsx";
            string filePath2 = "C:\\Users\\user\\Documents\\borrar\\resultados.xlsx";
            List<decimal> XnL = ExcelDataReader.ReadColumnDataFromExcel(filePath, "Datos", 5);
            List<decimal> YnL = ExcelDataReader.ReadColumnDataFromExcel(filePath, "Datos", 6);
            List<decimal> RL = ExcelDataReader.ReadColumnDataFromExcel(filePath, "Datos", 4);
            List<decimal> VL = ExcelDataReader.ReadColumnDataFromExcel(filePath, "Datos", 3);

            decimal[] Xn = XnL.ToArray();
            decimal[] Yn = YnL.ToArray();
            decimal[] R = RL.ToArray();
            decimal[] V = VL.ToArray();

            //------------------------------------------------------------------------------------------------------------------

                bool salir = false;
                while (!salir)
                {
                    Console.WriteLine("Seleccione una opción:");
                    Console.WriteLine("1. Calcular Costos y filtrar");
                    Console.WriteLine("2. Calcular el Costo Final");
                    Console.WriteLine("3. Salir");
                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
                            ExcelExporter.ExportarResultadosAExcel(ProductoCalculadora.filtro(ProductoCalculadora.CostoNEW(Xn, Yn, R, V), ProductoCalculadora.distancialocalidadantigua(Xn, Yn, R, V)), filePath2);
                            break;
                        case "2":
                            string filePathresultado = "C:\\Users\\user\\Documents\\borrar\\FILTRADOPARAIMPORTAR.xlsx";
                            string filePath2resultados = "C:\\Users\\user\\Documents\\borrar\\resultadosfinales.xlsx";
                            List<decimal> XnL2 = ExcelDataReader.ReadColumnDataFromExcel(filePathresultado, "Hoja2", 5);
                            List<decimal> YnL2 = ExcelDataReader.ReadColumnDataFromExcel(filePathresultado, "Hoja2", 6);
                            List<decimal> RL2 = ExcelDataReader.ReadColumnDataFromExcel(filePathresultado, "Hoja2", 4);
                            List<decimal> VL2 = ExcelDataReader.ReadColumnDataFromExcel(filePathresultado, "Hoja2", 3);
                            decimal[] Xn2 = XnL2.ToArray();
                            decimal[] Yn2 = YnL2.ToArray();
                            decimal[] R2 = RL2.ToArray();
                            decimal[] V2 = VL2.ToArray();

                            Console.WriteLine("COSTO2:");
                            ProductoCalculadora.Costo2(Xn2, Yn2, R2, V2);
                            Console.WriteLine("\n");
                            break;
                        case "3":
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción inválida");
                            break;
                    }
                }

                Console.ReadLine();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("No tienes el archivo Excel necesario.");
                Console.ReadLine();
            }
        }
    }
}






