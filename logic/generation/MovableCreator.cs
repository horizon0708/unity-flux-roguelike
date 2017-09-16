using UnityEditor;
using UnityEngine;

namespace MyRogueLike
{
    public static class MovableCreator
    {
        public static GameObject CreateMovable(GameObject target, IMovable original)
        {
            Attacher.Collider(target, original);
            Attacher.Sprite(target,original);
            Attacher.Values(target, original);

            return target;
        }
    }
}