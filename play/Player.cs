using System;
using System.Collections.Generic;


namespace play{

public class Player
{
    
        public string Name { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public Inventory PlayerInventory { get; set; }

        public Player(string name, int startX = 0, int startY = 0)
        {
            Name = name;
            X = startX;
            Y = startY;
            PlayerInventory = new Inventory();
        }

        public bool Move(string direction, int maxWidth, int maxHeight)
        {

            if (direction == "вверх" && Y > 0) Y--;

            else if (direction == "вниз" && Y < maxHeight - 1) Y++;
            else if (direction == "влево" && X > 0) X--;
            else if (direction == "вправо" && X < maxWidth - 1) X++;
            
            else
            {
                Console.WriteLine("Осторожно, край карты!");
                return false;
            }

            Console.WriteLine($"🚶 {Name} переместился на позицию ({X}, {Y})");
            return true;
        }
    }
}