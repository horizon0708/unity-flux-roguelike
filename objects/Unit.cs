using System.Collections.Generic;
using UnityEngine;

namespace MyRogueLike
{
    public class Unit: IMovable
    {
        public string Id { get; set; }
        public string Slug { get; set; }
        public Vector2 Position { get; set; }
        public float Radius;
        public float Speed { get; set; }
        public List<string> Debuffs;
        public List<string> Buffs;
        public bool CanCollide { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }

        public Unit(string id, Vector2 position)
        {
            Id = id;
            Position = position;
            Radius = 0.02f;
            Height = 1;
            Width = 1;
        }

        

        public float GetSpeed()
        {
            // TODO: change speed depending on buffs, debuffs
            return 0.12f;
        }
    }
}