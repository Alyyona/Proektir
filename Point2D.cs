using System;

namespace PrakticheskayaRabota
{

    class Point2D
    {
        private double _x;       
        private double _y;     
        private string _color;   

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public Point2D(double x, double y, string color)
        {
            _x = x;
            _y = y;
            _color = color;
        }

        public string GetDescription()
        {
            string result = "Точка: X = " + _x +
                            ", Y = " + _y +
                            ", цвет = " + _color;
            return result;
        }

    }
}