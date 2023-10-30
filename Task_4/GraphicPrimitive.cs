using System;

namespace task_4
{
    public abstract class GraphicPrimitive
    {
        public int X { get; set; }
        public int Y { get; set; }

        public GraphicPrimitive(int x, int y)
        {
            X = x;
            Y = y;
        }

        public abstract void Draw();

        public virtual void Move(int x, int y)
        {
            X += x;
            Y += y;
        }
    }
}