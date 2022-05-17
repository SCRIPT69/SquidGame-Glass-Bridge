using System;

/// <summary>
/// Game errors when assigning values to game parameters
/// </summary>
class SquidGameErrors
{
    /// <summary>
    /// If game has already started, the value cannot be assigned
    /// </summary>
    /// <param name="gameIsOn">GameIsOn value, if game is running</param>
    public void CheckSettingsError(bool gameIsOn)
    {
        if( gameIsOn )
        {
            throw new SystemException("settings of the game can not be changed after game was started");
        }
    }
    /// <summary>
    /// Check if value is less than should be
    /// </summary>
    /// <param name="value">a value, that wanted to be assigned</param>
    /// <param name="needed">the minimum number</param>
    /// <param name="name">name of the field</param>
    public void CheckLessThanNeededError(int value, int needed, string name)
    {
        if( value < needed )
        {
            throw new ArgumentException(name + " value can not be less than " + needed);
        }
    }
    /// <summary>
    /// Check if value is bigger than should be
    /// </summary>
    /// <param name="value">a value, that wanted to be assigned</param>
    /// <param name="needed">the maximum number</param>
    /// <param name="name">name of the field</param>
    public void CheckBiggerThanNeededError(int value, int needed, string name)
    {
        if (value > needed)
        {
            throw new ArgumentException(name + " value can not be bigger than " + needed);
        }
    }
    public void CheckCanSetNewGameParametres(string name, bool setNewGameParameters)
    {
        if( !setNewGameParameters )
        {
            throw new SystemException("You can't change '" + name + "' value, because setNewGameParameters is false");
        }
    }
}
