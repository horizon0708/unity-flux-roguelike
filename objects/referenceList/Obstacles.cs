using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using MyRogueLike.utilities;
using UnityEngine;

namespace MyRogueLike
{
    public class Obstacles
    {
        private List<Obstacle> _arr;

        public Obstacles()
        {
            var gameDataFileName = "obstacles.json";
            string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
            if (File.Exists(filePath))
            {
                string dataAsJson = File.ReadAllText(filePath);

                _arr = JsonHelper.FromJson<Obstacle>(dataAsJson).ToList();
            }
            else
            {
                Debug.LogError("NO JSON FILE FOUND");
            }
        }

        public Obstacle FindWithId(string id)
        {
            return _arr.Find(x => x.Id == id);
        }
    }
}