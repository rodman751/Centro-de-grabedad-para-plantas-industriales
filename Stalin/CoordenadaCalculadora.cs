using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stalin
{
    public class CoordenadaCalculadora
    {
        public static decimal CalcularX(decimal[] V, decimal[] R, decimal[] Xn, decimal[] Da)
        {
            decimal numerador = 0;
            decimal denominador = 0;

            // Calcular el numerador y el denominador
            for (int i = 0; i < V.Length; i++)
            {
                numerador += (V[i] * R[i] * Xn[i]) / Da[i];
                denominador += (V[i] * R[i]) / Da[i];
            }

            // Evitar división por cero
            if (denominador == 0)
            {
                throw new InvalidOperationException("No se puede dividir por cero.");
            }

            // Calcular X o Y
            return numerador / denominador;
        }

        public static decimal CalcularXY(decimal[] V, decimal[] Xn)
        {
            decimal numerador = 0;
            decimal denominador = 0;

            // Calcular el numerador y el denominador
            for (int i = 0; i < V.Length; i++)
            {
                numerador += (Xn[i] * V[i]);
                denominador += V[i];
            }

            // Evitar división por cero
            if (denominador == 0)
            {
                throw new InvalidOperationException("No se puede dividir por cero.");
            }

            // Calcular X
            return numerador / denominador;
        }
    }
}
