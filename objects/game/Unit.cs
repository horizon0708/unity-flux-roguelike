using System.Collections.Generic;
using UnityEngine;

namespace MyRogueLike
{
    [System.Serializable]
    public class Unit: IMovable
    {
        public string Id { get; set; }
        public string InGameId { get; set; }
        public string Slug { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 PreviousPosition { get; set; }
 
        public bool IsMoving { get; set; }
        public bool IsFalling { get; set; }
        public bool IsJumping { get; set; }

        public float Speed { get; set; }
        public float XSpeed { get; set; }
        public float YSpeed { get; set; }
        public float Acceleration { get; set; }
        public float XAcceleration { get; set; }
        public float YAcceleration { get; set; }
        public float MaxSpeed { get; set; }

        public List<string> Debuffs;
        public List<string> Buffs;
        public bool CanCollide { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }

        public Unit(string id, Vector2 position)
        {
            InGameId = id;
            Position = position;
        }

        public Unit(string id)
        {
            var _gm = GeneralManager.Instance;
            var original = _gm.Units.FindWithId(id);
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


        public void ChangePosition(Vector2 newPos)
        {
            PreviousPosition = Position;
            Position = newPos;
        }

        public float GetSpeed()
        {
            // TODO: change speed depending on buffs, debuffs
            if (Speed < MaxSpeed) Speed += Acceleration;
            return Speed;
        }

        public float GetXSpeed()
        {
            if (XSpeed < MaxSpeed) XSpeed += Acceleration;
            return XSpeed;
        }

        public float GetYSpeed()
        {
            var glob = GeneralManager.Instance.GlobalStore.GlobalParameters;
            if (YSpeed > glob.TerminalVelocity) YSpeed -= glob.Gravity;
            
            return YSpeed;
        }
    }
}