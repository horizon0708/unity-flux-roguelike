using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using JsonFx.Json;
using UnityEditor;
using UnityEngine;

namespace MyRogueLike
{
    public class Terrains
    {
        public Terrain[] TerrainList;

        public Terrains()
        {
            var gameDataFileName = "terrains.json";
            string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
            if (File.Exists(filePath))
            {
                string dataAsJson = File.ReadAllText(filePath);
                var reader = new JsonReader();
                TerrainList = reader.Read<Terrain[]>(dataAsJson);
            }
            else
            {
                Debug.LogError("NO JSON FILE FOUND");
            }
        }
    }   
}