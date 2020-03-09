using System;
using System.Collections.Generic;
using System.Text;

namespace nationwidebank
{
    public class OddOccuranceInaArray
    {
        public static int GetOddUnpairNumber(int[] A)
        {

            //int[] A = { 9, 3, 9, 3, 9, 7, 9 };
            int result = 0;
            foreach (var i in A)
                result ^= i;            
            return result;
        }
    }
}
