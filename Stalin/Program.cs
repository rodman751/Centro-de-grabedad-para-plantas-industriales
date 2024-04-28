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


            //Console.WriteLine("COSTO2:");
            //Costo2(Xn, Yn, R, V);
            //Console.WriteLine("\n");

      
            Console.WriteLine("\n");
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            ExcelExporter.ExportarResultadosAExcel(ProductoCalculadora.filtro(ProductoCalculadora.CostoNEW(Xn, Yn, R, V), ProductoCalculadora.distancialocalidadantigua(Xn, Yn, R, V)), filePath2);




            Console.ReadLine();
        }

    }
}






