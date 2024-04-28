using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stalin
{
    public class VariacionCalculadora
    {
        
        public static bool VariacionPequena(decimal[] arregloActual, decimal[] arregloAnterior, decimal umbral)
        {
            if (arregloActual.Length != arregloAnterior.Length)
            {
                throw new ArgumentException("Los arreglos deben tener la misma longitud.");
            }

            for (int i = 0; i < arregloActual.Length; i++)
            {
                if (Math.Abs(arregloActual[i] - arregloAnterior[i]) > umbral)
                {
                    return false; // Si la variación es mayor que el umbral, retorna falso
                }
            }

            return true; // Si la variación es pequeña para todos los elementos, retorna verdadero
        }
    }
}
