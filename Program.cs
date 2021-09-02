using System;
using System.Text;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input array length:");

            string readLine = Console.ReadLine();
            char[] checkList = {'a', 'e', 'i', 'd', 'h', 'j'};
            int valueMin = 1;
            int valueMax = 26;

            if (!int.TryParse(readLine.Trim(), out int arraySize))
            {
                Console.WriteLine("Not a digit!");
                return;
            }

            int[] arraySource = GenerateArrayMinMax(arraySize, valueMin, valueMax);
            int[] arrayOdd = FilterByParity(arraySource, true);
            int[] arrayEven = FilterByParity(arraySource, false);
            char[] charArrayOdd = GetLettersByNumber(arrayOdd);
            char[] charArrayEven = GetLettersByNumber(arrayEven);

            charArrayOdd = ReplaceWithRule(charArrayOdd, checkList);
            charArrayEven = ReplaceWithRule(charArrayEven, checkList);

            int upperCountOdd = GetUppercaseCount(charArrayOdd);
            int upperCountEven = GetUppercaseCount(charArrayEven);


            // OUTPUT
            Console.WriteLine();
            Console.WriteLine("Results:");
            Console.WriteLine(GetSplittedStringFromChars(charArrayOdd));
            Console.WriteLine($"{upperCountOdd} {(upperCountOdd > upperCountEven ? "<- the longest!" : "")}");
            Console.WriteLine(GetSplittedStringFromChars(charArrayEven));
            Console.WriteLine($"{upperCountEven} {(upperCountOdd < upperCountEven ? "<- the longest!" : "")}");
            Console.ReadKey();
        }

        static int[] GenerateArrayMinMax(int size, int min, int max)
        {
            int[] result = new int[size];
            Random randomGen = new Random();

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = randomGen.Next(min, max);
            }

            return result;
        }

        static int[] FilterByParity(int[] source, bool isOdd)
        {
            int newArrayLength = 0;

            foreach (var item in source)
            {
                if (isOdd ? item % 2 == 0 : item % 2 != 0)
                {
                    newArrayLength++;
                }
            }

            int[] result = new int[newArrayLength];
            int resultIndex = 0;

            foreach (var item in source)
            {
                if (isOdd ? item % 2 == 0 : item % 2 != 0)
                {
                    result[resultIndex] = item;
                    resultIndex++;
                }
            }
            
            return result;
        }

        static char[] GetLettersByNumber(int[] source)
        {
            int shift = 96;
            char[] result = new char[source.Length];

            for (int i = 0; i < source.Length; i++)
            {
                result[i] = (char) (source[i] + shift);
            }
            
            return result;
        }

        static bool Includes(char itemToTest, char[] checkList)
        {
            bool result = false;

            foreach (var item in checkList)
            {
                if (itemToTest == item)
                {
                    result = true;
                }
            }

            return result;
        }

        static char[] ReplaceWithRule(char[] source, char[] checkList)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (Includes(source[i], checkList))
                {
                    source[i] = Char.ToUpperInvariant(source[i]);
                }
            }

            return source;
        }

        static int GetUppercaseCount(char[] source)
        {
            int result = 0;

            foreach (var item in source)
            {
                if (Char.IsUpper(item))
                {
                    result++;
                }
            }

            return result;
        }

        static string GetSplittedStringFromChars(char[] source)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < source.Length; i++)
            {
                result.Append(source[i]);
                if (i < source.Length - 1)
                {
                    result.Append(' ');
                }
            }

            return result.ToString();
        }
    }
}