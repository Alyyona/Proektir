using System;

namespace sokoban
{
    public class Box : Entity
    {

        public override string GetObjectInfo()
            {
                return $"[Бокс] Коробочка. Коробочка находиться на X: {Position.X}, Y: {Position.Y}";
            }

        public Box() :base(){}
        public Box(int x, int y) : base(x, y){}
        public char Symbol(bool onGoal) => onGoal ? '*' : '$'; // * - коробка на цели, иначе $

    }
}