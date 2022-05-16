using System;

interface ITilesFactory
{
    Tile[][] GenerateTilesGroups(int tilesInGroup, int tilesWillBreakNum, int tilesGroupsNum, Random random);
}
