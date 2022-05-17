using System;

/// <summary>
/// Class for getting correct user input
/// </summary>
class UserInput
{
    /// <summary>
    /// Getting the correct player's choice
    /// </summary>
    /// <param name="tilesInGroup">the range of numbers that can be chosen by the player</param>
    /// <returns></returns>
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
