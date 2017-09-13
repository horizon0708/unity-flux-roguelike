using System.Collections.Generic;
using UnityEngine;

namespace MyRogueLike
{
    public class Unit
    {
        public string Id;
        public Vector2 Position;
        public float Radius;
        private float speed;
        public List<string> Debuffs;
        public List<string> Buffs;
        public bool CanCollide = true;

        public Unit(string id, Vector2 position)
        {
            Id = id;
            Position = position;
            Radius = 0.02f;
        }

        public float Height = 1;
        public float Width = 1;

        public float getSpeed()
        {
            // TODO: change speed depending on buffs, debuffs
            return 0.12f;
        }
    }
}