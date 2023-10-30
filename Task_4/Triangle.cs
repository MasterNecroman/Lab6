using System;

namespace task_4
{
    public class Triangle : GraphicPrimitive
    {
        public int SideLength { get; set; }

        public Triangle(int x, int y, int sideLength) : base(x, y)
        {
            SideLength = sideLength;
        }

        public override void Draw()
        {
            Console.WriteLine($"Drawing a triangle at ({X}, {Y}) with side length {SideLength}");
        }
    }
}