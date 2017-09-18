using System;
using UnityEngine.Windows.Speech;

namespace MyRogueLike
{
    public class Action
    {
        public string Type { get; private set; }
        public Payload Payload { get; private set; }
        public DateTime Time { get; private set; }
        public IBaseObject Target { get; private set; }
        public IBaseObject Instigator { get; private set;  }
        public object Parameters { get; private set; }

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

        public Action(string type, IBaseObject target)
        {
            Time = DateTime.Now;
            Type = type;
            Target = target;
        }

        public Action(string type, IBaseObject target, IBaseObject instigator)
        {
            Time = DateTime.Now;
            Type = type;
            Target = target;
            Instigator = instigator;
        }

        public Action(string type, IBaseObject target, IBaseObject instigator, object parameters)
        {
            Time = DateTime.Now;
            Type = type;
            Target = target;
            Instigator = instigator;
            Parameters = parameters;

        }
    }
}