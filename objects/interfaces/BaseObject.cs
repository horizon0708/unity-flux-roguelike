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


    }
}