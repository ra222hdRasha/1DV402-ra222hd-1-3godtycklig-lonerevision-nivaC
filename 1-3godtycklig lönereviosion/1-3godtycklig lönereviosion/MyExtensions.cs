using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3godtycklig_lönereviosion
{
    public static class MyExtensions
    {
        //**********************************************************************************************************
        //Metoden ska beräkna lönespridningen på de löner som skickas som argument i form av en array till metoden.*
        //**********************************************************************************************************
        public static int Dispersion(this int[] source)
        {

            return source.Max() - source.Min();
        }

        //****************************************************************************************
        //Metden ska beräkna medianlönen av de löner som skickas som argument i form av en array.*
        //****************************************************************************************
        public static int Median(this int[] source)
        {
            //List-objekt som kan innehålla referenser till int-objekt T i List<T> ersätts med typ som List-objekt ska innehålla
            List<int> integer = new List<int>(source);
            integer.Sort();
            while (integer.Count() > 2)
            {
                integer.RemoveAt(0);   //tarr bort det första element
                integer.RemoveAt(integer.Count() - 1);

            }
            if (integer.Count == 2)
            {
                return (int)Math.Round(integer.Average());
            }
            else
            {
                return integer[0];
            }
        }
    }
}
