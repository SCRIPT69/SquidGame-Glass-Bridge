using System;

/// <summary>
/// Game errors when assigning values to game parameters
/// </summary>
class SquidGameErrors
{
    public void CheckSettingsError(bool gameIsOn)
    {
        if( gameIsOn )
        {
            throw new SystemException("settings of the game can not be changed after game was started");
        }
    }
    public void CheckLessThanNeededError(int value, int needed, string name)
    {
        if( value < needed )
        {
            throw new ArgumentException(name + " value can not be less than " + needed);
        }
    }
    public void CheckBiggerThanNeededError(int value, int needed, string name)
    {
        if (value > needed)
        {
            throw new ArgumentException(name + " value can not be bigger than " + needed);
        }
    }

    /// <summary>
    /// Pattern "Gates" error checking. Checking, if game property can be changed at the moment
    /// </summary>
    /// <param name="name">Name of property</param>
    /// <param name="canChangeGameParametres"></param>
    public void CheckCanChangeGameParametres(string name, bool canChangeGameParametres)
    {
        if( !canChangeGameParametres )
        {
            throw new SystemException("You can't change '" + name + "' value, because _canChangeGameParametres is false");
        }
    }
}
