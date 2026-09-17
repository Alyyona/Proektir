using System;

namespace PrakticheskayaRabota
{

    class ConsoleUI
    {

        public void ShowHeader()
        {
            Console.WriteLine("Практическая работа. Вариант 4.");
            Console.WriteLine("Объект: двумерная точка (координаты X, Y и цвет).");
            Console.WriteLine("Пример строки:  Двумерные точки: 1.5 2.3 red");
            Console.WriteLine();
        }


        public string ReadDescription()
        {
            Console.Write("Введите описание объекта: ");
            string inputLine = Console.ReadLine();
            return inputLine;
        }


        public void ShowCreated(Point2D point)
        {
            Console.WriteLine();
            Console.WriteLine("Объект создан:");
            Console.WriteLine(point.GetDescription());
        }


        public void ShowNotCreated(string errorMessage)
        {
            Console.WriteLine();
            Console.WriteLine(errorMessage);
            Console.WriteLine("Объект не создан. Проверьте правильность ввода.");
        }

        public void WaitToExit()
        {
            Console.WriteLine();
            Console.Write("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}