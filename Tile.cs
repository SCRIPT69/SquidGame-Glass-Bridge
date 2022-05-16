using System;

/// <summary>
/// The base class of tiles, subsequent generations of tiles should inherit from it
/// </summary>
class Tile
{
    public bool WillActivate { get; protected set; }
    public string TilePicture { get; protected set; }
    public string ActivatedTilePic { get; protected set; }
    public Tile(bool willActivate)
    {
        WillActivate = willActivate;
        TilePicture = "|#|";
        ActivatedTilePic = "| |";
    }
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
    protected virtual void onActivated(SquidGame gameProperties, int move, int playersAliveNum)
    {
        Console.WriteLine("\nI wAnNA lIVe. Bdshshss. ААААА");
        Console.WriteLine("\nThe player number {0} fell and died...", playersAliveNum);
        move = 0;
        playersAliveNum--;
        gameProperties.ContinueGame(move, playersAliveNum);
    }
    protected virtual void onNotActivated(SquidGame gameProperties, int move, int playersAliveNum)
    {
        move++;
        gameProperties.ContinueGame(move, playersAliveNum);
    }
}