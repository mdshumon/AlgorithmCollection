using System;
using System.Collections.Generic;
using System.Text;

namespace nationwidebank
{
    public class GenomicRangeQuery
    {

        public int[] GetMinimumImpactFactors(string S, int[] P, int[] Q)
        {
            //nuc(s) is short for nucleotide(s)
            Dictionary<char, int> nucsDict = new Dictionary<char, int>() { { 'A', 1 }, { 'C', 2 }, { 'G', 3 }, { 'T', 4 } };
            int[] result = new int[P.Length];
            int[] nucsInOrder = new int[S.Length];
            int nucsIndex = 0;
            //iterate through dictionary, looking for A's, then C's, and so on...
            foreach (var searchedImpactPair in nucsDict)
            {
                //Appearances of <searchedImpactPair.Key> have a given position in <S> chain, those positions are saved
                for (int currNucPos = 0; currNucPos < S.Length; currNucPos++)
                {
                    if (S[currNucPos] == searchedImpactPair.Key)
                    {
                        nucsInOrder[nucsIndex++] = currNucPos;
                    }
                }
            }
            int start, end, minImpactValueFound, minNucFound;
            char nucleotide;
            for (int positionWithinRange = 0; positionWithinRange < P.Length; positionWithinRange++)
            {

                start = P[positionWithinRange];
                end = Q[positionWithinRange];
                for (int nucInOrder = 0; nucInOrder < nucsInOrder.Length; nucInOrder++)
                {
                    minNucFound = nucsInOrder[nucInOrder];
                    if (minNucFound >= start && nucsInOrder[nucInOrder] <= end)
                    {
                        nucleotide = S[minNucFound];
                        minImpactValueFound = nucsDict[nucleotide];
                        result[positionWithinRange] = minImpactValueFound;
                        break;
                    }
                }
            }
            return result;
        }
    }
}
