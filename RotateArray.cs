using System;
using System.Collections.Generic;
using System.Text;

namespace nationwidebank
{
    public class RotateArray
    {
        public int[] solution(int[] A, int K)
        {
            int len = A.Length;
            int[] B = new int[len];
            if (len > 0 && K % len != 0)
            {
                for (int i = 0; i < len; i++)
                {
                    B[(K + i) % len] = A[i];
                }
            }
            else
            {
                return A;
            }
            return B;
        }
    }
}
