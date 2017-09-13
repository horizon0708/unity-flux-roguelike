using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using MyRogueLike.utilities;
using UnityEditor;
using UnityEngine;

namespace MyRogueLike
{
    public class Terrains
    {
        public Terrain[] TerrainArr;

        public Terrains()
        {
            var gameDataFileName = "terrains.json";
            string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
            if (File.Exists(filePath))
            {
                string dataAsJson = File.ReadAllText(filePath);

                TerrainArr = JsonHelper.FromJson<Terrain>(dataAsJson);
                Debug.Log(TerrainArr);
            }
            else
            {
                Debug.LogError("NO JSON FILE FOUND");
            }
        }
    }   
}