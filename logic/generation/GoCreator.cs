﻿using UnityEditor;
using UnityEngine;

namespace MyRogueLike
{
    public static class GoCreator
    {
        public static GameObject Create(GameObject target, IMovable original)
        {
            Attacher.Collider(target, original);
            Attacher.OnCollision(target);
            Attacher.Sprite(target,original);
            Attacher.Values(target, original);

            return target;
        }
        public static GameObject Create(GameObject target, IBaseObject original)
        {
            Attacher.Sprite(target, original);
            Attacher.Values(target, original);

            return target;
        }

        public static GameObject CreatePlayer(GameObject target, IMovable original)
        {
            Attacher.Collider(target, original);
            Attacher.Sprite(target, original);
            Attacher.Values(target, original);

            return target;
        }

    }
}