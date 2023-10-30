using System;
using System.Collections.Generic;

namespace task_4
{
    public class GraphicsEditor
    {
        private List<GraphicPrimitive> primitives = new List<GraphicPrimitive>();

        public void AddPrimitive(GraphicPrimitive primitive)
        {
            primitives.Add(primitive);
        }

        public void DisplayPrimitives()
        {
            foreach (var primitive in primitives)
            {
                primitive.Draw();
            }
        }
    }
}