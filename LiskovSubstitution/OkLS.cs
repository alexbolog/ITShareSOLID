using System;
using System.Collections.Generic;
using System.Text;

namespace SolidDemo.LiskovSubstitution
{
    internal class OkLiskovSubstitution
    {
        internal void Demo()
        {
            Shape rectangle = new Rectangle();
            Shape circle = new Circle();
            rectangle.GetShape(); // returns "Rectangle"
            circle.GetShape(); // returns "Circle"
        }

        internal abstract class Shape
        {
            public abstract string GetShape();
        }

        internal class Rectangle : Shape
        {
            public override string GetShape() => "Rectangle";
        }

        internal class Circle : Shape
        {
            public override string GetShape() => "Circle";
        }
    }
}
