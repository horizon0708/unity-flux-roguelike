using UnityEngine;

namespace MyRogueLike
{
    [System.Serializable]
    public class Terrain : IBaseObject
    {
        public bool Passable { get; set; }
        public string Id { get; set; }
        public string Slug { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public Vector2 Position { get; set; }

        public void SetPosition(Vector2 position)
        {
            Position = position;
        }
    }
}