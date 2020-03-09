using System;
using System.Collections.Generic;
using System.Text;

namespace nationwidebank
{
    public class ChocolateByNumber
    {
        public static int PrintNChocolatesInaCircle(int N, int M)
        {
            // these already have a known answer
            if (M == 1) return N;
            if (M == N) return 1;

            int a = N, b = M;
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }

            return N / a;
        }
    }
}
