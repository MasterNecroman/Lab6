using System;

namespace task_4
{
    public class Rectangle : GraphicPrimitive
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int x, int y, int width, int height) : base(x, y)
        {
            Width = width;
            Height = height;
        }

        public override void Draw()
        {
            Console.WriteLine($"Drawing a rectangle at ({X}, {Y}) with width {Width} and height {Height}");
        }
    }
}