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
            chosenNumber = convertToNumber(input);

            if (chosenNumber < 1 || chosenNumber > maxNumber)
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
    private int convertToNumber(string value)
    {
        int number = 0;

        try
        {
            number = int.Parse(value);
        }
        catch (FormatException)
        {
        }

        return number;
    }
}
