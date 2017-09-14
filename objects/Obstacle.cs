using UnityEngine;

namespace MyRogueLike
{
    public class Obstacle: IMovable
    {
        public string Id { get; set; }
        public string Slug { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 PreviousPosition { get; set; }
        public float Speed { get; set; }
        public float XSpeed { get; set; }
        public float YSpeed { get; set; }
        public float Acceleration { get; set; }
        public float XAcceleration { get; set; }
        public float YAcceleration { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public bool CanCollide { get; set; }
        public float GetYSpeed()
        {
            throw new System.NotImplementedException();
        }

        public bool IsMoving { get; set; }
        public bool IsFalling { get; set; }
        public bool IsJumping { get; set; }

        public float GetSpeed()
        {
            return 0.12f;
        }

        public float GetXSpeed()
        {
            throw new System.NotImplementedException();
        }

        public void ChangePosition(Vector2 newPos)
        {
            PreviousPosition = Position;
            Position = newPos;
        }

        public Obstacle(string id, Vector2 pos)
        {
            Id = id;
            Position = pos;
            PreviousPosition = pos;
        }
    }
}