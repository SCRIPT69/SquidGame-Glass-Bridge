using System;

/// <summary>
/// Static class of Squid Game, game options here
/// </summary>
static class SquidGame
{
    // after game was started, you cannot change game settings
    public static bool GameIsOn { get; private set; } = false;

    // objects composition, that are needed for the game
    private static SquidGameErrors _errors = new SquidGameErrors();
    private static ConsoleDrawing _field = new ConsoleDrawing();
    private static UserInput _userInput = new UserInput();
    private static ITilesFactory _factory;

    /// <summary>
    /// Maximum amount of players to be chosen randomly
    /// </summary>
    private static int _maxPlayers = 5; // default value
    public static int MaxPlayers
    {
        get
        {
            return _maxPlayers;
        }
        set
        {
            _errors.CheckSettingsError();
            _errors.CheckLessThanNeededError(value, 1, "MaxPlayers");
            _maxPlayers = value;
        }
    }
    /// <summary>
    /// The number of tiles groups, that players have to pass to win
    /// </summary>
    private static int _tilesGroupsNum = 5; // default value
    public static int TilesGroupsNum
    {
        get
        {
            return _tilesGroupsNum;
        }
        set
        {
            _errors.CheckSettingsError();
            _errors.CheckLessThanNeededError(value, 1, "TilesGroupsNum");
            _tilesGroupsNum = value;
        }
    }
    /// <summary>
    /// The number of tiles in one group from which the player must choose one
    /// </summary>
    private static int _tilesInGroup = 2; // default value
    public static int TilesInGroup
    {
        get
        {
            return _tilesInGroup;
        }
        set
        {
            _errors.CheckSettingsError();
            _errors.CheckLessThanNeededError(value, 2, "TilesInGroup");
            _tilesInGroup = value;
        }
    }
    /// <summary>
    /// The amount of tiles, that will do smth with player, after he'd chosen it
    /// </summary>
    private static int _tilesWillActivateNum = 1; // default value
    public static int TilesWillActivateNum
    {
        get
        {
            return _tilesWillActivateNum;
        }
        set
        {
            _errors.CheckSettingsError();
            _errors.CheckLessThanNeededError(value, 1, "TilesWillActivateNum");
            _errors.CheckBiggerThanNeededError(value, TilesInGroup - 1, "TilesWillActivateNum");
            _tilesWillActivateNum = value;
        }
    }

    private static int _playersAliveNum;
    public static int PlayersAliveNum
    {
        get
        {
            return _playersAliveNum;
        }
        set
        {
            _errors.CheckCanChangeGameParametres("PlayersAliveNum");
            _errors.CheckLessThanNeededError(value, 0, "PlayersAliveNum");
            _errors.CheckBiggerThanNeededError(value, MaxPlayers, "TilesWillActivateNum");
            _playersAliveNum = value;
        }
    }
    private static int _numOfCurrentTilesGroup;
    public static int NumOfCurrentTilesGroup
    {
        get
        {
            return _numOfCurrentTilesGroup;
        }
        set
        {
            _errors.CheckCanChangeGameParametres("NumOfCurrentTilesGroup");
            _errors.CheckLessThanNeededError(value, 0, "NumOfCurrentTilesGroup");
            _numOfCurrentTilesGroup = value;
        }
    }
    public static Tile[][] Tiles { get; private set; } // massive of tiles groups and tiles in these groups

    /// <summary>
    /// This property is used for my personal pattern named "Gates"
    /// Some game properties can only be changed when this field equals true, at certain times
    /// </summary>
    public static bool CanChangeGameParameters { get; private set; }


    public static void StartGame()
    {
        if (!GameIsOn)
        {
            //Game setting, and starting the game cycle
            _field.DrawSquidGameLogo();
            Console.WriteLine("\nWho wAtcHed thE sqUiD gAMe WiLl uNdErStaND");

            Random random = new Random();

            _playersAliveNum = random.Next(1, MaxPlayers + 1);
            _numOfCurrentTilesGroup = 0;

            _factory = new TilesGroupsFactory(TilesInGroup, TilesWillActivateNum, TilesGroupsNum);
            Tiles = _factory.GenerateTilesGroups();

            GameIsOn = true;
            startGameCycle();
        }
    }

    private static void startGameCycle()
    {
        while (GameIsOn)
        {
            Console.WriteLine("Remaining players: {0}", PlayersAliveNum);
            Console.WriteLine("\nCocuma co ti...");
            _field.DrawGameField();
            doMove();

            if (PlayersAliveNum == 0)
            {
                Console.WriteLine("No one passed");
                break;
            }
            else if (NumOfCurrentTilesGroup == TilesGroupsNum)
            {
                Console.WriteLine("The player number {0} won", PlayersAliveNum);
                break;
            }
        }
        GameIsOn = false;
    }

    /// <summary>
    /// Tile selection and move logic
    /// </summary>
    private static void doMove()
    {
        Console.WriteLine("Choose a tile to jump:");
        int tileNum = _userInput.GetCorrectNumFromUser(TilesInGroup);
        _field.Clear();

        CanChangeGameParameters = true; // allowing changing game properties by tile
        Tiles[NumOfCurrentTilesGroup][tileNum - 1].ActivateTile(); // tile will be activated, if it can
        continueGame();
    }

    private static void continueGame()
    {
        if (PlayersAliveNum == 0)
        {
            _field.DrawGameField();
        }
        // again we prohibit the change of game properties from other classes, "closing the gates back"
        CanChangeGameParameters = false;
    }
}
