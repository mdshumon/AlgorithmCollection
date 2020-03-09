using System;
using System.Collections.Generic;
using System.Text;

namespace nationwidebank
{
    public class FrogCanjumpOthersodeoftheRiver
    {
        const int FROG_CANT_JUMP_TO_THE_OTHER_SIDE = -1;
        public static int GetSecondsRequired(int requiredAmountOfLeaves, int[] fallenLeaves)
        {
            // You should comment why there's a + 1 here.
            bool[] leavesAsSteps = new bool[requiredAmountOfLeaves + 1];
            int numberOfFallenLeaves = 0;

            for (int i = 0; i < fallenLeaves.Length; i++)
            {
                int currentFallenLeaf = fallenLeaves[i];

                // Have we already checked this number?
                // Is the leaf number out of range?
                // If so, let's just stop right there for this leaf.
                if (currentFallenLeaf > requiredAmountOfLeaves
                    || leavesAsSteps[currentFallenLeaf])
                {
                    continue;
                }

                numberOfFallenLeaves++;
                leavesAsSteps[currentFallenLeaf] = true;

                // Have we marked all our leaves? We're done.
                if (numberOfFallenLeaves == requiredAmountOfLeaves)
                {
                    return i;
                }
            }

            return FROG_CANT_JUMP_TO_THE_OTHER_SIDE;
        }
    }
}
