using System;
using System.Numerics;
namespace TrueCalculator;

class Program
{
    static void Main(string[] args)
    {
        const string Menu = """
                            |--------------------------------------|
                            |             Calculator               |
                            |                                      |
                            |   A - Sum                            |
                            |   B - Multiplication                 |
                            |   C - Subtraction                    |
                            |   D - Division                       |
                            |                                      |
                            |   Q - Quit                           |
                            |--------------------------------------|
            """;
        bool isRunning = true;
        string result = "";

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine(Menu);
            Console.WriteLine(result);

            Console.Write("\nChoose an Option: ");
            string option = Console.ReadLine()?.ToUpper();

            switch (option)
            {
                case "A":
                    result = Operation("Sum", Sum);
                    break;

                case "B":
                    result = Operation("Multiplication", Multiplication);
                    break;

                case "C":
                    result = Operation("Subtraction", Subtraction);
                    break;

                case "D":
                    result = Division();
                    break;

                case "Q":
                    isRunning = false;
                    Console.WriteLine("Thank you for using the Calculator. Goodbye!");
                    break;

                default:
                    result = $"Please enter a valid Option";
                    break;
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    static string Division()
    {
        (int numOne, int numTwo) = InputNumbers();
        if (numTwo == 0)
        {
            return $"Division by zero is not allowed.";
        }
        return $"The Result of Division is: {numOne / numTwo}";
    }

    static string Operation(string operationName, Func<int, int, int> operation)
    {
        (int numOne, int numTwo) = InputNumbers();
        int result = operation(numOne, numTwo);
        return $"The Result of {operationName} is: {result}";
    }

    static (int, int) InputNumbers()
    {
        int numOne = readInterger("Enter your First Number: ");
        int numTwo = readInterger("Enter your Second Number: ");
        return (numOne, numTwo);
    }

    static int readInterger(string message)
    {
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                return number;
            }
            Console.WriteLine("Invalid input. Please enter a valid Interger");
        }
    }
    static int Sum(int firstNum, int secondNum) => firstNum + secondNum;
    static int Multiplication(int firstNum, int secondNum) => firstNum * secondNum;
    static int Subtraction(int firstNum, int secondNum) => firstNum - secondNum;

}