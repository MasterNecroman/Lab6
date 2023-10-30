using System;
using System.Collections.Generic;

namespace task_4
{
    public class Group : GraphicPrimitive
    {
        private List<GraphicPrimitive> elements = new List<GraphicPrimitive>();

        public Group(int x, int y) : base(x, y) { }

        public void AddElement(GraphicPrimitive element)
        {
            elements.Add(element);
        }

        public override void Draw()
        {
            Console.WriteLine($"Group at ({X}, {Y}) contains:");

            foreach (var element in elements)
            {
                element.Draw();
            }
        }

        public override void Move(int x, int y)
        {
            X += x;
            Y += y;

            foreach (var element in elements)
            {
                element.Move(x, y);
            }
        }
    }
}