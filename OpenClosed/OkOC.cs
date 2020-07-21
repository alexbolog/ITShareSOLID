using System;
using System.Collections.Generic;
using System.Text;

namespace SolidDemo.OpenClosed
{
    internal class OkOpenClosed
    {
        #region Abstract class version
        internal abstract class ShapeAbstr
        {
            public abstract double Area();
        }

        internal class RectangleAbstr : ShapeAbstr
        {
            public double Height { get; set; }
            public double Width { get; set; }
            public override double Area()
            {
                return Height * Width;
            }
        }

        internal class CircleAbstr : ShapeAbstr
        {
            public double Radius { get; set; }
            public override double Area()
            {
                return Radius * Radius * Math.PI;
            }
        }

        #endregion

        #region Interface version

        internal interface IShape
        {
            double Area();
        }

        internal class RectangleIntf : IShape
        {
            public double Height { get; set; }
            public double Width { get; set; }

            public double Area()
            {
                return Height * Width;
            }
        }

        internal class CircleIntf : IShape
        {
            public double Radius { get; set; }

            public double Area()
            {
                return Radius * Radius * Math.PI;
            }
        }
        #endregion

        public class AreaCalculator
        {
            public double TotalArea(ShapeAbstr[] arrShapes)
            {
                double area = 0;
                foreach (var objShape in arrShapes)
                {
                    area += objShape.Area();
                }
                return area;
            }

            public double TotalArea(IShape[] arrShapes)
            {
                double area = 0;
                foreach (var objShape in arrShapes)
                {
                    area += objShape.Area();
                }
                return area;
            }
        }
    }
}
