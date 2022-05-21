﻿using System;

/// <summary>
/// Abstract factory for creating tiles groups
/// </summary>
class TilesGroupsFactory : ITilesFactory
{
    public Tile[][] GenerateTilesGroups(SquidGame tilesOptons)
    {
        Random random = new Random();
        int tilesInGroup = tilesOptons.TilesInGroup;
        int tilesWillActivateNum = tilesOptons.TilesWillActivateNum;
        int tilesGroupsNum = tilesOptons.TilesGroupsNum;

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
