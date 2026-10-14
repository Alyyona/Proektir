using System;

namespace PrakticheskayaRabota
{

    class ConsoleUI
    {

        public void ShowHeader()
        {
            Console.WriteLine("Практическая работа. Вариант 4.");
            Console.WriteLine("Объект: Система геометрических точек ( 2D, 3D и Именнованые).");
            Console.WriteLine("Пример строки:  2D точка: 1.5 2.3 red true");
            Console.WriteLine("Пример строки:  3D точка: 1.5 2.3 6.7 red false");
            Console.WriteLine("Пример строки:  Именнованая точка: MyCat 1.5 2.3 red true");
            Console.WriteLine();
        }


        public string ReadDescription()
        {
            Console.WriteLine("Вводите точки. Пустая строка - выход.");
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