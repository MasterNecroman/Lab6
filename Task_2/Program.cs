using System;
using Task_2;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            MathOperations mathOps = new MathOperations();

            while (true)
            {
                Console.WriteLine("Select an operation:");
                Console.WriteLine("1 - Addition");
                Console.WriteLine("2 - Subtraction");
                Console.WriteLine("3 - Multiplication");
                Console.WriteLine("4 - Division");
                Console.WriteLine("5 - Exit");

                if (!int.TryParse(Console.ReadLine(), out int operationChoice))
                {
                    Console.WriteLine("Invalid choice. Please select a valid operation (1 - 5).");
                    continue;
                }

                if (operationChoice == 5)
                {
                    break;
                }

                Console.WriteLine("Select data type:");
                Console.WriteLine("1 - Integers");
                Console.WriteLine("2 - Floating-Point Numbers");
                Console.WriteLine("3 - Arrays of Integers");
                Console.WriteLine("4 - Matrices (2D Arrays)");
                Console.WriteLine("5 - Back");

                if (!int.TryParse(Console.ReadLine(), out int dataTypeChoice))
                {
                    Console.WriteLine("Invalid choice. Please select a valid data type (1 - 5).");
                    continue;
                }

                if (dataTypeChoice == 5)
                {
                    continue;
                }

                if (dataTypeChoice < 1 || dataTypeChoice > 5)
                {
                    Console.WriteLine("Invalid choice. Please select a valid data type (1 - 5).");
                    continue;
                }

               
                switch (operationChoice)
                {
                    case 1: 
                        PerformAddition(mathOps, dataTypeChoice);
                        break;
                    case 2:
                        PerformSubtraction(mathOps, dataTypeChoice);
                        break;
                    case 3: 
                        PerformMultiplication(mathOps, dataTypeChoice);
                        break;
                    case 4: 
                        PerformDivision(mathOps, dataTypeChoice);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid operation (1 - 4).");
                        break;
                }
            }
        }

        static void PerformAddition(MathOperations mathOps, int dataTypeChoice)
        {
            Console.WriteLine("Enter the first number:");
            double num1 = ReadNumber(dataTypeChoice);
            Console.WriteLine("Enter the second number:");
            double num2 = ReadNumber(dataTypeChoice);

            double result = mathOps.Add(num1, num2);
            Console.WriteLine($"Result of addition: {result}");
        }

        static void PerformSubtraction(MathOperations mathOps, int dataTypeChoice)
        {
            Console.WriteLine("Enter the first number:");
            double num1 = ReadNumber(dataTypeChoice);
            Console.WriteLine("Enter the second number:");
            double num2 = ReadNumber(dataTypeChoice);

            double result = mathOps.Subtract(num1, num2);
            Console.WriteLine($"Result of subtraction: {result}");
        }

        static void PerformMultiplication(MathOperations mathOps, int dataTypeChoice)
        {
            if (dataTypeChoice == 4)
            {
                Console.WriteLine("Enter the dimensions of the first matrix (rows columns):");
                int rows1 = ReadInt();
                int cols1 = ReadInt();

                Console.WriteLine("Enter the dimensions of the second matrix (rows columns):");
                int rows2 = ReadInt();
                int cols2 = ReadInt();

                int[,] matrix1 = ReadMatrix(rows1, cols1);
                int[,] matrix2 = ReadMatrix(rows2, cols2);

                if (cols1 != rows2)
                {
                    Console.WriteLine("Matrix dimensions do not allow multiplication.");
                }
                else
                {
                    int[,] resultMatrix = mathOps.MultiplyMatrices(matrix1, matrix2);
                    Console.WriteLine("Result of matrix multiplication:");
                    PrintMatrix(resultMatrix);
                }
            }
            else
            {
                Console.WriteLine("Enter the first number:");
                double num1 = ReadNumber(dataTypeChoice);
                Console.WriteLine("Enter the second number:");
                double num2 = ReadNumber(dataTypeChoice);

                double result = mathOps.Multiply(num1, num2);
                Console.WriteLine($"Result of multiplication: {result}");
            }
        }

        static void PerformDivision(MathOperations mathOps, int dataTypeChoice)
        {
            Console.WriteLine("Enter the first number:");
            double num1 = ReadNumber(dataTypeChoice);

            while (true)
            {
                Console.WriteLine("Enter the second number (non-zero):");
                double num2 = ReadNumber(dataTypeChoice);

                if (num2 == 0)
                {
                    Console.WriteLine("Division by zero is not allowed. Please enter a non-zero second number.");
                }
                else
                {
                    double result = mathOps.Divide(num1, num2);
                    Console.WriteLine($"Result of division: {result}");
                    break;
                }
            }
        }

        static double ReadNumber(int dataTypeChoice)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (dataTypeChoice == 1 && int.TryParse(input, out int intValue))
                {
                    return intValue;
                }
                else if (dataTypeChoice == 2 && double.TryParse(input, out double doubleValue))
                {
                    return doubleValue;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        static int ReadInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int intValue))
                {
                    return intValue;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }
        }

        static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    while (true)
                    {
                        Console.Write($"Enter the element at row {i + 1}, column {j + 1}: ");
                        if (int.TryParse(Console.ReadLine(), out int element))
                        {
                            matrix[i, j] = element;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                        }
                    }
                }
            }

            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}