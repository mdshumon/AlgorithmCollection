using System;
using System.Collections.Generic;
using System.Text;

namespace nationwidebank
{
   public class VariousFishAreMoving
    {
        public int solution(int[] A, int[] B)
        {
            
            const int DownstreamFloater = 1;

            Stack<int> downstreamersStack = new Stack<int>();

            //int topStackDownstreamer;

            int aliveFishesCounter = 0;

            for (int fish = 0; fish < B.Length; fish++)
            {
                if (B[fish] == DownstreamFloater)
                {
                    downstreamersStack.Push(fish);
                }
                else // must be UpstreamFloater
                {
                    while (downstreamersStack.Count > 0)
                    {
                        if (A[fish] > A[downstreamersStack.Peek()])
                        {
                            downstreamersStack.Pop();
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (downstreamersStack.Count == 0)
                    {
                        aliveFishesCounter++;
                    }
                }
            }
            aliveFishesCounter += downstreamersStack.Count;
            return aliveFishesCounter;
        }
    }
}
