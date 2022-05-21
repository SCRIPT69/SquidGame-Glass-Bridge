using System;
using System.IO;
using System.Threading;

/// <summary>
/// Working with console
/// </summary>
class ConsoleDrawing
{
    public void DrawGameField(SquidGame gameOptions)
    {
        int playersAliveNum = gameOptions.PlayersAliveNum;
        int move = gameOptions.NumOfCurrentTilesGroup;
        Tile[][] tiles = gameOptions.Tiles;
        int tilesGroupsNum = gameOptions.TilesGroupsNum;
        int tilesInGroup = gameOptions.TilesInGroup;

        for (int i = 0; i < tilesGroupsNum; i++)
        {
            string field = "";
            for (int j = 0; j < tilesInGroup; j++)
            {
                field += tiles[i][j].TilePicture;
            }

            if (i == move && playersAliveNum != 0)
            {
                field += " <";
            }
            Console.WriteLine("\n" + field);
        }
        Console.WriteLine(new string('-', tilesInGroup * 3));
    }

    public void Clear()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("\n");
        }
    }

    public void DrawSquidGameLogo()
    {
        printStringsFromFile("squid game.txt");
        printStringsFromFile("squidward.txt");
    }
    /// <summary>
    /// Write every string from the file to console, drawing the images
    /// </summary>
    /// <param name="fileName">name and directory of the file</param>
    private void printStringsFromFile(string fileName)
    {
        Console.WriteLine("\n");
        string[] fileText = File.ReadAllLines(fileName);
        foreach (string str in fileText)
        {
            Thread.Sleep(15);
            Console.WriteLine(str);
        }
    }
}
