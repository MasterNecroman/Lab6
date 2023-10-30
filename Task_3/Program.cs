using System;
using System.Numerics;
using task_3;

namespace QuaternionCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quaternion Calculator");

            Console.WriteLine("Enter values for Quaternion 1:");
            float w1 = ReadFloat("W: ");
            float x1 = ReadFloat("X: ");
            float y1 = ReadFloat("Y: ");
            float z1 = ReadFloat("Z: ");

            Console.WriteLine("Enter values for Quaternion 2:");
            float w2 = ReadFloat("W: ");
            float x2 = ReadFloat("X: ");
            float y2 = ReadFloat("Y: ");
            float z2 = ReadFloat("Z: ");

            task_3.Quaternion q1 = new task_3.Quaternion(w1, x1, y1, z1); 
            task_3.Quaternion q2 = new task_3.Quaternion(w2, x2, y2, z2); 

            Console.WriteLine("Select an operation:");
            Console.WriteLine("1. Addition (+)");
            Console.WriteLine("2. Subtraction (-)");
            Console.WriteLine("3. Multiplication (*)");
            Console.WriteLine("4. Norm of Quaternion 1");
            Console.WriteLine("5. Conjugate of Quaternion 1");
            Console.WriteLine("6. Inverse of Quaternion 1");
            Console.WriteLine("7. Convert Quaternion 1 to Rotation Matrix");
            Console.WriteLine("8. Convert Rotation Matrix to Quaternion 1");
            int choice = ReadInt("Enter your choice: ");

            task_3.Quaternion result = null;

            switch (choice)
            {
                case 1:
                    result = q1 + q2;
                    break;
                case 2:
                    result = q1 - q2;
                    break;
                case 3:
                    result = q1 * q2;
                    break;
                case 4:
                    float norm1 = q1.Norm();
                    Console.WriteLine($"Norm of Quaternion 1: {norm1}");
                    break;
                case 5:
                    result = q1.Conjugate();
                    break;
                case 6:
                    try
                    {
                        result = q1.Inverse();
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case 7:
                    Matrix4x4 rotationMatrix = q1.ToRotationMatrix();
                    Console.WriteLine("Rotation Matrix for Quaternion 1:");
                    Console.WriteLine(rotationMatrix);
                    break;
                case 8:
                    try
                    {
                        result = task_3.Quaternion.FromRotationMatrix(q1.ToRotationMatrix());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            if (result != null)
            {
                Console.WriteLine("Result:");
                Console.WriteLine($"W: {result.W}, X: {result.X}, Y: {result.Y}, Z: {result.Z}");
            }
        }

        static float ReadFloat(string prompt)
        {
            float value;
            while (true)
            {
                Console.Write(prompt);
                if (float.TryParse(Console.ReadLine(), out value))
                    return value;

                Console.WriteLine("Invalid input. Please enter a valid float.");
            }
        }

        static int ReadInt(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value))
                    return value;

                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }
}