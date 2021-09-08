using System;
using System.Diagnostics;
using System.IO;

namespace Insertion_Sort
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

            for (int i = 1; i < count; i++)
            {
                int value = numbers[i];
                int hole = i;
                while (hole > 0 && numbers[hole-1] > value)
                {
                    numbers[hole] = numbers[hole - 1];
                    hole = hole - 1;
                }
                numbers[hole] = value;
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

        static void LoadFile(int[] numbers, ref int count)
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
                    Console.WriteLine("Wrong file.");
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