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
    public string TilePicture { get; protected set; }
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
    /// <param name="gameProperties">Game properties</param>
    public void ActivateTile(SquidGame gameProperties)
    {
        if (WillActivate)
        {
            TilePicture = ActivatedTilePic;
            onActivated(gameProperties);
        }
        else
        {
            onNotActivated(gameProperties);
        }
    }
    /// <summary>
    /// Tile's action, that will kill the player
    /// </summary>
    /// <param name="gameProperties">Game properties</param>
    protected virtual void onActivated(SquidGame gameProperties)
    {
        Console.WriteLine("\nI wAnNA lIVe. Bdshshss. ААААА");
        Console.WriteLine("\nThe player number {0} fell and died...", gameProperties.PlayersAliveNum);
        gameProperties.Move = 0;
        gameProperties.PlayersAliveNum--;
        gameProperties.ContinueGame();
    }
    /// <summary>
    /// Tile's action, when tile do nothing
    /// </summary>
    /// <param name="gameProperties">Game properties</param>
    protected virtual void onNotActivated(SquidGame gameProperties)
    {
        gameProperties.Move++;
        gameProperties.ContinueGame();
    }
}