using System;

namespace PrakticheskayaRabota
{

    class Point2D
    {
        private double _x;       
        private double _y;     
        private string _color;   
        private bool _flag;

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

        public bool Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }

        public Point2D(double x, double y, string color, bool flag = false)
        {
            _x = x;
            _y = y;
            _color = color;
            _flag = flag;
        }

        public string GetDescription()
        {
            string result = "Точка: X = " + _x +
                            ", Y = " + _y +
                            ", цвет = " + _color +
                             ", флаг = " + _flag;
            return result;
        }
    }
}