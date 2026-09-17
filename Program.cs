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
            List<Point2D> points = new List<Point2D>();


            userInterface.ShowHeader();

            while(true)
            {
                string inputLine = userInterface.ReadDescription();

                
                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    break;
                }

                string errorMessage;
                Point2D point = parser.Parse(inputLine, out errorMessage);

                if (point == null)
                {
                    userInterface.ShowNotCreated(errorMessage);
                }
                else
                {
                    points.Add(point);              
                    userInterface.ShowCreated(point);
                }
            }
            
            userInterface.WaitToExit();
            
        }
    }
}