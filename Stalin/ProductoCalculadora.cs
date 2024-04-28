using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stalin
{
    public class ProductoCalculadora
    {
        public static decimal SumaProducto(decimal[] V, decimal[] R, decimal[] Da)
        {
            decimal suma = 0;
            for (int i = 0; i < V.Length; i++)
            {
                suma += V[i] * R[i] * Da[i];
            }
            return suma;
        }

        public static decimal[] CostoNEW(decimal[] Xn, decimal[] Yn, decimal[] R, decimal[] V)
        {
            // Definir los arreglos Xn y Yn

            decimal inicio = 0;
            decimal[] da = new decimal[Xn.Length];
            decimal[] daAnterior = new decimal[Xn.Length]; // Almacenar los valores anteriores de da
            decimal umbral = 0.001m; // Umbral para la variación pequeña
            decimal costo = 0;
            int contador = 0;
            decimal[] costos;

            do
            {
                Array.Copy(da, daAnterior, da.Length); // Copiar los valores actuales de da a daAnterior

                if (contador == 0)
                {
                    for (int i = 0; i < Xn.Length; i++)
                    {
                        da[i] = DistanciaCalculadora.CalcularDistancia2(inicio, inicio, Xn[i], Yn[i]);
                    }
                }
                else
                {
                    decimal x = CoordenadaCalculadora.CalcularXY(V, Xn);
                    decimal y = CoordenadaCalculadora.CalcularXY(V, Yn);

                    for (int i = 0; i < Xn.Length; i++)
                    {
                        da[i] = DistanciaCalculadora.CalcularDistancia2(x, y, Xn[i], Yn[i]);
                    }
                }

                costo = SumaProducto(V, R, da);
                contador++;

            } while (!VariacionCalculadora.VariacionPequena(da, daAnterior, umbral));
            costos = SumaCostos(V, R, da);
            //Imprimir(da, costos);
            ExcelExporter.ExportarAExcel(da, costos, "CostoNEW babahoyo");
            Console.WriteLine("costo1: " + costo);

            decimal xFinal = CoordenadaCalculadora.CalcularXY(V, Xn);
            decimal yFinal = CoordenadaCalculadora.CalcularXY(V, Yn);

            Console.WriteLine("x: " + xFinal + ", y: " + yFinal);

            //Console.ReadLine();
            return costos;
        }
        public static decimal[] distancialocalidadantigua(decimal[] Xn, decimal[] Yn, decimal[] R, decimal[] V)
        {
            // Definir los arreglos Xn y Yn

            decimal inicio = -1.2761765591335013m;
            decimal inicio2 = -78.65500410014276m;
            decimal[] dab = new decimal[Xn.Length];
            decimal[] daAnterior = new decimal[Xn.Length]; // Almacenar los valores anteriores de da
            decimal umbral = 0.001m; // Umbral para la variación pequeña
            decimal costo = 0;
            decimal[] costos;
            int contador = 0;

            do
            {
                Array.Copy(dab, daAnterior, dab.Length); // Copiar los valores actuales de da a daAnterior

                if (contador == 0)
                {
                    for (int i = 0; i < Xn.Length; i++)
                    {
                        dab[i] = DistanciaCalculadora.CalcularDistancia2(inicio, inicio2, Xn[i], Yn[i]);
                    }
                }
                else
                {
                    decimal x = CoordenadaCalculadora.CalcularX(V, R, Xn, dab);
                    decimal y = CoordenadaCalculadora.CalcularX(V, R, Yn, dab);

                    for (int i = 0; i < Xn.Length; i++)
                    {
                        dab[i] = DistanciaCalculadora.CalcularDistancia2(x, y, Xn[i], Yn[i]);

                    }
                }

                costo = ProductoCalculadora.SumaProducto(V, R, dab);


                contador++;

            } while (!VariacionCalculadora.VariacionPequena(dab, daAnterior, umbral));
            costos = ProductoCalculadora.SumaCostos(V, R, dab);
            //Imprimir(dab, costos);    //para ver las distancias descomentar el imprimir
            ExcelExporter.ExportarAExcel(dab, costos, "distancialocalidadantigua");

            Console.WriteLine("costo viejo: " + costo);

            decimal xFinal = CoordenadaCalculadora.CalcularX(V, R, Xn, dab);
            decimal yFinal = CoordenadaCalculadora.CalcularX(V, R, Yn, dab);


            Console.WriteLine("x: " + xFinal + ", y: " + yFinal);

            return costos;

        }

        static decimal[] SumaCostos(decimal[] V, decimal[] R, decimal[] Da)
        {
            decimal[] costos = new decimal[V.Length]; // Crear un arreglo para almacenar los resultados
            for (int i = 0; i < V.Length; i++)
            {
                costos[i] = V[i] * R[i] * Da[i]; // Calcular el producto y guardarlo en el arreglo
            }
            return costos; // Devolver el arreglo de resultados
        }

        public static decimal[] filtro(decimal[] costo1, decimal[] costoviejo)
        {
            decimal[] Costosfiltrados = new decimal[costo1.Length];

            for (int i = 0; i < costo1.Length && i < costoviejo.Length; i++)
            {
                if (costo1[i] < costoviejo[i])
                {
                    Costosfiltrados[i] = costo1[i];
                }
            }
            for (int i = 0; i < Costosfiltrados.Length; i++)
            {
                Console.WriteLine("Costo:" + Costosfiltrados[i]);
            }

            return Costosfiltrados;
        }


        //public static void Costo2(decimal[] Xn, decimal[] Yn, decimal[] R, decimal[] V)
        //    {
        //        // Definir los arreglos Xn y Yn

        //        decimal inicio = 0;
        //        decimal[] dab = new decimal[Xn.Length];
        //        decimal[] daAnterior = new decimal[Xn.Length]; // Almacenar los valores anteriores de da
        //        decimal umbral = 0.001m; // Umbral para la variación pequeña
        //        decimal costo = 0;
        //        decimal[] costos;
        //        int contador = 0;

        //        do
        //        {
        //            Array.Copy(dab, daAnterior, dab.Length); // Copiar los valores actuales de da a daAnterior

        //            if (contador == 0)
        //            {
        //                for (int i = 0; i < Xn.Length; i++)
        //                {
        //                    dab[i] = CalcularDistancia2(inicio, inicio, Xn[i], Yn[i]);
        //                }
        //            }
        //            else
        //            {
        //                decimal x = CalcularX(V, R, Xn, dab);
        //                decimal y = CalcularX(V, R, Yn, dab);

        //                for (int i = 0; i < Xn.Length; i++)
        //                {
        //                    dab[i] = CalcularDistancia2(x, y, Xn[i], Yn[i]);

        //                }
        //            }

        //            costo = SumaProducto(V, R, dab);


        //            contador++;

        //        } while (!VariacionPequena(dab, daAnterior, umbral));
        //        costos = SumaCostos(V, R, dab);                            //ESTE EL EL IMPORTNATE
        //        Imprimir(dab, costos);    //para ver las distancias descomentar el imprimir
        //        ExportarAExcel(dab, costos, "Costo2 guayakill");

        //        Console.WriteLine("costo2: " + costo);

        //        decimal xFinal = CalcularX(V, R, Xn, dab);
        //        decimal yFinal = CalcularX(V, R, Yn, dab);


        //        Console.WriteLine("x: " + xFinal + ", y: " + yFinal);



        //    }
    }
}
