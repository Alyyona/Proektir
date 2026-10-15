using System;
using System.Collections.Generic;
using System.Globalization;

namespace PrakticheskayaRabota
{
    class PointParser
    {
        private const string ErrorIncomplete = "Ошибка: строка записана не полностью.";
        private const string ErrorCoordinates = "Ошибка: координаты должны быть числами.";
        private const string ErrorZCoordinate = "Ошибка: координата Z должна быть числом.";
        private const string ErrorColor = "Ошибка: цвет должен быть red, green или blue.";
        private const string ErrorFlag = "Ошибка: флаг должен быть true или false.";

        public Point2D Parse(string line, out string errorMessage)
        {
            errorMessage = "";
            string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 3)
            {
                errorMessage = ErrorIncomplete;
                return null;
            }

            // 1. Определение формата строки (3D или Именованная)
            bool isFirstWordNumber = TryParseToDouble(parts[0], out _);
            bool is3D = parts.Length == 5 && isFirstWordNumber;

            // 2. Распределение индексов 
            int xIndex = 0;
            int yIndex = 1;
            int colorIndex = 2;
            int flagIndex = parts.Length == 4 ? 3 : -1;

            if (parts.Length == 5)
            {
                if (isFirstWordNumber)
                {
                    colorIndex = 3;
                    flagIndex = 4;
                }
                else
                {
                    xIndex = 1;
                    yIndex = 2;
                    colorIndex = 3;
                    flagIndex = 4;
                }
            }
            else if (parts.Length >= 6)
            {
                xIndex = 2;
                yIndex = 3;
                colorIndex = 4;
                flagIndex = 5;
            }

            // 3. Разбор и валидация базовых координат X и Y
            if (!TryParseToDouble(parts[xIndex], out double x) || !TryParseToDouble(parts[yIndex], out double y))
            {
                errorMessage = ErrorCoordinates;
                return null;
            }

            // 4. Разбор координаты Z для Point3D
            double z = 0;
            if (is3D)
            {
                if (!TryParseToDouble(parts[2], out z))
                {
                    errorMessage = ErrorZCoordinate;
                    return null;
                }
            }

            // 5. Разбор и валидация цвета
            string color = parts[colorIndex];
            if (color != "red" && color != "green" && color != "blue")
            {
                errorMessage = ErrorColor;
                return null;
            }

            // 6. Разбор и валидация логического флага
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
                    errorMessage = ErrorFlag;
                    return null;
                }
            }

            // 7. Возврат нужного типа объекта 
            if (is3D)
            {
                return new Point3D(x, y, z, color, flag);
            }

            if (parts.Length >= 5)
            {
                string name = parts[0];
                return new NamePoint(name, x, y, color, flag);
            }

            return new Point2D(x, y, color, flag);
        }

        public List<Point2D> ParseLines(string[] lines, out List<string> errors)
        {
            var points = new List<Point2D>();
            errors = new List<string>();

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                Point2D point = Parse(line, out string errorMessage);
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

        private bool TryParseToDouble(string text, out double value)
        {
            text = text.Replace(',', '.');
            return double.TryParse(
                text,
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out value);
        }
    }
}
