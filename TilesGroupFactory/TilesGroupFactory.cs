using System;

/// <summary>
/// Abstract factory for creating tiles groups
/// </summary>
class TilesGroupsFactory : ITilesFactory
{
    int extraTilesWillBreak;
    public Tile[][] GenerateTilesGroups(SquidGame tilesOptions)
    {
        int tilesInGroup = tilesOptions.TilesInGroup;
        int tilesWillActivateNum = tilesOptions.TilesWillActivateNum;
        int tilesGroupsNum = tilesOptions.TilesGroupsNum;

        Tile[][] tilesGroups = new Tile[tilesGroupsNum][];
        for (int groupNum = 0; groupNum < tilesGroupsNum; groupNum++)
        {
            tilesGroups[groupNum] = new Tile[tilesInGroup];

            extraTilesWillBreak = tilesWillActivateNum;
            for (int tileNum = 0; tileNum < tilesInGroup; tileNum++)
            {
                Tile tile = new Tile(generateTileBehaviorProperty(tilesOptions, tileNum));
                tilesGroups[groupNum][tileNum] = tile;
            }
        }

        return tilesGroups;
    }
    private bool generateTileBehaviorProperty(SquidGame tilesOptions, int tileNum)
    {
        Random random = new Random();
        int willActivateNum = random.Next(0, 2);
        if (extraTilesWillBreak != 0 && willActivateNum == 1 || tilesOptions.TilesInGroup - tileNum <= extraTilesWillBreak)
        {
            extraTilesWillBreak--;
            return true;
        }
        else
        {
            return false;
        }
    }
}
