using System;
using System.Collections.Generic;

namespace MyRogueLike
{
    public class RoomGenerator
    {
        // generate an empty room for now.
        void GenerateEmptyRoom()
        {
            var width = 32;
            var height = 18;
            var map = new List<List<object>>();

            for (int i = 0; i < height; i++)
            {
                map.Add(new List<object>(width));
                for (int j = 0; j < width; j++)
                {
                    map[i][j] = new Terrain("t_dirt");
                }
            }
        }
    }
}