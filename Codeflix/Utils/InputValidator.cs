using System;

namespace Codeflix.Utils
{
    public static class InputValidator
    {
        public static string ReadRequiredString(string fieldName)
        {
            while (true)
            {
                Console.Write($"Enter {fieldName}: ");
                string input = Console.ReadLine()?.Trim();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }

                Console.WriteLine($"{fieldName} cannot be empty. Please try again.");
            }
        }

        public static int ReadInt(string fieldName, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            while (true)
            {
                Console.Write($"Enter {fieldName}: ");
                string input = Console.ReadLine()?.Trim();

                if (int.TryParse(input, out int value))
                {
                    if (value >= minValue && value <= maxValue)
                    {
                        return value;
                    }

                    Console.WriteLine($"{fieldName} must be between {minValue} and {maxValue}.");
                }
                else
                {
                    Console.WriteLine($"Invalid {fieldName}. Please enter a whole number.");
                }
            }
        }

        public static double ReadDouble(string fieldName, double minValue = double.MinValue, double maxValue = double.MaxValue)
        {
            while (true)
            {
                Console.Write($"Enter {fieldName}: ");
                string input = Console.ReadLine()?.Trim();

                if (double.TryParse(input, out double value))
                {
                    if (value >= minValue && value <= maxValue)
                    {
                        return value;
                    }

                    Console.WriteLine($"{fieldName} must be between {minValue} and {maxValue}.");
                }
                else
                {
                    Console.WriteLine($"Invalid {fieldName}. Please enter a valid number.");
                }
            }
        }

        public static string ReadMediaType()
        {
            while (true)
            {
                Console.Write("Enter type (Movie/TV Show): ");
                string input = Console.ReadLine()?.Trim();

                if (string.Equals(input, "Movie", StringComparison.OrdinalIgnoreCase))
                {
                    return "Movie";
                }

                if (string.Equals(input, "TV Show", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(input, "TVShow", StringComparison.OrdinalIgnoreCase))
                {
                    return "TV Show";
                }

                Console.WriteLine("Invalid type. Please enter either 'Movie' or 'TV Show'.");
            }
        }

        public static string ReadMenuChoice(params string[] validChoices)
        {
            while (true)
            {
                Console.Write("Choose an option: ");
                string input = Console.ReadLine()?.Trim();

                foreach (string choice in validChoices)
                {
                    if (input == choice)
                    {
                        return input;
                    }
                }

                Console.WriteLine("Invalid option. Please try again.");
            }
        }
    }
}