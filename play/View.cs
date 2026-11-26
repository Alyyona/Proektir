using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace play;

public class View
{
    private double vision = 5.0;
    public void Draw(Place place, Player player)
    {
        
        Console.Clear();
        Console.WriteLine("--- КАРТА ---");
        

        for (int y = 0; y < place.Height; y++)
        {
            for (int x = 0; x < place.Width; x++)
            
            {   // Вычисление с помощью пифагора расстояние
                double interval = Math.Pow(x - player.X, 2) + Math.Pow(y - player.Y, 2);

                if (interval <=vision)
                {
                    if (x == player.X && y == player.Y) 
                    {
                        Console.Write("🧍 ");
                    }
                    else if (place.Items.ContainsKey((x, y))) 
                    {
                        Console.Write("🎁 ");
                    }
                    else 
                    {
                        Console.Write(".  ");
                    }
                }
            }

            Console.WriteLine();
        }
        Console.WriteLine($" В инвентаре предметов: {player.PlayerInventory.Count}");
        Console.Write("\nКуда идти (w, a, s, d) или exit: ");
        
    }
}
