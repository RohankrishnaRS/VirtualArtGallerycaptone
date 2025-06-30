using System;

namespace HotelUnhappinessApp
{
    public class HotelService
    {
        public int CalculateMinimumUnhappiness(int[] customers)
        {
            Array.Sort(customers);
            int unhappiness = 0;

            for (int i = 0; i < customers.Length; i++)
            {
                unhappiness += Math.Abs(customers[i] - (i + 1));
            }

            return unhappiness;
        }
    }
}
