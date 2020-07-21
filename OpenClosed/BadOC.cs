using System;
using System.Collections.Generic;
using System.Text;

namespace SolidDemo.OpenClosed
{
    internal class BrokenOpenClosed
    {
        internal class Rectangle
        {
            public double Height { get; set; }
            public double Width { get; set; }
        }

        internal class AreaCalculator
        {
            public double TotalArea(Rectangle[] arrRectangles)
            {
                var area = 0d;
                foreach (var objRectangle in arrRectangles)
                {
                    area += objRectangle.Height * objRectangle.Width;
                }
                return area;
            }
        }

        internal class Circle
        {
            public double Radius { get; set; }
        }

        internal class ModifiedAreaCalculator
        {
            public double TotalArea(object[] arrObjects)
            {
                double area = 0;
                Rectangle objRectangle;
                Circle objCircle;
                foreach (var obj in arrObjects)
                {
                    if (obj is Rectangle)
                    {
                        objRectangle = (Rectangle)obj;
                        area += objRectangle.Height * objRectangle.Width;
                    }
                    else
                    {
                        objCircle = (Circle)obj;
                        area += objCircle.Radius * objCircle.Radius * Math.PI;
                    }
                }
                return area;
            }
        }




    }
}
