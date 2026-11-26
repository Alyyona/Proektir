using System;
namespace sokoban;

public class Map
{
    private readonly List<char[]> matrix;
    private readonly List<Position> boxStarts;

    public int Width { get; private set; }
    public int Height { get; private set; }
    public Position PlayerStart { get; private set; }

    public IReadOnlyList<Position> BoxStarts
    {
        get
        {
            return boxStarts;
        }
    }

    public Map()
    {
        matrix = new List<char[]>();
        boxStarts = new List<Position>();
    }

    // Метод загрузки карты с классическим out-параметром для ошибки
    public bool Load(string text, out string error)
    {
        matrix.Clear();
        boxStarts.Clear();
        Width = 0;
        Height = 0;
        PlayerStart = new Position(0, 0);
        error = "";

        List<string> rows = SplitLines(text);
        if (rows.Count == 0)
        {
            error = "карта пуста";
            return false;
        }

        // Поиск максимальной ширины
        for (int i = 0; i < rows.Count; i++)
        {
            if (rows[i].Length > Width)
            {
                Width = rows[i].Length;
            }
        }
        Height = rows.Count;

        for (int i = 0; i < rows.Count; i++)
        {
            string paddedRow = rows[i].PadRight(Width, ' ');
            matrix.Add(paddedRow.ToCharArray());
        }


        int goals = 0;
        bool foundPlayer = false;

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                char c = matrix[y][x];

                if (c == '#')
                {
                    continue;
                }

                if (c == ' ' || c == '-')
                {
                    matrix[y][x] = ' ';
                }
                else if (c == '.')
                {
                    goals++;
                }
                else if (c == '$')
                {
                    matrix[y][x] = ' ';
                    boxStarts.Add(new Position(x, y));
                }
                else if (c == '*')
                {
                    matrix[y][x] = '.';
                    goals++;
                    boxStarts.Add(new Position(x, y));
                }
                else if (c == '@' || c == '+')
                {
                    if (foundPlayer)
                    {
                        error = "на карте больше одного игрока";
                        return false;
                    }

                    if (c == '+')
                    {
                        matrix[y][x] = '.';
                        goals++;
                    }
                    else
                    {
                        matrix[y][x] = ' ';
                    }

                    PlayerStart = new Position(x, y);
                    foundPlayer = true;
                }
                else
                {
                    error = "неизвестный символ '" + c + "'";
                    return false;
                }
            }
        }

        if (foundPlayer == false)
        {
            error = "на карте нет игрока";
            return false;
        }

        if (goals != boxStarts.Count)
        {
            error = "коробок и целей должно быть поровну";
            return false;
        }

        return true;
    }

    public bool Inside(int x, int y)
    {
        if (x < 0 || y < 0)
        {
            return false;
        }

        if (x >= Width || y >= Height)
        {
            return false;
        }

        return true;
    }

    public bool Inside(Position p)
    {
        return Inside(p.X, p.Y);
    }

    public bool IsWall(int x, int y)
    {
        if (Inside(x, y) == false)
        {
            return true;
        }

        if (matrix[y][x] == '#')
        {
            return true;
        }

        return false;
    }

    public bool IsWall(Position p)
    {
        return IsWall(p.X, p.Y);
    }

    public bool IsGoal(Position p)
    {
        if (Inside(p) == false)
        {
            return false;
        }

        if (matrix[p.Y][p.X] == '.')
        {
            return true;
        }

        return false;
    }

    public char Tile(int x, int y)
    {
        if (Inside(x, y) == false)
        {
            return '#';
        }

        return matrix[y][x];
    }
// neiro help
    private static List<string> SplitLines(string text)
    {
        string normalized = text.Replace("\r\n", "\n").Replace('\r', '\n');
        string[] rawRows = normalized.Split('\n');

        List<string> rows = new List<string>(rawRows);

        while (rows.Count > 0 && string.IsNullOrWhiteSpace(rows[0]))
        {
            rows.RemoveAt(0);
        }

        while (rows.Count > 0 && string.IsNullOrWhiteSpace(rows[rows.Count - 1]))
        {
            rows.RemoveAt(rows.Count - 1);
        }

        return rows;
    }
}