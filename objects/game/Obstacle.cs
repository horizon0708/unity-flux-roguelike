using UnityEngine;

namespace MyRogueLike
{
    [System.Serializable]
    public class Obstacle: IMovable
    {
        public string Id { get; set; }
        public string InGameId { get; set; }
        public string Slug { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 PreviousPosition { get; set; }
        public float Speed { get; set; }
        public float XSpeed { get; set; }
        public float YSpeed { get; set; }
        public float MaxSpeed { get; set; }
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

        public Obstacle(string id)
        {
            var _gm = GeneralManager.Instance;
            var original = _gm.Obstacles.FindWithId(id);
            InGameId = original.Id == "player" ? original.Id : IdGenerator.GenerateId();
            Slug = original.Slug;
            IsMoving = false;
            IsFalling = false;
            IsJumping = false;
            Speed = 0;
            XSpeed = original.XSpeed;
            YSpeed = original.YSpeed;
            Acceleration = original.Acceleration;
            XAcceleration = original.XAcceleration;
            YAcceleration = original.YAcceleration;
            MaxSpeed = original.MaxSpeed;
            Height = original.Height;
            Width = original.Width;
        }

        public float GetSpeed()
        {
            if (Speed < MaxSpeed) Speed += Acceleration;
            return Speed;
        }

        public float GetMaxSpeed()
        {
            return MaxSpeed;
        }

        public float GetXSpeed()
        {
            return XSpeed;
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

            //
            Height = 4f;
            Width = 1f;
            Speed = 4f;
            CanCollide = true;
            Slug = "obstacle";

        }
    }
}