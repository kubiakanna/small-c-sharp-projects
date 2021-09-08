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

            MergeSort(numbers, ref count);

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
                    Console.WriteLine("Wrong file format.");
                    Environment.Exit(0);
                }

                else
                {
                    numbers[count] = int.Parse(lines[count]);
                }
            }
        }

        static void MergeSort(int[] numbers, ref int count)
        {
            if (count < 2)
                return;

            int mid = count / 2;
            int[] left = new int[mid];
            int[] right = new int[count - mid];

            int i;
            for (i = 0; i < mid; i++)
            {
                left[i] = numbers[i];
            }

            int j;
            for (j = mid; j < count; j++)
            {
                right[j - mid] = numbers[j];
            }

            int rightLength = j - mid;

            MergeSort(left, ref i);
            MergeSort(right, ref rightLength);
            Merge(left, ref i, right, ref rightLength, numbers, ref count);
        }

        static void Merge(int[] L, ref int leftLength,
            int[] R, ref int rightLength,
            int[] A, ref int count)
        {
            int i = 0;
            int j = 0;
            int k = 0;

            while (i < leftLength && j < rightLength)
            {
                if (L[i] <= R[j])
                {
                    A[k] = L[i];
                    i++;
                }

                else
                {
                    A[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < leftLength)
            {
                A[k] = L[i];
                i++;
                k++;
            }

            while (j < rightLength)
            {
                A[k] = R[j];
                j++;
                k++;
            }
        }
    }
}