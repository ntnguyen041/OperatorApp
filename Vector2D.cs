namespace OperatorApp
{
    public class Vector2D
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Vector2D() : this(0, 0) { }
        public Vector2D(double x, double y) { X = x; Y = y; }

        // Do dai vector (Euclidean norm)
        public double DoDai => Math.Sqrt(X * X + Y * Y);

        public static Vector2D operator +(Vector2D a, Vector2D b)
            => new Vector2D(a.X + b.X, a.Y + b.Y);

        public static Vector2D operator -(Vector2D a, Vector2D b)
            => new Vector2D(a.X - b.X, a.Y - b.Y);

        // Nhan scalar: Vector2D * double
        public static Vector2D operator *(Vector2D v, double k)
            => new Vector2D(v.X * k, v.Y * k);

        // Nhan scalar theo chieu nguoc: double * Vector2D (tinh giao hoan)
        public static Vector2D operator *(double k, Vector2D v)
            => v * k;

        // Unary minus: doi chieu vector
        public static Vector2D operator -(Vector2D v)
            => new Vector2D(-v.X, -v.Y);

        public override string ToString()
            => $"({X:F2}, {Y:F2})";

        public static bool operator ==(Vector2D a, Vector2D b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (a is null || b is null)
                return false;
            return a.X == b.X && a.Y == b.Y ;
        }
        public static bool operator !=(Vector2D a, Vector2D b)
            => !(a==b);
        public static double operator *(Vector2D a, Vector2D b)
            =>  a.X * b.X + a.Y * b.Y;
        public static implicit operator(double x, double y)(Vector2D v)
            => (v.X,v.Y);

    }

}
