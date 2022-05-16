using System;
using System.IO;
using System.Threading;

class ConsoleDrawing
{
    public void DrawField(int playersAliveNum, int move, Tile[][] tiles, SquidGame tilesOptions)
    {
        int tilesGroupsNum = tilesOptions.TilesGroupsNum;
        int tilesInGroup = tilesOptions.TilesInGroup;

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
    public void DrawLogo()
    {
        printStringsFromFile("squid game.txt");
        printStringsFromFile("squidward.txt");
    }
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
