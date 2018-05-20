using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bela
{
    public static class HelperClass
    {
        /// <summary>
        /// Generates list of 32 numbers from 0 to 31 in random order
        /// </summary>
        /// <returns>Range of numbers 0 to 31 in random order</returns>
        public static List<int> DealCards()
        {
            Random rnd = new Random();
            List<int> tmpAllCardValues = new List<int>();
            // create 32 random card numbers
            for (int i = 0; i < 32; i++)
            {
                short tmp = (short)rnd.Next(32);
                if (tmpAllCardValues.Contains(tmp))
                {
                    tmp = -1;
                    do
                    {
                        tmp += 1;
                    }
                    while (tmpAllCardValues.Contains(tmp));
                }

                tmpAllCardValues.Add(tmp);
            }
            return tmpAllCardValues;
        }
    }
}
