using System;

namespace PrakticheskayaRabota
{

    public class Point2D
    {
        public double X {get; set; }
        public double Y {get; set;}     
        public string Color {get; set; }  
        public bool Flag {get; set;}


        public Point2D(double x, double y, string color, bool flag)
        {
            X = x;
            Y = y;
            Color = color;
            Flag = flag;
        }

        public string GetDescription()
        {
            return ToString();
        }

        public override string ToString()
        {
            return $"Point2D ({X}, {Y}) [Color: {Color}, Flag: {Flag}]";
        }

    }
}