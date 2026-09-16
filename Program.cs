using System;

namespace PrakticheskayaRabota
{
    // =============================================================
    //  Класс Program - только точка входа в программу.
    //  Передаёт данные между классом ввода/вывода (ConsoleUI)
    //  и классом разбора (PointParser).
    // =============================================================
    class Program
    {
        // Точка входа в программу
        static void Main(string[] args)
        {
            // Вспомогательные объекты
            ConsoleUI userInterface = new ConsoleUI();   // ввод и вывод
            PointParser parser = new PointParser();      // разбор строки

            // Приветствие
            userInterface.ShowHeader();

            // Чтение описания объекта с консоли
            string inputLine = userInterface.ReadDescription();

            // Разбор строки в объект "точка"
            string errorMessage;
            Point2D point = parser.Parse(inputLine, out errorMessage);

            // Вывод результата на экран
            if (point == null)
            {
                userInterface.ShowNotCreated(errorMessage);
            }
            else
            {
                userInterface.ShowCreated(point);
            }

            // Ожидание клавиши перед выходом
            userInterface.WaitToExit();
        }
    }
}