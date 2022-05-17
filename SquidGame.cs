using System;

/// <summary>
/// class of Squid Game, game options here
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

    private int playersAliveNum; // alive players
    private int move; // number of current tiles group
    private Tile[][] tiles; // massive of tiles groups and tiles in these groups
    private ITilesFactory factory;
    private bool continueGame;


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
        tiles = factory.GenerateTilesGroups(TilesInGroup, TilesWillActivateNum, TilesGroupsNum, random);

        GameIsOn = true;
        startGameCycle();
    }

    private void startGameCycle()
    {
        while (GameIsOn)
        {
            Console.WriteLine("Remaining players: {0}", playersAliveNum);
            Console.WriteLine("\nCocuma co ti...");
            field.DrawField(playersAliveNum, move, tiles, this);
            doMove();

            if (playersAliveNum == 0)
            {
                Console.WriteLine("No one passed");
                break;
            }
            else if (move == TilesGroupsNum)
            {
                Console.WriteLine("The player number {0} won", playersAliveNum);
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
        continueGame = true;
        tiles[move][tileNum - 1].ActivateTile(this, move, playersAliveNum); // tile will be activated, if it can
    }

    public void ContinueGame(int newMove, int newPlayersAliveNum)
    {
        if (continueGame)
        {
            move = newMove;
            playersAliveNum = newPlayersAliveNum;
            if (playersAliveNum == 0)
            {
                field.DrawField(playersAliveNum, move, tiles, this);
            }
            continueGame = false;
        }
        else // to avoid calling this method, when it isn't needed
        {
            throw new SystemException("Method \"ContinueGame\" can not be called, when game shouldn't continue");
        }
    }
}
