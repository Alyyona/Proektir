using System;

namespace sokoban;

public class Program
{
    public static int Main()
    {
        var game = new Game();
        //var menu = new GameMenu();
        var ui = new UI();
        int levelNumber = 0;

        if (!game.LoadLevel(levelNumber))
        {
            Console.WriteLine("Не удалось загрузить первый уровень");
            return 1;
        }

        ui.Start();
        bool running = true;

        while (running)
        {
            if (game.Solved() && levelNumber + 1 < game.LevelCount())
            {
                levelNumber++;
                game.LoadLevel(levelNumber);
            }

            ui.Draw(game, " 1. Управление: wasd\n 2. Открыть меню: M\n 3. Next level: n\n 4. Отмена шага: p\n 5. Выход: q");
            Key key = ui.ReadKey();

            switch (key)
            {
                case Key.Up:    game.MovePlayer(Direction.Up);    break;
                case Key.Down:  game.MovePlayer(Direction.Down);  break;
                case Key.Left:  game.MovePlayer(Direction.Left);  break;
                case Key.Right: game.MovePlayer(Direction.Right); break;
                case Key.Restart: game.Restart(); break;
                
                // case Key.Menu:
                //     menu.Show(game);
                //     break;

                case Key.Next:
                    if (levelNumber + 1 < game.LevelCount()) 
                        game.LoadLevel(++levelNumber);
                    break;
                    
                case Key.Prev:
                    if (levelNumber > 0) 
                        game.LoadLevel(--levelNumber);
                    break;
                    
                case Key.Quit:
                    running = false;
                    break;
            }
        }

        ui.Stop();
        return 0;
    }

}
