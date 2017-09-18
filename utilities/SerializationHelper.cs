using System.Collections.Generic;
using System.IO;
using System.Linq;
using MyRogueLike.utilities;
using UnityEngine;

namespace MyRogueLike
{
    public static class SerializationHelper
    {
        public static List<T> Deserialize<T>(string dataFileName)
        {
            string filePath = Path.Combine(Application.streamingAssetsPath, dataFileName);
            if (File.Exists(filePath))
            {
                string dataAsJson = File.ReadAllText(filePath);

                return JsonHelper.FromJson<T>(dataAsJson).ToList();
            }
            Debug.LogError("NO JSON FILE FOUND");
            return new List<T>();
        }
    }
}