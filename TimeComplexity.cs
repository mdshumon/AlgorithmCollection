using System;
using System.Collections.Generic;
using System.Text;

namespace nationwidebank
{
    public class TimeComplexity
    {

        public int solution(int A, int B, int K)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int result = 0;

            if (A % K == 0)
            {
                result = ((B - A) / K) + 1;
            }
            else
            {
                result = (B / K - ((A / K) + 1)) + 1;
            }

            return result;
        }
    }
}
