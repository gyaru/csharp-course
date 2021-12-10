using System;
using System.Text.RegularExpressions;
using static System.Console;

namespace calculator
{
    internal static class Program
    {
        private static void GetInput(bool clearBefore)
        {
            if (clearBefore) Clear();
            WriteLine("Please input what you want to calculate:");
            string input = ReadLine();
            LetsDoSomeMath(input);
        }
        private static void AskUser()
        {
            WriteLine("Do you want to do another one?");
            WriteLine("Press <Enter> to continue or any other key to quit.");
            if (ReadKey().Key == ConsoleKey.Enter)
            {
                GetInput(true);

            }
            WriteLine("Bye!");
            Environment.Exit(0);
        }
        private static int Multiplication(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }
        private static int Division(int firstNumber, int secondNumber)
        {
            try
            {
                int value = firstNumber / secondNumber;
                return value;
            }
            catch (DivideByZeroException)
            {
                WriteLine("You tried to divide by zero, oh no!");
                AskUser();
            }
            return 0;
        }
        private static int Subtraction(int firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }
        private static int Addition(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
        private static bool AllowedOperators(string input)
        {
            char[] allowed = { '+', '/', '-', '*', 'x' };
            return input.IndexOfAny(allowed) > -1;
        }
        private static void ErrorPrint()
        {
            WriteLine("Error, did you input it properly? you need to input 2 numbers and an operator.");
            WriteLine("Examples:");
            WriteLine("3 + 3, 4/5, 3 * 4");
            Main();
        }
        private static void LetsDoSomeMath(string input)
        {
            const string regexPattern = @"(\d+)\s*([\+\*\/\+\-])\s*(\d+)";
            Match matched = Regex.Match(input, regexPattern);
            // simple error check
            if (matched.Groups.Count < 4 | !int.TryParse(matched.Groups[1].Value, out int firstNumber) | !int.TryParse(matched.Groups[1].Value, out int secondNumber) | !AllowedOperators(matched.Groups[2].Value))
            {
                ErrorPrint();
            }
            WriteLine($"DEBUG: {matched.Groups[1].Value}     {matched.Groups[2].Value}        {matched.Groups[3].Value}");
            string operatorToUse = matched.Groups[2].Value;
            int result = operatorToUse switch
            {
                "/" => Division(firstNumber, secondNumber),
                "+" => Addition(firstNumber, secondNumber),
                "-" => Subtraction(firstNumber, secondNumber),
                "*" => Multiplication(firstNumber, secondNumber),
                "x" => Multiplication(firstNumber, secondNumber),
                _ => 0
            };
            WriteLine($"Result: {result}");
            AskUser();
        }

        private static void Main()
        {
            WriteLine("Simple Calculator");
            WriteLine("Addition, Subtraction, Division and Multiplication are the only supported operations currently.");
            GetInput(false);
        }
    }
}