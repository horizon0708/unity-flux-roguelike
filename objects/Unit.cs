using System.Collections.Generic;
using UnityEngine;

namespace MyRogueLike
{
    public class Unit: IMovable
    {
        public string Id { get; set; }
        public string Slug { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 PreviousPosition { get; set; }
        public float Radius;
 
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
            Id = id;
            Position = position;
            Radius = 0.01f;
            Height = 1;
            Width = 1;
            Speed = 1f;
            MaxSpeed = 10f;
            IsMoving = false;
            IsJumping = false;
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
            return Speed;
        }

        public float GetYSpeed()
        {
            var glob = GeneralManager.Instance.GlobalStore.GlobalParameters;
            if (IsJumping)
            {
                YSpeed = 5f;
            }
            else if (YSpeed > glob.TerminalVelocity) YSpeed -= glob.Gravity;
            
            return YSpeed;
        }
    }
}