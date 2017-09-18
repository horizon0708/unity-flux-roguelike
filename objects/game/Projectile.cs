using UnityEngine;

namespace MyRogueLike
{
    [System.Serializable]
    public class Projectile : IProjectile
    {
        // Serialized fields
        public string Id;
        public string Slug;
        public float Speed;
        public float XSpeed;
        public float MaxSpeed;
        public float Acceleration;
        public float XAcceleration;
        public float YAcceleration;
        public float Height;
        public float Width;
        public bool CanCollide;
        public int Damage;
        public bool Round;

        public Vector2 Position { get; set; }
        public Vector2 PreviousPosition { get; set; }
        public string InGameId { get; set; }

        public float YSpeed { get; set; }
        public bool IsFalling { get; set; }
        public bool IsMoving { get; set; }
        public bool IsJumping { get; set; }

        public Vector2 Direction { get; set; }
        public Vector2 PreviousDirection { get; set; }

        public void ChangePosition(Vector2 newPos)
        {
            PreviousPosition = Position;
            Position = newPos;
        }

        public string GetId()
        {
            return Id;
        }

        public float GetHeight()
        {
            return Height;
        }

        public float GetWidth()
        {
            return Width;
        }

        public string GetSlug()
        {
            return Slug;
        }

        public bool IsRound()
        {
            return IsRound();
        }

        public Vector2 GetPosition()
        {
            return Position;
        }

        public int GetDamage()
        {
            return Damage;
        }


        public float GetSpeed()
        {
            if (Speed < MaxSpeed) Speed += Acceleration;
            return Speed;
        }

        public float GetXSpeed()
        {
            return XSpeed;
        }

        public float GetYSpeed()
        {
            return YSpeed;
        }

        public void SetYSpeed(float speed)
        {
            YSpeed = speed;
        }

        public Vector2 GetDirection()
        {
            return Direction;
        }

        public void ChangeDirection(Vector2 newDir)
        {
            PreviousDirection = Direction;
            Direction = newDir;
        }

        public Projectile(string id, Vector2 direction)
        {
            var original = Library.Projectiles.Find(x => x.Id == id);

            InGameId = original.Id == "player" ? original.Id : IdGenerator.GenerateId();
            IsMoving = false;
            IsFalling = false;
            IsJumping = false;
            Speed = 0;
            Direction = direction;

            Position = new Vector2(-999, 0);
            PreviousPosition = new Vector2(-999, 0);

            Round = original.Round;
            Slug = original.Slug;
            XSpeed = original.XSpeed;
            YSpeed = original.YSpeed;
            Acceleration = original.Acceleration;
            XAcceleration = original.XAcceleration;
            YAcceleration = original.YAcceleration;
            MaxSpeed = original.MaxSpeed;
            Height = original.Height;
            Width = original.Width;
            Damage = original.Damage;
        }
    }
}