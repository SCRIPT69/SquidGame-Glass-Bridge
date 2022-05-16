using System;

class SquidGameErrors
{
    public void CheckSettingsError(bool gameIsOn)
    {
        if( gameIsOn )
        {
            throw new ArgumentException("settings of the game can not be changed after game was started");
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
}
