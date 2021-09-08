using System;
using System.Diagnostics;
using System.IO;

namespace Selection_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[60000];
            int count;
            int intTest;

            string[] lines = File.ReadAllLines(@"data.txt");

            if (lines.Length > 60000)
            {
                Console.WriteLine("Too many numbers in file.");
                return;
            }

            for (count = 0; count < lines.Length; count++)
            {
                if (!int.TryParse(lines[count], out intTest))
                {
                    Console.WriteLine("Wrong file.");
                    return;
                }

                else
                {
                    numbers[count] = int.Parse(lines[count]);
                }
            }
            Console.WriteLine("Unsorted: ");
            for (int a = 0; a < count; a++)
            {
                Console.WriteLine(numbers[a]);
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < lines.Length - 1; i++)
            {
                int iMin = i;
                for (int j = i + 1; j < lines.Length; j++)
                {
                    if (numbers[j] < numbers[iMin])
                    {
                        iMin = j;
                    }

                }
                int tempI = numbers[i];
                numbers[i] = numbers[iMin];
                numbers[iMin] = tempI;
            }

            stopWatch.Stop();

            Console.WriteLine("Sorted: ");
            for (int b = 0; b < count; b++)
            {
                Console.WriteLine(numbers[b]);
            }

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
    ts.Hours, ts.Minutes, ts.Seconds,
    ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }
    }
}
