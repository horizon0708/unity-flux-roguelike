using UnityEngine;

namespace MyRogueLike
{
    [System.Serializable]
    public class Obstacle: IMovable
    {
        public string Id ;
        public string InGameId { get; set; }
        public string Slug ;
        public Vector2 Position { get; set; }
        public Vector2 PreviousPosition { get; set; }
        public float Speed ;
        public float XSpeed ;
        public float YSpeed { get; set; }
        public float MaxSpeed ;
        public float Acceleration ;
        public float XAcceleration ;
        public float YAcceleration ;
        public float Height ;
        public float Width ;
        public bool CanCollide ;

        public float GetYSpeed()
        {
            return 0;
        }

        public void SetYSpeed(float speed)
        {
            YSpeed = speed;
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

            Position = new Vector2(-999, 0);
            PreviousPosition = new Vector2(-999, 0);

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
            if (XSpeed < MaxSpeed) XSpeed += Acceleration;
            return XSpeed;
        }

        public void ChangePosition(Vector2 newPos)
        {
            PreviousPosition = Position;
            Position = newPos;
        }

        public string GetSlug()
        {
            return Slug;
        }

        public string GetId()
        {
            return InGameId;
        }

        public float GetHeight()
        {
            return Height;
        }

        public float GetWidth()
        {
            return Width;
        }

        public Vector2 GetPosition()
        {
            return Position;
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