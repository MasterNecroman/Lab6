using System;

namespace Task_2
{
    public class MathOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public double Add(double a, double b)
        {
            return a + b;
        }

        public int[] AddArrays(int[] arr1, int[] arr2)
        {
            if (arr1.Length != arr2.Length)
            {
                throw new ArgumentException("Array sizes do not match");
            }

            int[] result = new int[arr1.Length];
            for (int i = 0; i < arr1.Length; i++)
            {
                result[i] = arr1[i] + arr2[i];
            }

            return result;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public int[] SubtractArrays(int[] arr1, int[] arr2)
        {
            if (arr1.Length != arr2.Length)
            {
                throw new ArgumentException("Array sizes do not match");
            }

            int[] result = new int[arr1.Length];
            for (int i = 0; i < arr1.Length; i++)
            {
                result[i] = arr1[i] - arr2[i];
            }

            return result;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public int[] MultiplyArrays(int[] arr1, int[] arr2)
        {
            if (arr1.Length != arr2.Length)
            {
                throw new ArgumentException("Array sizes do not match");
            }

            int[] result = new int[arr1.Length];
            for (int i = 0; i < arr1.Length; i++)
            {
                result[i] = arr1[i] * arr2[i];
            }

            return result;
        }

        public int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed");
            }

            return a / b;
        }

        public double Divide(double a, double b)
        {
            if (b == 0.0)
            {
                throw new DivideByZeroException("Division by zero is not allowed");
            }

            return a / b;
        }

        public int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows1 = matrix1.GetLength(0);
            int cols1 = matrix1.GetLength(1);
            int cols2 = matrix2.GetLength(1);

            if (cols1 != matrix2.GetLength(0))
            {
                throw new ArgumentException("Matrix dimensions do not allow multiplication");
            }

            int[,] result = new int[rows1, cols2];

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < cols1; k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return result;
        }
    }
}