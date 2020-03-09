using System;
using System.Collections.Generic;
using System.Text;

namespace nationwidebank
{
    public class MaxCounter
    {

        public static int[] GetCountersAfterApplyingOperations(int N, int[] A)
        {
            int[] countersArr = new int[N];
            int max = 0;
            int index;
            int setAllCountersOp = N;
            int floor = 0;

            for (int i = 0; i < A.Length; i++)
            {
                index = A[i] - 1;

                if (index == setAllCountersOp)
                {
                    floor = max;
                    continue;
                }

                if (countersArr[index] < floor)
                {
                    countersArr[index] = floor + 1;
                }
                else
                {
                    ++countersArr[index];
                }

                if (countersArr[index] > max)
                {
                    ++max;
                }
            }

            for (int i = 0; i < countersArr.Length; i++)
            {
                if (countersArr[i] < floor)
                {
                    countersArr[i] = floor;
                }
            }

            return countersArr;
        }
    }
}
