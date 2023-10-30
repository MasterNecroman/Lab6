using System;

namespace task_4
{
    public class Circle : GraphicPrimitive
    {
        public int Radius { get; set; }

        public Circle(int x, int y, int radius) : base(x, y)
        {
            Radius = radius;
        }

        public override void Draw()
        {
            Console.WriteLine($"Drawing a circle at ({X}, {Y}) with radius {Radius}");
        }
    }
}