using System;

namespace sokoban
{
    public class Entity
    {
        protected Position position;

        public virtual string GetObjectInfo()
            {
                return $"[Сущность] Находится на позиции X: {Position.X}, Y: {Position.Y}";
            }

        public Entity()
        {
            position = new Position(0, 0);
        }
        public Entity(int x, int y)
        {
            position = new Position(x, y);
        }

        public Position Position
        {
            get => position;
            set => position = value;
        }
    }
}