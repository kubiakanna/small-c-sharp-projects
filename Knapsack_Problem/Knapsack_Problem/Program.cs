using System;
using System.IO;

namespace Knapsack_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] weights = new int[1000000];
            int[] values = new int[1000000];
            int count = 0;
            LoadFile(weights, values, ref count);

            int sackSize = 7;
            int[,] sackTable = new int[count + 1, sackSize + 1];

            KnapsackSolution(sackTable, weights, values, ref count, sackSize);

            int rowLength = count + 1;
            int colLength = sackSize + 1;

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", sackTable[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }

            WhichItems(sackTable, weights, values, ref count, sackSize);
        }

        static void LoadFile(int[] weights, int[] values, ref int count)
        {
            string[] lines = File.ReadAllLines(@"knapsack.txt");

            for (count = 0; count < lines.Length; count++)
            {
                string[] line = lines[count].Split();
                weights[count] = int.Parse(line[0]);
                values[count] = int.Parse(line[1]);
            }
        }

        static void KnapsackSolution(int[,] sackTable, int[] weights, int[] values, ref int count, int sackSize)
        {
            for (int i = 0; i < count + 1; i++)
            {
                for (int j = 0; j < sackSize + 1; j++)
                {
                    if (i == 0 || j == 0)
                        continue;

                    else if (j < weights[i - 1])
                        sackTable[i, j] = sackTable[i - 1, j];

                    else
                        sackTable[i, j] = Math.Max(sackTable[i - 1, j], sackTable[i - 1, j - weights[i - 1]] + values[i - 1]);
                }
            }
        }

        static void WhichItems(int[,] sackTable, int[] weights, int[] values, ref int count, int sackSize)
        {
            Console.WriteLine("Items inside of the knapsack are numbered: ");

            int result = sackTable[count, sackSize];
            int column = sackSize;

            for (int i = count; i > 0 && result > 0; i--)
            {
                if (result == sackTable[i - 1, column])
                    continue;

                else
                {
                    Console.Write(i + " ");

                    result = result - values[i - 1];
                    column = column - weights[i - 1];
                }
            }

        }
    }
}
