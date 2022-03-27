using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string text = default;

            Console.WriteLine("Input 'end' word for exist from app.");

            while (true)
            {
                Console.Write("Input text:  ");
                text = Console.ReadLine();

                if (text == "end")
                {
                    break;
                }

                var firstCharacter = GetFirstCharacter(text);
                Console.WriteLine(firstCharacter);
            }
        }

        private static char GetFirstCharacter(string inputText)
        {
            char firstCharacter = default;

            try
            {
                firstCharacter = inputText[0];
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return firstCharacter;
        }
    }
}