using UnityEngine;

namespace MyRogueLike
{
    public static class Attacher
    {
        public static void Collider(GameObject go, IBaseObject bo)
        {
            var r = go.AddComponent<Rigidbody2D>();
            r.isKinematic = true;

            var collider = go.AddComponent<BoxCollider2D>();
            var height = bo.Height;
            var width = bo.Width;
            collider.size = new Vector2(width, height);
        }

        public static void Sprite(GameObject go, IBaseObject bo)
        {
            var sprite = go.AddComponent<SpriteRenderer>();
            sprite.sprite = Resources.Load<Sprite>("sprites/" +bo.Slug);
            var height = bo.Height;
            var width = bo.Width;
            sprite.size = new Vector2(width, height);
        }

        public static void Values(GameObject go, IBaseObject bo)
        {
            go.name = bo.Id;
            go.transform.position = bo.Position;
        }

        public static void CircleCollider(GameObject go, IBaseObject bo)
        {
            var r = go.AddComponent<Rigidbody2D>();
            r.isKinematic = true;

            var collider = go.AddComponent<CircleCollider2D>();
            var height = bo.Height;
            var width = bo.Width;
            collider.radius = height;
        }
    }
}