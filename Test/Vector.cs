using UnityEngine;


namespace JevLogin
{
    public struct Vector
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static explicit operator Vector(double x) => new Vector(x, x);

        public static implicit operator double(Vector x) => x.X;

        public override string ToString() => $"X = {X} Y = {Y}";

        public static Vector operator +(Vector v1, Vector v2)
        {
            Vector res = new Vector
            {
                X = v1.X + v1.X,
                Y = v1.Y + v2.Y
            };
            return res;
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            Vector res = new Vector
            {
                X = v1.X - v2.X,
                Y = v1.Y - v2.Y
            };
            return res;
        }

        public static Vector operator -(Vector v1)
        {
            Vector res = new Vector
            {
                X = -1 * v1.X,
                Y = -1 * v1.Y
            };
            return res;
        }
    }
}
