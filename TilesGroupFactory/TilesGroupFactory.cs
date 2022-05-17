using System;

/// <summary>
/// Abstract factory for creating tiles groups
/// </summary>
class TilesGroupsFactory : ITilesFactory
{
    /// <summary>
    /// Returning massive of massives with tiles groups with tiles in them
    /// </summary>
    /// <param name="tilesInGroup">The number of tiles in one group from which the player must choose one</param>
    /// <param name="tilesWillActivateNum">The amount of tiles, that will do smth with player, after he'd chosen it</param>
    /// <param name="tilesGroupsNum">The number of tiles groups, that players have to pass to win</param>
    /// <param name="random">The instance of Random class</param>
    /// <returns></returns>
    public Tile[][] GenerateTilesGroups(int tilesInGroup, int tilesWillActivateNum, int tilesGroupsNum, Random random)
    {
        Tile[][] tilesGroups = new Tile[tilesGroupsNum][];
        for (int i = 0; i < tilesGroupsNum; i++)
        {
            tilesGroups[i] = new Tile[tilesInGroup];

            int extraTilesWillBreak = tilesWillActivateNum;
            for (int j = 0; j < tilesInGroup; j++)
            {
                int willActivateNum = random.Next(0, 2);
                bool willActivate;
                if (extraTilesWillBreak != 0 && willActivateNum == 1 || tilesInGroup - j <= extraTilesWillBreak)
                {
                    willActivate = true;
                    extraTilesWillBreak--;
                }
                else
                {
                    willActivate = false;
                }
                Tile tile = new Tile(willActivate);
                tilesGroups[i][j] = tile;
            }
        }

        return tilesGroups;
    }
}
