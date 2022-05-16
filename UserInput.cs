using System;

class UserInput
{
    public int GetUserNum(int tilesInGroup)
    {
        string input = Console.ReadLine();
        bool correctInput = false;
        int chosenTile = 0;
        while (correctInput == false)
        {
            bool isNumber = false;
            try
            {
                chosenTile = int.Parse(input);
                isNumber = true;
            }
            catch (FormatException)
            {
            }

            if (!isNumber || chosenTile < 1 || chosenTile > tilesInGroup)
            {
                Console.WriteLine("Choose a tile:");
                input = Console.ReadLine();
            }
            else
            {
                correctInput = true;
            }
        }

        return chosenTile;
    }
}
