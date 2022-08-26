using System;

/// <summary>
/// Abstract factory for creating tiles groups
/// </summary>
class TilesGroupsFactory : ITilesFactory
{
    public int TilesInGroup { get; set; }
    public int TilesWillActivateNum { get; set; }
    public int TilesGroupsNum { get; set; }

    protected int _extraTilesWillBreak;

    public TilesGroupsFactory(int tilesInGroup, int tilesWillActivateNum, int tilesGroupsNum)
    {
        TilesInGroup = tilesInGroup;
        TilesWillActivateNum = tilesWillActivateNum;
        TilesGroupsNum = tilesGroupsNum;
    }

    public Tile[][] GenerateTilesGroups()
    {
        Random random = new Random();

        Tile[][] tilesGroups = new Tile[TilesGroupsNum][];
        for (int groupNum = 0; groupNum < TilesGroupsNum; groupNum++)
        {
            tilesGroups[groupNum] = new Tile[TilesInGroup];

            _extraTilesWillBreak = TilesWillActivateNum;
            for (int tileNum = 0; tileNum < TilesInGroup; tileNum++)
            {
                tilesGroups[groupNum][tileNum] = generateTileBehavior(tileNum, random);
            }
        }

        return tilesGroups;
    }
    protected virtual Tile generateTileBehavior(int tileNum, Random random)
    {
        bool willBreak;
        int willActivateNum = random.Next(0, 2);
        if (_extraTilesWillBreak != 0 && willActivateNum == 1 || TilesInGroup - tileNum <= _extraTilesWillBreak)
        {
            _extraTilesWillBreak--;
            willBreak = true;
        }
        else
        {
            willBreak = false;
        }
        return new Tile(willBreak);
    }
}
