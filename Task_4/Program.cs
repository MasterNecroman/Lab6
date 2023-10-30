using System;

namespace task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphicsEditor editor = new GraphicsEditor();

            
            Circle circle = new Circle(10, 10, 5);
            Rectangle rectangle = new Rectangle(20, 20, 8, 6);
            Triangle triangle = new Triangle(30, 30, 7);

            editor.AddPrimitive(circle);
            editor.AddPrimitive(rectangle);
            editor.AddPrimitive(triangle);

            
            Group group = new Group(0, 0);
            group.AddElement(circle);
            group.AddElement(rectangle);

            editor.AddPrimitive(group);

           
            Console.WriteLine("Displaying individual primitives:");
            editor.DisplayPrimitives();

         
            group.Move(5, 5);

            
            Console.WriteLine("\nDisplaying primitives after moving the group:");
            editor.DisplayPrimitives();
        }
    }
}