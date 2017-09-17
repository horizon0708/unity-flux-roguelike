using System;
using UnityEngine;

namespace MyRogueLike
{
    [Serializable]
    public class Test
    {
        public string name;

        public Test()
        {

        }

        public static Test CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<Test>(jsonString);
        }

    }
}