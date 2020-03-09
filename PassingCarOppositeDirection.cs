using System;
using System.Collections.Generic;
using System.Text;

namespace nationwidebank
{
    public class PassingCarOppositeDirection
    {

        public static int GetNumberOfPassingCars(int[] passingCars)
        {
            if (passingCars == null) throw new ArgumentNullException(nameof(passingCars));

            const int Overflow = -1;
            const int East = 0;
            const int West = 1;
            const uint maxLimit = 1000000000;
            uint carsTravelingEast = 0, pairsOfPassingCars = 0;

            foreach (var passingCar in passingCars)
            {
                if (passingCar == East)
                {
                    ++carsTravelingEast;
                }
                else if (passingCar == West)
                {
                    pairsOfPassingCars += carsTravelingEast;
                    if (pairsOfPassingCars > maxLimit)
                    {
                        return Overflow;
                    }
                }
            }

            return (int)pairsOfPassingCars;
        }
    }
}
