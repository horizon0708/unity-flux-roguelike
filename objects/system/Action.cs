using System;
using UnityEngine.Windows.Speech;

namespace MyRogueLike
{
    public class Action
    {
        public string Type { get; private set; }
        public Payload Payload { get; private set; }
        public DateTime Time { get; private set; }

        public Action(string type, Payload payload)
        {
            Type = type;
            Payload = payload;
            Time = DateTime.Now;
        }

        public Action(string type)
        {
            Type = type;
            Time = DateTime.Now;
        }
    }
}