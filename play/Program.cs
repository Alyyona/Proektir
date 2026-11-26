using System;
using System.Collections.Generic;
namespace play
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введите имя персонажа: ");
            string? playerName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(playerName)) playerName = "Герой";

            Player player = new Player(playerName, 4, 4);
            Place place = new Place(50, 50); 
            View view = new View();


            place.Items[(2, 1)] = new Item("Меч", "Простой меч");
            place.Items[(3, 3)] = new Item("Зелье", "Восстанавливает HP");


            while (true)
            {
                view.Draw(place, player);


                var currentPos = (player.X, player.Y);
                if (place.Items.ContainsKey(currentPos))
                {
                    player.PlayerInventory.AddItem(place.Items[currentPos]);
                    place.Items.Remove(currentPos);
                }

              
                string? command = Console.ReadLine();

                if (command == "exit") 
                {
                    break;
                }

                if (command == "w")
                {
                    player.Move("вверх", place.Width, place.Height);
                }
                if (command == "s") 
                {
                    player.Move("вниз", place.Width, place.Height);
                }

                if (command == "a")
                {
                    player.Move("влево", place.Width, place.Height);
                }

                if (command == "d") 
                {
                    player.Move("вправо", place.Width, place.Height);
                }
            }
        }
    }
}
