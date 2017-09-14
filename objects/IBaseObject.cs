using UnityEngine;

namespace MyRogueLike
{
    public interface IBaseObject
    {
        string Id { get; set; }
        string Slug { get; set; }
        float Height { get; set; }
        float Width { get; set; }
        Vector2 Position { get; set; }
        Vector2 PreviousPosition { get; set; }

        void ChangePosition(Vector2 newPos);
    }
}