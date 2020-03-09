using System;
using System.Collections.Generic;
using System.Text;

namespace nationwidebank
{
    public class Permutation
    {
        public static bool IsPermutation(int[] values)
        {
            var seen = new bool[values.Length];

            foreach (var value in values)
            {
                if (value < 1 || value > values.Length)
                {
                    // Out of range: not a permutation
                    return false;
                }
                else if (seen[value - 1])
                {
                    // Duplicated value: not a permutation
                    return false;
                }
                else
                {
                    // Value is OK. Mark as seen.
                    seen[value - 1] = true;
                }
            }

            // All values in range, no duplicates: a valid permutation
            return true;
        }
    }
}
