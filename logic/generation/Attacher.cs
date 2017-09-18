using MyRogueLike.components;
using UnityEngine;

namespace MyRogueLike
{
    public static class Attacher
    {
        public static void Collider(GameObject go, IBaseObject bo)
        {
            if (bo.IsRound())
            {
                CircleCollider(go, bo);
            }
            else
            {
                var r = go.AddComponent<Rigidbody2D>();
                r.isKinematic = true;

                var collider = go.AddComponent<BoxCollider2D>();
                var height = bo.GetHeight();
                var width = bo.GetWidth();
                collider.size = new Vector2(width, height);
                collider.isTrigger = true;
            }

           
        }

        public static void OnCollision(GameObject go)
        {
            go.AddComponent<OnCollision>();
        }

        public static void Sprite(GameObject go, IBaseObject bo)
        {
            var sprite = go.AddComponent<SpriteRenderer>();
            sprite.sprite = Resources.Load<Sprite>("sprites/" +bo.GetSlug());
            var height = bo.GetHeight();
            var width = bo.GetWidth();
            sprite.size = new Vector2(width, height);
        }

        public static void Values(GameObject go, IBaseObject bo)
        {
            go.name = bo.InGameId;
            go.transform.position = bo.GetPosition();
        }

        public static void CircleCollider(GameObject go, IBaseObject bo)
        {
            var r = go.AddComponent<Rigidbody2D>();
            r.isKinematic = true;

            var collider = go.AddComponent<CircleCollider2D>();
            var height = bo.GetHeight();
            collider.radius = height;
            collider.isTrigger = true;
        }
    }
}