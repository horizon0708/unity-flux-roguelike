﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using MyRogueLike.utilities;
using UnityEngine;

namespace MyRogueLike
{
    public class Units
    {
        //private List<Unit> _arr;
        private Unit[] _arr;
        public Units()
        {
            var gameDataFileName = "units.json";
            string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
            if (File.Exists(filePath))
            {
                string dataAsJson = File.ReadAllText(filePath);
                Debug.Log(dataAsJson);
                _arr = JsonHelper.FromJson<Unit>(dataAsJson);
                Debug.Log(_arr[0].Id);
                Debug.Log(_arr[0].MaxSpeed);
                Debug.Log(_arr[0].Height);
                Debug.Log(_arr[0].Width);
            }
            else
            {
                Debug.LogError("NO JSON FILE FOUND");

            }

            
        }

        public Unit FindWithId(string id)
        {
            return new Unit("player", Vector2.down);
            //return _arr.Find(x => x.Id == id);
        }
    }
}