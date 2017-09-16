using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using MyRogueLike.utilities;
using UnityEditor;
using UnityEngine;

namespace MyRogueLike
{
    public class Terrains
    {
        public List<Terrain> TerrainArr;

        public Terrains()
        {
            var gameDataFileName = "terrains.json";
            string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
            if (File.Exists(filePath))
            {
                string dataAsJson = File.ReadAllText(filePath);

                TerrainArr = JsonHelper.FromJson<Terrain>(dataAsJson).ToList();
            }
            else
            {
                Debug.LogError("NO JSON FILE FOUND");
            }
        }

        public Terrain FindWithId(string id)
        {
            return TerrainArr.Find(x => x.Id == id);
        }
    }   
}