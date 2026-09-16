using System;
using System.Globalization;

namespace PrakticheskayaRabota
{
    // =============================================================
    //  Класс PointParser - разбор текстовой строки в объект Point2D.
    //  Отвечает только за превращение строки в объект.
    // =============================================================
    class PointParser
    {
        // ---------------------------------------------------------
        //  Разбор строки и создание объекта Point2D.
        //  Возвращает null и текст ошибки, если строка некорректна.
        // ---------------------------------------------------------
        public Point2D Parse(string line, out string errorMessage)
        {
            errorMessage = "";

            // Разбиваем строку на части по одному и более пробелов.
            // Полный вариант:   "Двумерные точки: 3.0 4.0 blue"
            //   часть 0 - "Двумерные", часть 1 - "точки:",
            //   часть 2 - X, часть 3 - Y, часть 4 - цвет.
            // Короткий вариант (без типа): "3.0 4.0 blue"
            //   часть 0 - X, часть 1 - Y, часть 2 - цвет.
            string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Проверка количества частей строки
            if (parts.Length < 3)
            {
                errorMessage = "Ошибка: строка записана не полностью.";
                return null;
            }

            // Номера частей, где лежат X, Y и цвет.
            // По умолчанию считаем, что введён короткий вариант.
            int xIndex = 0;
            int yIndex = 1;
            int colorIndex = 2;

            // Если слов больше 3 - значит, введён полный вариант
            // с названием типа объекта.
            if (parts.Length >= 5)
            {
                xIndex = 2;
                yIndex = 3;
                colorIndex = 4;
            }

            // Преобразуем координаты в дробные числа.
            // Метод понимает и целые (2), и дробные (1.5, 2,5) числа.
            double x;
            double y;
            bool xOk = TryParseToDouble(parts[xIndex], out x);
            bool yOk = TryParseToDouble(parts[yIndex], out y);

            // Проверка: оба числа должны быть распознаны
            if (xOk == false || yOk == false)
            {
                errorMessage = "Ошибка: координаты должны быть числами.";
                return null;
            }

            // Берём цвет из строки
            string color = parts[colorIndex];

            // Проверка цвета: допустимы только red, green, blue
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
            Point2D createdPoint = new Point2D(x, y, color);
            return createdPoint;
        }

        // ---------------------------------------------------------
        //  Преобразование текстовой записи числа в double.
        //  Понимает целые (5) и дробные (1.5 или 2,5) числа.
        //  Возвращает true, если число распознано, и false, если нет.
        // ---------------------------------------------------------
        private bool TryParseToDouble(string text, out double value)
        {
            // Приводим дробное число к единому виду:
            // если введена запятая, заменяем её на точку.
            text = text.Replace(',', '.');

            // Преобразуем текст в дробное число.
            // NumberStyles.Any разрешает знак минуса, точку и т.д.
            bool ok = double.TryParse(
                text,
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out value);

            // Возвращаем true или false в зависимости от результата
            return ok;
        }
    }
}