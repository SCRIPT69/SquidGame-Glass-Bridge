using System;

/// <summary>
/// The base class of tiles, subsequent generations of tiles should inherit from it
/// </summary>
class Tile
{
    /// <summary>
    /// Will tile activate and do smth or not
    /// </summary>
    public bool WillActivate { get; protected set; }
    /// <summary>
    /// Original tile piclure, that will be shown in console
    /// </summary>
    public string TilePicture { get; protected set; }
    /// <summary>
    /// Tile picture, after it was activated
    /// </summary>
    public string ActivatedTilePic { get; protected set; }
    public Tile(bool willActivate)
    {
        WillActivate = willActivate;
        TilePicture = "|#|";
        ActivatedTilePic = "| |";
    }
    /// <summary>
    /// Tile's action, after it was chosen
    /// </summary>
    /// <param name="gameProperties"></param>
    /// <param name="move"></param>
    /// <param name="playersAliveNum"></param>
    public void ActivateTile(SquidGame gameProperties, int move, int playersAliveNum)
    {
        if (WillActivate)
        {
            TilePicture = ActivatedTilePic;
            onActivated(gameProperties, move, playersAliveNum);
        }
        else
        {
            onNotActivated(gameProperties, move, playersAliveNum);
        }
    }
    /// <summary>
    /// Tile's action, that will kill the player
    /// </summary>
    /// <param name="gameProperties"></param>
    /// <param name="move"></param>
    /// <param name="playersAliveNum"></param>
    protected virtual void onActivated(SquidGame gameProperties, int move, int playersAliveNum)
    {
        Console.WriteLine("\nI wAnNA lIVe. Bdshshss. ААААА");
        Console.WriteLine("\nThe player number {0} fell and died...", playersAliveNum);
        move = 0;
        playersAliveNum--;
        gameProperties.ContinueGame(move, playersAliveNum);
    }
    /// <summary>
    /// Tile's action, when tile do nothing
    /// </summary>
    /// <param name="gameProperties"></param>
    /// <param name="move"></param>
    /// <param name="playersAliveNum"></param>
    protected virtual void onNotActivated(SquidGame gameProperties, int move, int playersAliveNum)
    {
        move++;
        gameProperties.ContinueGame(move, playersAliveNum);
    }
}