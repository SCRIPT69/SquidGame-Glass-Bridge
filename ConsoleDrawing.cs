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
        int currentMove = gameOptions.NumOfCurrentTilesGroup;
        Tile[][] tiles = gameOptions.Tiles;
        int tilesGroupsNum = gameOptions.TilesGroupsNum;
        int tilesInGroup = gameOptions.TilesInGroup;

        for (int tilesGroupIndex = 0; tilesGroupIndex < tilesGroupsNum; tilesGroupIndex++)
        {
            string field = "";
            for (int tileIndex = 0; tileIndex < tilesInGroup; tileIndex++)
            {
                field += tiles[tilesGroupIndex][tileIndex].TilePicture;
            }

            if (tilesGroupIndex == currentMove && playersAliveNum != 0)
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
