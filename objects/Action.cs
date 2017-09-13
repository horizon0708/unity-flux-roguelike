using System;
using UnityEngine.Windows.Speech;

namespace MyRogueLike
{
    public class Action
    {
        public string Type { get; private set; }
        public object Payload { get; private set; }
        public DateTime Time { get; private set; }

        public Action(string type, object payload)
        {
            Type = type;
            Payload = payload;
            Time = DateTime.Now;
        }
    }
}