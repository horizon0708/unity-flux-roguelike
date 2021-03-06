﻿using System.Collections.Generic;
using UnityEngine;

namespace MyRogueLike
{
    [System.Serializable]
    public class Unit: IMovable, IDamagable
    {
        public string Id;
        public string InGameId { get; set; }
        public string Slug;
        public Vector2 Position { get; set; }
        public Vector2 PreviousPosition { get; set; }
 
        public bool IsMoving { get; set; }
        public bool IsFalling { get; set; }
        public bool IsJumping { get; set; }

        public float Speed;
        public float XSpeed;
        public float Acceleration;
        public float XAcceleration;
        public float YAcceleration;
        public float MaxSpeed;

        public List<string> Debuffs;
        public List<string> Buffs;
        public bool CanCollide;
        public float Height;
        public float Width;

        public Unit(string id, Vector2 position)
        {
            InGameId = id;
            Position = position;
        }

        public Unit(string id)
        {
            var original = Library.Units.Find(x => x.Id == id);
            Id = original.Id;
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
            Hp = original.MaxHp;
            MaxHp = original.MaxHp;

            Position = new Vector2(-999, 0);
            PreviousPosition = new Vector2(-999, 0);
        }


        public void ChangePosition(Vector2 newPos)
        {
            PreviousPosition = Position;
            Position = newPos;
        }

        public string GetId()
        {
            return Id;
        }

        public string GetSlug()
        {
            return Slug;
        }

        public bool IsRound()
        {
            return true;
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

        public float YSpeed { get; set; }

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

        public void SetYSpeed(float speed)
        {
            YSpeed = Speed;
        }

        public int Hp { get; set; }
        public int PreviousHp { get; set; }
        public int MaxHp;

        public void TakeDamage(int damage)
        {
            PreviousHp = Hp;
            Hp -= damage;
        }

        public int GetHp()
        {
            return Hp;
        }
    }
}