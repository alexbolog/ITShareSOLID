using System;
using System.Collections.Generic;
using System.Text;

namespace SolidDemo.LiskovSubstitution
{
    internal class BadLiskovSubstitution
    {
        internal void Demo()
        {
            Rectangle rectangle = new Circle();
            rectangle.GetShape(); // returns "Circle"
        }

        internal class Rectangle
        {
            public virtual string GetShape() => "Rectangle";
        }

        internal class Circle : Rectangle
        {
            public override string GetShape() => "Circle";
        }
    }
}
