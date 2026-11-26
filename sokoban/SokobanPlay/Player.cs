using System;
namespace sokoban
{
    public class Player : Entity

    {
        public override string GetObjectInfo()
            {
                return $"[Игрок] Управляет персонажем. Персонаж находиться на X: {Position.X}, Y: {Position.Y}";
            }


        public Player() : base (){}
        public Player(int x, int y) : base(x, y){}

        public Position NextPosition(Direction direction) => Position.Move(direction);
        public char Symbol(bool onGoal) => onGoal ? '+' : '@'; // + игрок  на целевой точке, иначе @

    }
}