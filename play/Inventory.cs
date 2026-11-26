using System;
using System.Collections.Generic;

namespace play;

public class Inventory
{
    public List<Item> items = new List<Item>();

    public int Count => items.Count;


    public void AddItem(Item item)
    {
        items.Add(item);
        Console.WriteLine($"В инвентарь добавлен предмет {item.Name}");
    }

    public void ShowInventory()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Инвентарь пустой");
            }
            else
            {
                Console.WriteLine("Содержимое инвентаря:");
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"  {i + 1}. {items[i]}");
                }
            }
        }
}
