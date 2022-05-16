using System;

class TilesGroupsFactory : ITilesFactory
{
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
