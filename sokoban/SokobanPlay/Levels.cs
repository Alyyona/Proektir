using System;
namespace sokoban
{
//neiro help create maps
    public static class Levels
    {
        // Массив строк с картами уровней
        private static readonly string[] LevelData = new string[]
        {
            "#######\n" +
            "#     #\n" +
            "#  $  #\n" +
            "#  .  #\n" +
            "#  @  #\n" +
            "#######\n",

            "#######\n" +
            "#     #\n" +
            "# $#$ #\n" +
            "# . . #\n" +
            "#  @  #\n" +
            "#######\n",

            "#########\n" +
            "#       #\n" +
            "# ##### #\n" +
            "# #   # #\n" +
            "# # $ # #\n" +
            "# #.# # #\n" +
            "# # @ # #\n" +
            "# #   # #\n" +
            "#       #\n" +
            "#########\n",

            "#########\n" +
            "#       #\n" +
            "# $ $ $ #\n" +
            "# . . . #\n" +
            "#   @   #\n" +
            "#########\n",

            "#########\n" +
            "#       #\n" +
            "#  $$$  #\n" +
            "#  ...  #\n" +
            "#  # #  #\n" +
            "#  # #  #\n" +
            "#   @   #\n" +
            "#########\n",

            "########\n" +
            "#      #\n" +
            "#  $ $ #\n" +
            "#  . . #\n" +
            "#   $  #\n" +
            "#  . @ #\n" +
            "########\n",

            "#########\n" +
            "#       #\n" +
            "# $ # $ #\n" +
            "# .   . #\n" +
            "# ##### #\n" +
            "#   @   #\n" +
            "#########\n",

            "##########\n" +
            "#        #\n" +
            "#  $$$$  #\n" +
            "#  ....  #\n" +
            "#   @    #\n" +
            "##########\n"
        };

        // Количество уровней
        public static int CountLevels()
        {
            return LevelData.Length;
        }

        // Текст уровня по номеру с проверкой выхода за границы
        public static string LevelText(int number)
        {
            if (number < 0 || number >= LevelData.Length)
            {
                return "";
            }

            return LevelData[number];
        }
    }
} 