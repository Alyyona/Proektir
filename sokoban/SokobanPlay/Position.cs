using System;

namespace sokoban
{
    
    public struct Position
    {
        public int X {get; set;}
        public int Y {get; set;}
        public Position(int x, int y)
        {
            X =x;
            Y = y;
        }

        public Position Move(Direction direction)
        {
            return direction switch
            {
                Direction.Up    => new Position(X, Y - 1),
                Direction.Down  => new Position(X, Y + 1),
                Direction.Left  => new Position(X - 1, Y),
                Direction.Right => new Position(X + 1, Y),
                _               => this
            };
        }


    }
    
}