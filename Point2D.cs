using System;

namespace PrakticheskayaRabota
{
    // =============================================================
    //  Класс Point2D - программный объект "двумерная точка".
    // =============================================================
    class Point2D
    {
        // --- Поля (сохраняют данные объекта) ---
        private double _x;        // координата X
        private double _y;        // координата Y
        private string _color;    // цвет точки

        // --- Свойства (публичный доступ к полям) ---
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

        // --- Конструктор: создаёт точку с заданными значениями ---
        public Point2D(double x, double y, string color)
        {
            _x = x;
            _y = y;
            _color = color;
        }

        // --- Метод: возвращает описание точки в виде строки ---
        public string GetDescription()
        {
            string result = "Точка: X = " + _x +
                            ", Y = " + _y +
                            ", цвет = " + _color;
            return result;
        }
    }
}