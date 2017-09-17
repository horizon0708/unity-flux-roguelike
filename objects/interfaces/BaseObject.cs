using UnityEngine;

namespace MyRogueLike
{
    public abstract class BaseObject : IBaseObject
    {
        public string Id { get; set; }
        public string InGameId { get; set; }
        public string Slug { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 PreviousPosition { get; set; }

        public void ChangePosition(Vector2 newPos)
        {
            PreviousPosition = Position;
            Position = newPos;
        }

        public string GetId()
        {
            throw new System.NotImplementedException();
        }

        public string GetIngameId()
        {
            throw new System.NotImplementedException();
        }

        public float GetHeight()
        {
            throw new System.NotImplementedException();
        }

        public float GetWidth()
        {
            throw new System.NotImplementedException();
        }

        public string GetSlug()
        {
            throw new System.NotImplementedException();
        }

        public Vector2 GetPosition()
        {
            throw new System.NotImplementedException();
        }
    }
}