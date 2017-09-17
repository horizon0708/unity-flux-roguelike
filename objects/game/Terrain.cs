using UnityEngine;

namespace MyRogueLike
{
    [System.Serializable]
    public class Terrain : IBaseObject
    {
        public bool Passable;
        public string Id;
        public string InGameId { get; set; }
        public string Slug ;
        public float Height ;
        public float Width ;
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

        public string GetId()
        {
            return Id;
        }

        public string GetIngameId()
        {
            return InGameId;
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

        public Vector2 GetPosition()
        {
            return Position;
        }
    }
}