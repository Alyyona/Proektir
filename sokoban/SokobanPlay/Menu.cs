using System;
using System.Collections.Generic;
using System.Net.ServerSentEvents;

namespace sokoban;

public class MenuItem
{
    private string? Description;
    public void Print()
    {
        Console.WriteLine(Description);
    }
}

public class Menu
{
    private List<MenuItem> items;
    Menu()
    {
        items = new List<MenuItem> ();
    }

    public void Add(MenuItem item)
    {
        items.Add(item);
    }
    public void PrintAllItems(MenuItem item)
    {
        items.PrintAllItems(item);
    }
}

// public class ShowObjects : Menu
// {
//     public ShowObjects() : base("Вывести информацию о всех объектах на карте") { }

//     public override void Do(Game game)
//     {
//         base.Do(game); 
        
//         Console.WriteLine("\n---  Список игровых объектов  ---");
        
        
//         if (game.Player != null)
//             Console.WriteLine(game.Player.GetObjectInfo());

        
//         foreach (var box in game.Boxes)
//         {
//             Console.WriteLine(box.GetObjectInfo());
//         }
//         Console.WriteLine("---------------------------------------------");
//     }
// }

