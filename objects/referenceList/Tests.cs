using System.IO;
using System.Linq;
using MyRogueLike.utilities;
using UnityEngine;

namespace MyRogueLike
{
    public class Tests
    {
        private Test _arr;

        public Tests()
        {
            var gameDataFileName = "tests.json";
            string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
            if (File.Exists(filePath))
            {
                string dataAsJson = File.ReadAllText(filePath);


                var r = Test.CreateFromJSON(dataAsJson);
            }
            else
            {
                Debug.LogError("NO JSON FILE FOUND");
            }
        }
    }
}