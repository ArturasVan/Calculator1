using System;

namespace Calculator1
{
    class Calculator
    {
        public static double Add(double num1, double num2) // addition mathematical operation's own method
        {
            double result = num1 + num2;
            return result;
        }
        public static double Subtract(double num1, double num2) // subtraction mathematical operation's own method
        {
            double result = num1 - num2;
            return result;
        }
        public static double Multiply(double num1, double num2) // multiplication mathematical operation's own method
        {
            double result = num1 * num2;
            return result;
        }
        
        public static double Divide(double num1, double num2) // division mathematical operation's own method
        {
            double result = num1 / num2;
            return result;
        }

        public static double DoOperation(double cleanNum1, double cleanNum2, string op)
        {
            double result = double.NaN; // Default value is "not-a-number" which we use if an operation, such as division, could result in an error.
            

            // Use a switch statement to do the math.
            switch (op)
            {
                case "a":
                    result = Add(cleanNum1, cleanNum2);
                    break;
                case "s":
                    result = Subtract(cleanNum1, cleanNum2);
                    break;
                case "m":
                    result = Multiply(cleanNum1, cleanNum2);
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    if (cleanNum2 != 0)
                    {
                        result = Divide(cleanNum1, cleanNum2);
                    }
                    break;
                    
                // Ask the user to enter a non-zero divisor.

                // Return text for an incorrect option entry.
                default:
                    break;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Display title as the C# console calculator app.
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                // Declare variables and set to empty.
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // Ask the user to type the first number.
                Console.Write("Type a number, and then press Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput1 = Console.ReadLine();
                }

                // Ask the user to type the second number.
                Console.Write("Type another number, and then press Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput2 = Console.ReadLine();
                }

                // Ask the user to choose an operator.
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.Write("Your option? ");

                string op = Console.ReadLine();

                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                // Keep running program while user to respond for closing.
                Console.Write("Press 'x' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "x") endApp = true;

                Console.WriteLine("\n"); // Linespacing.
            }
            return;
        }
    }
}
