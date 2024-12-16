using System;
using System.Linq;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            char WriteFirstLetter(string input)
            {
                if (input.Trim() == string.Empty)
                    throw new ArgumentException(message: "Input string cannot be empty.", input);

                if (input == null)
                    throw new ArgumentNullException(nameof(input), message: "Input string cannot be null.");

                char[] characters = input.ToCharArray();
                return characters.First();

            }

            Console.WriteLine(WriteFirstLetter(" "));
        }


    }
}