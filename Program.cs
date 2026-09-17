using System;
using System.Drawing;

namespace PrakticheskayaRabota
{

    class Program
    {
        static void Main(string[] args)
        {

            ConsoleUI userInterface = new ConsoleUI();   
            PointParser parser = new PointParser();    


            userInterface.ShowHeader();


            string inputLine = userInterface.ReadDescription();

            
            string errorMessage;
            Point2D point = parser.Parse(inputLine, out errorMessage);

            
            if (point == null)
            {
                userInterface.ShowNotCreated(errorMessage);
            }
            else
            {
                userInterface.ShowCreated(point);
            }

            
            userInterface.WaitToExit();
        }
    }
}