using System;
using System.Diagnostics;
using System.IO;

namespace Bubble_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[60000];
            int count = 0;
            LoadFile(numbers, ref count);

            Console.WriteLine("Unsorted: ");
            for (int a = 0; a < count; a++)
            {
                Console.WriteLine(numbers[a]);
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int k = 1; k < count - 1; k++)
            {
                int check = 0;

                for (int i = 0; i < count - k; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        int tempI = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = tempI;
                        check = 1;
                    }
                }

                if (check == 0)
                {
                    break;
                }
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


        static void LoadFile (int[] numbers, ref int count)
        {
            const int SIZE = 51000;
            int intTest;

            string[] lines = File.ReadAllLines(@"data.txt");

            if (lines.Length > SIZE)
            {
                Console.WriteLine("Too many numbers in file.");
                Environment.Exit(0);
            }

            for (count = 0; count < lines.Length; count++)
            {
                if (!int.TryParse(lines[count], out intTest))
                {
                    Console.WriteLine("Wrong file format");
                    Environment.Exit(0);
                }

                else
                {
                    numbers[count] = int.Parse(lines[count]);
                }
            }
        }
    }
}
