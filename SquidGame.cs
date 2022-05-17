using System;

/// <summary>
/// Class of Squid Game, game options here
/// </summary>
class SquidGame
{
    /// <summary>
    /// Is the game running
    /// </summary>
    public bool GameIsOn { get; set; } // after game was started, you cannot change game settings

    /// <summary>
    /// Maximum amount of players to be chosen randomly
    /// </summary>
    private int _maxPlayers;
    public int MaxPlayers
    {
        get
        {
            return _maxPlayers;
        }
        set
        {
            _errors.CheckSettingsError(GameIsOn);
            _errors.CheckLessThanNeededError(value, 1, "MaxPlayers");
            _maxPlayers = value;
        }
    }
    /// <summary>
    /// The number of tiles groups, that players have to pass to win
    /// </summary>
    private int _tilesGroupsNum;
    public int TilesGroupsNum
    {
        get
        {
            return _tilesGroupsNum;
        }
        set
        {
            _errors.CheckSettingsError(GameIsOn);
            _errors.CheckLessThanNeededError(value, 1, "TilesGroupsNum");
            _tilesGroupsNum = value;
        }
    }
    /// <summary>
    /// The number of tiles in one group from which the player must choose one
    /// </summary>
    private int _tilesInGroup;
    public int TilesInGroup
    {
        get
        {
            return _tilesInGroup;
        }
        set
        {
            _errors.CheckSettingsError(GameIsOn);
            _errors.CheckLessThanNeededError(value, 2, "TilesInGroup");
            _tilesInGroup = value;
        }
    }
    /// <summary>
    /// The amount of tiles, that will do smth with player, after he'd chosen it
    /// </summary>
    private int _tilesWillActivateNum;
    public int TilesWillActivateNum
    {
        get
        {
            return _tilesWillActivateNum;
        }
        set
        {
            _errors.CheckSettingsError(GameIsOn);
            _errors.CheckLessThanNeededError(value, 1, "TilesWillBreakNum");
            _errors.CheckBiggerThanNeededError(value, TilesInGroup - 1, "TilesWillBreakNum");
            _tilesWillActivateNum = value;
        }
    }

    // objects, that are needed for the game
    private ConsoleDrawing _field;
    private UserInput _userInput;
    private SquidGameErrors _errors;
    private ITilesFactory _factory;

    public SquidGame()
    {
        GameIsOn = false;
        _field = new ConsoleDrawing();
        _userInput = new UserInput();
        _errors = new SquidGameErrors();

        // default settings
        MaxPlayers = 5;
        TilesGroupsNum = 5;
        TilesInGroup = 2;
        TilesWillActivateNum = 1;
    }

    private int _playersAliveNum;
    public int PlayersAliveNum // alive players
    {
        get
        {
            return _playersAliveNum;
        }
        set
        {
            _errors.CheckCanSetNewGameParametres("PlayersAliveNum", _setNewGameParameters);
            _playersAliveNum = value;
        }
    }
    private int _move;
    public int Move // number of current tiles group
    {
        get
        {
            return _move;
        }
        set
        {
            _errors.CheckCanSetNewGameParametres("Move", _setNewGameParameters);
            _move = value;
        }
    }
    public Tile[][] Tiles { get; private set; } // massive of tiles groups and tiles in these groups

    private bool _setNewGameParameters;


    /// <summary>
    /// Start the game
    /// </summary>
    public void Start()
    {
        //Game setting, and starting the game cycle
        _field.DrawLogo();
        Console.WriteLine("\nWho wAtcHed thE sqUiD gAMe WiLl uNdErStaND");

        Random random = new Random();

        _playersAliveNum = random.Next(1, MaxPlayers + 1);
        _move = 0;

        _factory = new TilesGroupsFactory();
        Tiles = _factory.GenerateTilesGroups(this);

        GameIsOn = true;
        startGameCycle();
    }

    /// <summary>
    /// Start the game cycle
    /// </summary>
    private void startGameCycle()
    {
        while (GameIsOn)
        {
            Console.WriteLine("Remaining players: {0}", PlayersAliveNum);
            Console.WriteLine("\nCocuma co ti...");
            _field.DrawField(this);
            doMove();

            if (PlayersAliveNum == 0)
            {
                Console.WriteLine("No one passed");
                break;
            }
            else if (Move == TilesGroupsNum)
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
    private void doMove()
    {
        Console.WriteLine("Choose a tile to jump:");
        int tileNum = _userInput.GetUserNum(TilesInGroup);
        _field.Clear();
        _setNewGameParameters = true;
        Tiles[Move][tileNum - 1].ActivateTile(this); // tile will be activated, if it can
    }

    public void ContinueGame()
    {
        if (_setNewGameParameters && PlayersAliveNum == 0)
        {
            _field.DrawField(this);
        }
        _setNewGameParameters = false;
    }
}
