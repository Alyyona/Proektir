using System;
using System.Collections.Generic;

namespace sokoban;

public class Game
{
    private Map map = new Map();
    private Player player = new Player();
    private List<Box> boxes = new List<Box>();

    public Map Map => map;
    public Player Player => player;
    public List<Box> Boxes => boxes;

    public int LevelCount() => Levels.CountLevels();

    public bool LoadLevel(int number)
    {
        if (number < 0 || number >= LevelCount()) 
            return false;

        return LoadText(Levels.LevelText(number), out _);
    }

    public bool LoadText(string text, out string error)
    {
        if (!map.Load(text, out error)) 
            return false;

        PlaceEntities();
        return true;
    }

    private void PlaceEntities()
    {
        player = new Player(map.PlayerStart.X, map.PlayerStart.Y);
        boxes.Clear();
        
        foreach (var start in map.BoxStarts)
        {
            boxes.Add(new Box(start.X, start.Y));
        }
    }

    public int FindBoxIndex(Position p)
    {
        return boxes.FindIndex(b => b.Position.X == p.X && b.Position.Y == p.Y);
    }

    public bool MovePlayer(Direction direction)
    {
        Position next = player.NextPosition(direction);
        if (map.IsWall(next)) 
            return false;

        int boxIndex = FindBoxIndex(next);
        if (boxIndex >= 0)
        {
            Position after = next.Move(direction);
            if (map.IsWall(after) || FindBoxIndex(after) >= 0) 
                return false;

            boxes[boxIndex].Position = after;
        }

        player.Position = next;
        return true;
    }

    public void Restart() => PlaceEntities();

    public bool Solved()
    {
        return boxes.TrueForAll(b => map.IsGoal(b.Position));
    }
}
