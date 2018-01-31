using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeTrackerTookit
{
    namespace MathUtil
    {
        // 數學相關 Function
        class MathUtil
        {
            public static float Clamp01(float x)
            {
                return Math.Min(Math.Max(0, x), 1);
            }
        }


        // Vector 2 相關
        class Vector2
        {
            public double X;
            public double Y;

            public Vector2(double x = 0, double y = 0)
            {
                X = x;
                Y = y;
            }

            public static Vector2 operator + (Vector2 a, Vector2 b)
            {
                return new Vector2(a.X + b.X, a.Y + b.Y);
            }

            public static Vector2 operator - (Vector2 a, Vector2 b)
            {
                return new Vector2(a.X - b.X, a.Y - b.Y);
            }

            public static Vector2 operator *(float factor, Vector2 v)
            {
                return new Vector2(factor * v.X, factor * v.Y);
            }

            public static double Distance(Vector2 a, Vector2 b)
            {
                return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
            }
        }
    }
}
