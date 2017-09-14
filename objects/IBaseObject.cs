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
    }
}