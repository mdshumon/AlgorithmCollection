using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace nationwidebank
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(GetMaxPossibleInsertions("dog"));            
            Console.WriteLine(GetCount("dog"));
            Console.WriteLine(GetCount("aa"));
            Console.WriteLine(GetCount("aaa"));
            Console.WriteLine(GetCount("baaaa"));
            // int[] A = { 9, 3, 9, 3, 9, 7, 9 };
            //Console.WriteLine(OddOccuranceInaArray.GetOddUnpairNumber(A));



            Console.ReadKey();
        }

        
        static int Solution(string[] S)
        {
            var max = 0;

            for (int i = 0; i < S.Length; i++)
            {
                HashSet<char> tempHashSet = new HashSet<char>();

                for (int j = S.Length - 1; j > i; j--)
                {
                    string item = S[i];
                    string item2 = S[j];

                    var fullStr = item + item2;

                    foreach (var c in fullStr.ToCharArray())
                    {
                        if (!tempHashSet.Add(c))
                        {
                            tempHashSet.Clear();
                            break;
                        }
                    }

                    var hashSetLen = tempHashSet.Count();

                    if (hashSetLen > max)
                    {
                        max = hashSetLen;
                    }
                }
            }

            return max;
        }
    }
}



public static int GetCount(string S, int n = 2)
        {
            if (string.IsNullOrEmpty(S)) throw new ArgumentException("invalid input");
            char a = 'a';
            int tempSum = 2;
            if (S.ToLower().Contains( "aaa"))
                return -1;
            else if (S.ToLower() == "aa")
                return 0;
            else
            {
                foreach (var c in S.ToLower().ToCharArray())
                {
                    if (c == a)
                        tempSum += -1;
                    else
                        tempSum += 2;

                }
            }

            //var sum = S.ToCharArray().Select(x => x == 'a' ? -1 : +2).Sum() + 2;
            return tempSum;
        }

        //public static int GetCount2(string S, int n = 2)
        //{
        //    if (string.IsNullOrEmpty(S)) throw new ArgumentException("invalid input");
        //    else if (S.ToLower() == "aaa") return -1;
        //    else if (S.ToLower() == "aa") return 0;
        //    var sum = S.ToCharArray().Select(x => x == 'a' ? -1 : +2).Sum() + 2;
        //    return sum;
        //}



        public int solution(int[] A)
        {

            int temp = 0;
            HashSet<int> ls = new HashSet<int>();
            for (int i = 0; i < A.Length - 1; i++)
                ls.Add(A[i]);

            for (int i = 1; i < 9999999; i++)
            {
                if (!ls.Contains(i))
                {
                    temp = i;
                    break;
                }
            }
            return temp;
        }




        //public static int GetCount(string S, int n = 2)
        //{
        //    if (string.IsNullOrEmpty(S)) throw new ArgumentException("invalid input");
        //    else if (S.ToLower() == "aaa") return -1;
        //    else if (S.ToLower() == "aa") return 0;
        //    var sum = S.ToCharArray().Select(x => x == 'a' ? -1 : +2).Sum() + 2;
        //    return sum;
        //}

        public static int GetMaxPossibleInsertions(string s = "", char c = 'a', int n = 3)
        {
            var max = -1;
            var k = n - 1;
            var pattern = new Regex($@"[{c}]{{{n}}}", RegexOptions.Compiled);
            var permutations = Permutate(s, c, k).Where(p => !pattern.IsMatch(p)).ToArray();

            max = permutations
                .Select(p => p.Count(x => x == c) - s.Count(x => x == c))
                .DefaultIfEmpty(max)
                .Max();

            return max;
        }

        public static IEnumerable<string> Permutate(string s = "", char c = 'a', int k = 2)
        {
            if (s == null)
                yield break;
            if (k < 1) k = 1;
            var buffer = new StringBuilder(s);
            foreach (var p in Permutate(buffer, c, k, 0, s.Length).Distinct()/*.OrderBy(x => x)*/)
            {
                yield return p;
            }
        }

        static IEnumerable<string> Permutate(StringBuilder buffer, char c, int k, int m, int i)
        {
            // any intermediate result is a permutation
            yield return buffer.ToString();
            if (m < k)
            {
                // recursively find permutations with an inserted character
                buffer.Insert(i, c);
                foreach (var p in Permutate(buffer, c, k, m + 1, i))
                {
                    yield return p;
                }
                buffer.Remove(i, 1);
            }
            if (i > 0)
            {
                // recursively find permutations with the insertion index moved back
                foreach (var p in Permutate(buffer, c, k, 0, i - 1))
                {
                    yield return p;
                }
            }
        }
    }
}
