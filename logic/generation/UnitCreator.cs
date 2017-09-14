using UnityEditor;
using UnityEngine;

namespace MyRogueLike
{
    public static class UnitCreator
    {
        private const string kKnobPath = "UI/Skin/Knob.psd";
        // attach necessary components to units and return them.
        public static GameObject CreateUnit(GameObject targetObject, Unit original)
        {
            var rb2d = targetObject.AddComponent<Rigidbody2D>();
            rb2d.isKinematic = true;

            var collider = targetObject.AddComponent<BoxCollider2D>();
            var sprite = targetObject.AddComponent<SpriteRenderer>();
            sprite.sprite = AssetDatabase.GetBuiltinExtraResource<Sprite>(kKnobPath);
            sprite.color = Color.red;

            targetObject.name = original.Id;
            targetObject.transform.position = original.Position;
            //
            if (targetObject.name == "player")
            {
                targetObject.layer = 8;
            }

            return targetObject;
        }

        static void AttachRaycast()
        {
            
        }
    }
}