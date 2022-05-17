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
    private int maxPlayers;
    public int MaxPlayers
    {
        get
        {
            return maxPlayers;
        }
        set
        {
            errors.CheckSettingsError(GameIsOn);
            errors.CheckLessThanNeededError(value, 1, "MaxPlayers");
            maxPlayers = value;
        }
    }
    /// <summary>
    /// The number of tiles groups, that players have to pass to win
    /// </summary>
    private int tilesGroupsNum;
    public int TilesGroupsNum
    {
        get
        {
            return tilesGroupsNum;
        }
        set
        {
            errors.CheckSettingsError(GameIsOn);
            errors.CheckLessThanNeededError(value, 1, "TilesGroupsNum");
            tilesGroupsNum = value;
        }
    }
    /// <summary>
    /// The number of tiles in one group from which the player must choose one
    /// </summary>
    private int tilesInGroup;
    public int TilesInGroup
    {
        get
        {
            return tilesInGroup;
        }
        set
        {
            errors.CheckSettingsError(GameIsOn);
            errors.CheckLessThanNeededError(value, 2, "TilesInGroup");
            tilesInGroup = value;
        }
    }
    /// <summary>
    /// The amount of tiles, that will do smth with player, after he'd chosen it
    /// </summary>
    private int tilesWillActivateNum;
    public int TilesWillActivateNum
    {
        get
        {
            return tilesWillActivateNum;
        }
        set
        {
            errors.CheckSettingsError(GameIsOn);
            errors.CheckLessThanNeededError(value, 1, "TilesWillBreakNum");
            errors.CheckBiggerThanNeededError(value, TilesInGroup - 1, "TilesWillBreakNum");
            tilesWillActivateNum = value;
        }
    }

    // objects, that are needed for the game
    private ConsoleDrawing field;
    private UserInput userInput;
    private SquidGameErrors errors;
    private ITilesFactory factory;

    public SquidGame()
    {
        GameIsOn = false;
        field = new ConsoleDrawing();
        userInput = new UserInput();
        errors = new SquidGameErrors();

        // default settings
        MaxPlayers = 5;
        TilesGroupsNum = 5;
        TilesInGroup = 2;
        TilesWillActivateNum = 1;
    }

    private int playersAliveNum;
    public int PlayersAliveNum // alive players
    {
        get
        {
            return playersAliveNum;
        }
        set
        {
            errors.CheckCanSetNewGameParametres("PlayersAliveNum", setNewGameParameters);
            playersAliveNum = value;
        }
    }
    private int move;
    public int Move // number of current tiles group
    {
        get
        {
            return move;
        }
        set
        {
            errors.CheckCanSetNewGameParametres("Move", setNewGameParameters);
            move = value;
        }
    }
    public Tile[][] Tiles { get; private set; } // massive of tiles groups and tiles in these groups

    private bool setNewGameParameters;


    /// <summary>
    /// Start the game
    /// </summary>
    public void Start()
    {
        //Game setting, and starting the game cycle
        field.DrawLogo();
        Console.WriteLine("\nWho wAtcHed thE sqUiD gAMe WiLl uNdErStaND");

        Random random = new Random();

        playersAliveNum = random.Next(1, MaxPlayers + 1);
        move = 0;

        factory = new TilesGroupsFactory();
        Tiles = factory.GenerateTilesGroups(this);

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
            field.DrawField(this);
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
        int tileNum = userInput.GetUserNum(TilesInGroup);
        field.Clear();
        setNewGameParameters = true;
        Tiles[Move][tileNum - 1].ActivateTile(this); // tile will be activated, if it can
    }

    public void ContinueGame()
    {
        if (setNewGameParameters && PlayersAliveNum == 0)
        {
            field.DrawField(this);
        }
        setNewGameParameters = false;
    }
}
