using System;
using System.Globalization;

namespace PrakticheskayaRabota
{

    class PointParser
    {
        public Point2D Parse(string line, out string errorMessage)
        {
            errorMessage = "";

            string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 4)
            {
                errorMessage = "Ошибка: строка записана не полностью.";
                return null;
            }


            int xIndex = 0;
            int yIndex = 1;
            int colorIndex = 2;

            if (parts.Length >= 6)
            {
                xIndex = 2;
                yIndex = 3;
                colorIndex = 4;
            }


            double x;
            double y;
            bool xOk = TryParseToDouble(parts[xIndex], out x);
            bool yOk = TryParseToDouble(parts[yIndex], out y);

            if (xOk == false || yOk == false)
            {
                errorMessage = "Ошибка: координаты должны быть числами.";
                return null;
            }


            string color = parts[colorIndex];

            bool colorOk = false;
            if (color == "red" || color == "green" || color == "blue")
            {
                colorOk = true;
            }

            if (colorOk == false)
            {
                errorMessage = "Ошибка: цвет должен быть red, green или blue.";
                return null;
            }

            // Создаём и возвращаем объект "точка"
            Point2D createdPoint = new Point2D(x, y, color, false);
            return createdPoint;
        }


        private bool TryParseToDouble(string text, out double value)
        {
            
            text = text.Replace(',', '.');

            bool ok = double.TryParse(
                text,
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out value);

            return ok;
        }
    }
}