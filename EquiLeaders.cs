using System;
using System.Collections.Generic;
using System.Text;

namespace nationwidebank
{
  public  class EquiLeaders
    {
        public int solution(int[] A)
        {
            var leftPartition = new Dictionary<int, int>();
            var rightPartition = new Dictionary<int, int>();

            for (var index = A.Length - 1; index >= 0; index--)
            {
                var candidate = A[index];
                rightPartition.TryGetValue(candidate, out int value);
                rightPartition[candidate] = value + 1;
            }

            var leadersCounter = 0;
            var leftPartitionSize = 1;
            var rightPartitionSize = A.Length;
            var leader = A[0];

            for (var index = 0; index < A.Length; index++)
            {
                var candidate = A[index];

                leftPartition.TryGetValue(candidate, out int value);
                leftPartition[candidate] = value + 1;

                rightPartition[candidate]--;
                rightPartitionSize--;

                if (leftPartition[candidate] > leftPartitionSize / 2)
                {
                    leader = candidate;
                }
                if (leftPartition[leader] > leftPartitionSize / 2 && rightPartition[leader] > rightPartitionSize / 2)
                {
                    leadersCounter++;
                }
                leftPartitionSize++;
            }
            return leadersCounter;
        }
    }
}
