using System;
using System.Collections.Generic;

namespace TaskV5.TaskV5
{
    public static class TaskV5
    {
        public static void TaskV5Main()
        {
            var charList = StringToList(Input("Enter char sequence > "));
            Console.WriteLine($"The largest amount of spaces: {CountTheLargestSpacesAmount(charList)}");
            Console.Write("Char sequence with deleted duplicate spaces: ");
            PrintList(RemoveDuplicateSpaces(charList));
        }

        public static uint CountTheLargestSpacesAmount(IEnumerable<char> charList)
        {
            uint maxSpaces = 0, currentMax = 0;
			
            foreach (var @char in charList)
            {
                if (@char == ' ')
                {
                    currentMax++;
                }
                else
                {
                    if (currentMax > maxSpaces)
                    {
                        maxSpaces = currentMax;	
                    }

                    currentMax = 0;
                }
            }
			
            return maxSpaces;
        }

        public static List<char> StringToList(string @string)
        {
            var newList = new List<char>();
            foreach (var @char in @string)
            {
                newList.Add(@char);
            }

            return newList;
        }

        private static string Input(string hint = "")
        {
            Console.Write(hint);
            return Console.ReadLine();
        }

        private static void PrintList(IEnumerable<char> charList)
        {
            foreach (var @char in charList)
            {
                Console.Write(@char);
            }
        }

        public static List<char> RemoveDuplicateSpaces(List<char> charList)
        {
            for (var i = 0; i < charList?.Count; i++)
            {
                if (char.IsWhiteSpace(charList[i]))
                {
                    while (char.IsWhiteSpace(charList[i + 1]) && i + 1 < charList.Count)
                    {
                        charList.RemoveAt(i + 1);
                    }
                }
            }
			
            return charList;
        }
    }
}
