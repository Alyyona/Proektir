using System;

namespace PrakticheskayaRabota
{
    public class Point3D : Point2D
    {
        public double Z {get ; set; }
        public Point3D( double x, double y, double z, string color, bool flag) 
        : base(x, y, color, flag)
        {
            Z = z;
        }

        public new string GetDescription()
        {
            return ToString();
        }

        public override string ToString() 
        {
             return $"Point3D ({X}, {Y}, {Z}) [Color: {Color}, Flag: {Flag}]";
        }
    }
}

