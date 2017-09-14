using UnityEngine;

namespace MyRogueLike
{
    public class Obstacle: IMovable
    {
        public string Id { get; set; }
        public string Slug { get; set; }
        public Vector2 Position { get; set; }
        public float Speed { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public bool CanCollide { get; set; }

        public float GetSpeed()
        {
            return 0.12f;
        }

        public Obstacle(string id, Vector2 pos)
        {
            Id = id;
            Position = pos;
        }
    }
}