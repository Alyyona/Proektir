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

            if (parts.Length < 3)
            {
                errorMessage = "Ошибка: строка записана не полностью.";
                return null;
            }


            int xIndex = 0;
            int yIndex = 1;
            int colorIndex = 2;
            int flagIndex = -1;   

            if (parts.Length == 4)
            {
                flagIndex = 3;
            }

            if (parts.Length == 5)
            {
                xIndex = 2;
                yIndex = 3;
                colorIndex = 4;
            }

            if (parts.Length >= 6)
            {
                xIndex = 2;
                yIndex = 3;
                colorIndex = 4;
                flagIndex = 5;
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

            // Разбор флага, если он задан в строке
            bool flag = false;
            if (flagIndex != -1)
            {
                string flagText = parts[flagIndex];

                if (flagText == "true" || flagText == "1")
                {
                    flag = true;
                }
                else if (flagText == "false" || flagText == "0")
                {
                    flag = false;
                }
                else
                {
                    errorMessage = "Ошибка: флаг должен быть true или false.";
                    return null;
                }
            }

            Point2D createdPoint = new Point2D(x, y, color, flag);
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