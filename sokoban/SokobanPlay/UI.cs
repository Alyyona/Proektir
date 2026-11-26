using System;
using System.Collections.Generic;
using System.Text;

namespace sokoban;

public class UI
{
    public void Start()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;
        Console.Clear();
    }

    public void Stop()
    {
        Console.CursorVisible = true;
        Console.WriteLine();
    }

    public Key ReadKey()
    {
        while (true)
        {
            var keyInfo = Console.ReadKey(intercept: true);

            if (keyInfo.Modifiers.HasFlag(ConsoleModifiers.Control) && keyInfo.Key == ConsoleKey.C)
                return Key.Quit;

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:    case ConsoleKey.W: return Key.Up;
                case ConsoleKey.DownArrow:  case ConsoleKey.S: return Key.Down;
                case ConsoleKey.LeftArrow:  case ConsoleKey.A: return Key.Left;
                case ConsoleKey.RightArrow: case ConsoleKey.D: return Key.Right;
                case ConsoleKey.R: return Key.Restart;
                case ConsoleKey.N: return Key.Next;
                case ConsoleKey.P: return Key.Prev;
                case ConsoleKey.Q: return Key.Quit;
                case ConsoleKey.M: return Key.Menu;
                default: continue;
            }
        }
    }

    public void Draw(Game game, string message)
    {
        Console.Clear();
        var sb = new StringBuilder();

        for (int y = 0; y < game.Map.Height; y++)
        {
            for (int x = 0; x < game.Map.Width; x++)
            {
                var p = new Position(x, y);
                char c = game.Map.Tile(x, y);

                if (game.Player.Position.X == x && game.Player.Position.Y == y)
                    c = game.Player.Symbol(game.Map.IsGoal(p));

                var box = game.Boxes.Find(b => b.Position.X == x && b.Position.Y == y);
                if (box != null)
                    c = box.Symbol(game.Map.IsGoal(p));

                sb.Append(c);
            }
            sb.AppendLine();
        }

        if (!string.IsNullOrEmpty(message))
            sb.AppendLine($"\n{message}");

        Console.Write(sb.ToString());
    }
}
