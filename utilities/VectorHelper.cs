using UnityEngine;

namespace MyRogueLike.utilities
{
    public static class VectorHelper
    {
        public static float SquaredDistance(Vector2 a, Vector2 b)
        {
            var x = a.x - b.y;
            var y = a.y - b.y;
            var squaredDistance = Mathf.Pow(x, 2) + Mathf.Pow(y, 2);
            return squaredDistance;
        }
    }
}