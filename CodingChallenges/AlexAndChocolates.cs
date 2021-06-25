using System;
using System.Collections.Generic;

namespace EasyProblem
{
    public class AlexAndChocolates
    {

        /// <summary>
        /// Steps:
        /// 1. Sort Array, Increasing Order
        /// 2. Sumation of 0 to K-1 elements of the array A
        /// 3. Return the result
        /// </summary>
        /// <param name="N">Length of Array</param>
        /// <param name="K">Number of cholocates wanting to buy</param>
        /// <param name="A">An Array of prices associated with the chocolates</param>
        /// <returns></returns>
        public static int FindMinimumCost(int N, int K, int[] A)
        {
            int result = 0;

            Array.Sort(A);

            for (int i = 0; i < K; i++)
            {
                result += A[i];
            }

            return result;
        }

    }
}