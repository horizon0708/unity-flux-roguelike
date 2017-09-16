using UnityEngine;

namespace MyRogueLike
{
    [System.Serializable]
    public class Terrain : IBaseObject
    {
        public bool Passable { get; set; }
        public string Id { get; set; }
        public string InGameId { get; set; }
        public string Slug { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 PreviousPosition { get; set; }

        public Terrain(string id)
        {
            var _gm = GeneralManager.Instance;
            var original = _gm.Terrains.FindWithId(id);
            InGameId = original.Id == "player" ? original.Id : IdGenerator.GenerateId();
            Slug = original.Slug;
            Height = original.Height;
            Width = original.Width;
        }

        public void ChangePosition(Vector2 position)
        {
            Position = position;
            PreviousPosition = position;
        }
    }
}