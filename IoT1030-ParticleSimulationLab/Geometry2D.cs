using System;
using System.Collections.Generic;
using System.Text;

namespace Psim
{
    namespace Geometry2D
    {
        public class Point
        {
            public double X { get; set; }
            public double Y { get; set; }
            public Point(double x = 0, double y = 0)
            {
                X = x;
                Y = y;
            }

            /// <summary>
            /// Get both the X and Y coordinate from one function call
            /// Returns the X and Y coordinate fo the point
            /// </summary>

            public void GetCoords(out double x, out double y)
            {
                x = X;
                y = Y;
            }
            public void SetCoords(double? x, double? y)
            {
                X = x ?? X;
                Y = y ?? Y;
            }
            public override string ToString() => $"({X}, {Y})";
        }
        public class Vector
        {
            public double DX { get; private set; }
            public double DY { get; private set; }
            public Vector(double dx = 0, double dy = 0)
            {
                Set(dx, dy);
            }

            /// <summary>
            /// Sets the x and y components of the vector
            /// </summary>
            /// <param name="dx"></param>
            /// <param name="dy"></param>
            /// <exception cref="ArgumentOutOfRangeException">Will throw if dx or dy is outside the range [-1, 1]</exception>
            public void Set(double dx, double dy)
            {
                if(dx < -1 || dy < -1 || dx > 1 || dy > 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    DX = dx;
                    DY = dy;
                }
                // if dx or dy <= -1 or >= 1 -> throw exception
            }

            public override string ToString() => $"({DX}, {DY})";
        }
        /// <summary>
        /// An immutable rectangle. The length and width cannot be altered after it is set.
        /// </summary>
        public class Rectangle
        {
            public double Length { get; }
            public double Width { get; }
            public double Area { get; }

            public Rectangle(double length, double width)
            {
                Area = length * width;
                Length = length;
                Width = width;
            }
        }
    }
}
