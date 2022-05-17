using System;
using System.IO;
using System.Threading;

/// <summary>
/// Working with console
/// </summary>
class ConsoleDrawing
{
    /// <summary>
    /// Draw the fild and tiles
    /// </summary>
    /// <param name="playersAliveNum">alive players</param>
    /// <param name="move">number of current tiles group</param>
    /// <param name="tiles">massive of tiles groups and tiles in these groups</param>
    /// <param name="gameOptions">Game options</param>
    public void DrawField(SquidGame gameOptions)
    {
        int playersAliveNum = gameOptions.PlayersAliveNum;
        int move = gameOptions.Move;
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
    /// <summary>
    /// Clear console
    /// </summary>
    public void Clear()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("\n");
        }
    }

    /// <summary>
    /// Draw SquidGame logo in console
    /// </summary>
    public void DrawLogo()
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
