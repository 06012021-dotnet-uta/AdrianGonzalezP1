using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
class Result
{

    /*
     * Complete the 'queensAttack' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER r_q
     *  4. INTEGER c_q
     *  5. 2D_INTEGER_ARRAY obstacles
     */

    public static int queensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
    {
        int totalMoves = 0;
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {

                for (int obs = 0; obs < k; obs++)
                {
                    int row_obs = obstacles[obs][0];
                    int col_obs = obstacles[obs][1];

                    if (((row_obs - row) != 0) && ((col_obs - col) != 0) && ((row - r_q) != 0) && ((col - c_q != 0)))
                    {

                        // Left to right Diagnal
                        if ((row - col) == (r_q - c_q))
                        {

                            totalMoves += 1;
                        }

                        // Right To left Diagnal
                        if ((row + col) == (r_q + c_q))
                        {

                            totalMoves += 1;
                        }

                        // Check if its the same row column as Queen.
                        if ((row == r_q || col == c_q))
                        {
                            totalMoves += 1;
                        }
                    }

                }
            }
        }

        return totalMoves;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int r_q = Convert.ToInt32(secondMultipleInput[0]);

        int c_q = Convert.ToInt32(secondMultipleInput[1]);

        List<List<int>> obstacles = new List<List<int>>();

        for (int i = 0; i < k; i++)
        {
            obstacles.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(obstaclesTemp => Convert.ToInt32(obstaclesTemp)).ToList());
        }

        int result = Result.queensAttack(n, k, r_q, c_q, obstacles);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}





