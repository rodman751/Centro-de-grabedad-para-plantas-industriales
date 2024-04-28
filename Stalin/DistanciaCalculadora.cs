using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stalin
{
    public class DistanciaCalculadora
    {
        public static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
       
        public static decimal CalcularDistancia2(decimal X, decimal Y, decimal Xn, decimal Yn)
        {
            double distance = Math.Acos((Math.Cos(DegreeToRadian(90 - (double)X)) * Math.Cos(DegreeToRadian(90 - (double)Xn))) +
                              (Math.Sin(DegreeToRadian(90 - (double)X)) * Math.Sin(DegreeToRadian(90 - (double)Xn)) *
                               Math.Cos(DegreeToRadian((double)Yn - (double)Y)))) * 6371;

            return (decimal)distance;
        }
    }
}
