using System;

/// <summary>
/// Class for getting correct user input
/// </summary>
class UserInput
{
    public int GetCorrectNumFromUser(int maxNumber)
    {
        string input = Console.ReadLine();
        bool correctInput = false;
        int chosenNumber = 0;
        while (correctInput == false)
        {
            bool isNumber = false;
            try
            {
                chosenNumber = int.Parse(input);
                isNumber = true;
            }
            catch (FormatException)
            {
            }

            if (!isNumber || chosenNumber < 1 || chosenNumber > maxNumber)
            {
                Console.WriteLine("Choose a tile:");
                input = Console.ReadLine();
            }
            else
            {
                correctInput = true;
            }
        }

        return chosenNumber;
    }
}
