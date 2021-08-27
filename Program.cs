using System;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array100 = CreateArray(10, -100, 100);
            int[] arrayA = CreateArray(20, 0, 2000);
            int[] arrayB = new int[20];
            
            // Task #1
            Console.WriteLine("Task #1");
            foreach (int key in array100)
            {
                Console.Write($"{key}, ");
            }
            
            Console.WriteLine();
            Console.WriteLine("--------------------");

            // Task #2
            MergeArray(arrayB, arrayA, 888);
            Console.WriteLine("Task #2");
            Console.WriteLine("Source Array:");
            foreach (int key in arrayA)
            {
                Console.Write($"{key}, ");
            }
            Console.WriteLine();
            Console.WriteLine("Target Array:");
            foreach (int key in arrayB)
            {
                Console.Write($"{key}, ");
            }
        }

        static int[] CreateArray(int size, int min, int max)
        {
            Random random = new Random();
            int[] result = new int[size];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = random.Next(min, max);
            }

            return result;
        }

        static void MergeArray(int[] target, int[] source, int limit)
        {
            int targetIndex = 0;
            
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] <= limit)
                {
                    target[targetIndex] = source[i];
                    targetIndex++;
                }
            }
        }
    }
}