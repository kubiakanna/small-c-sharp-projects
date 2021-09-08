using System;
using System.Diagnostics;
using System.IO;

namespace Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[600000];
            int count = 0;
            int start = 0;

            LoadFile(numbers, ref count);

            int end = count-1;

            Console.WriteLine("Unsorted: ");
            for (int a = 0; a < count; a++)
            {
                Console.WriteLine(numbers[a]);
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Quicksort(numbers, ref start, ref end);

            stopWatch.Stop();

            Console.WriteLine("Sorted: ");
            for (int b = 0; b < count; b++)
            {
                Console.WriteLine(numbers[b]);
            }

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
    ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }

        static void LoadFile(int[] numbers, ref int count)
        {
            const int SIZE = 600000;
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
                    Console.WriteLine("Wrong file format.");
                    Environment.Exit(0);
                }

                else
                {
                    numbers[count] = int.Parse(lines[count]);
                }
            }
        }

        static void RandomizedPartition (int[] numbers, ref int start, ref int end)
        {
            Random rd = new Random();

            int pivotIndex = rd.Next(start, end);
            int temp = numbers[pivotIndex];
            numbers[pivotIndex] = numbers[end];
            numbers[end] = temp;

            Partition(numbers, ref start, ref end);
        }

         static int Partition (int[] numbers, ref int start, ref int end)
        {
            int pivot = numbers[end];
            int partitionIndex = start;

            for (int i = start; i < end; i++)
            {
                if (numbers[i] <= pivot)
                {
                    int temp1 = numbers[i];
                    numbers[i] = numbers[partitionIndex];
                    numbers[partitionIndex] = temp1;
                    partitionIndex++;
                }
            }

            int temp2 = numbers[partitionIndex];
            numbers[partitionIndex] = numbers[end];
            numbers[end] = temp2;

            return partitionIndex;
        }

        static void Quicksort (int[] numbers, ref int start, ref int end)
        {
            if (start < end)
            {
                RandomizedPartition(numbers, ref start, ref end);
                int partitionIndex = Partition(numbers, ref start, ref end);
                int pIndexMinus = partitionIndex - 1;
                int pIndexPlus = partitionIndex + 1;
                Quicksort(numbers, ref start, ref pIndexMinus);
                Quicksort(numbers, ref pIndexPlus, ref end);
            }
        }
    }
}