using System;
using System.Collections.Generic;

namespace play
{

    public class Place
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
            
        
        public Dictionary<(int, int), Item> Items = new Dictionary<(int, int), Item>();

        public Place(int width = 5, int height = 5)
        {
            Width = width;
            Height = height;
        }
    }
}
