using System;
using System.Globalization;
using System.Collections.Generic;

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

            /// Распределение индексов для длины 5
            bool isFirstWordNumber = TryParseToDouble(parts[0], out _);

            if (parts.Length == 5)
            {
                if (isFirstWordNumber)
                {
                    // Если первое число: это 3D точка -> Формат: X Y Z Цвет Флаг
                    colorIndex = 3;
                    flagIndex = 4;
                }
                else
                {
                    // Если текст: это Именованная 2D точка -> Формат: Имя X Y Цвет Флаг
                    xIndex = 1;
                    yIndex = 2;
                    colorIndex = 3;
                    flagIndex = 4;
                }
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

            /// Разбор координаты Z для Point3D (длина 5) ///
            double z = 0;
            if (parts.Length == 5 && isFirstWordNumber)
            {
                if (TryParseToDouble(parts[2], out z) == false)
                {
                    errorMessage = "Ошибка: координата Z должна быть числом.";
                    return null;
                }
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


            /// Возврат нужного типа объекта в зависимости от длины 
            if (parts.Length == 5 && isFirstWordNumber)
            {
                // Возвращаем трехмерную точку 
                return new Point3D(x, y, z, color, flag);
            }
            
            if (parts.Length >= 6 || parts.Length == 5)
            {
                // Возвращаем именованную точку. Имя берем из самого первого элемента (индекс 0)
                string name = parts[0];
                return new NamePoint(name, x, y, color, flag);
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


        /// Обработка набора (массива) строк
        public System.Collections.Generic.List<Point2D> ParseLines(string[] lines, out System.Collections.Generic.List<string> errors)
        {
            var points = new System.Collections.Generic.List<Point2D>();
            errors = new System.Collections.Generic.List<string>();

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string errorMessage;
                Point2D point = Parse(line, out errorMessage);

                if (point != null)
                {
                    points.Add(point);
                }
                else
                {
                    errors.Add($"Строка \"{line}\" => {errorMessage}");
                }
            }
            return points;
        }

    }
}