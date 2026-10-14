using System;

namespace PrakticheskayaRabota
{
    public class Point3D : Point2D
    {
        public double Z {get ; }
        public Point3D( double x, double y, double z, string color, bool flag) : base(x, y, color, flag)
        {
            Z = z;
        }

        public override string ToString() => $"Point3D ({X}, {Y}, {Z})";
    }
}

