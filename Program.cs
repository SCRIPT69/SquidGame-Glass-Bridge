using System;

class Program
{
    static void Main(string[] args)
    {
        SquidGame game = new SquidGame();
        //game.TilesGroupsNum = 5;
        //game.TilesInGroup = 6;
        //game.TilesWillActivateNum = 5;
        game.Start();

        Console.ReadKey();
    }
}
