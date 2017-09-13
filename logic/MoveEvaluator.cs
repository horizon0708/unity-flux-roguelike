using System.Collections.Generic;
using UnityEngine;

namespace MyRogueLike
{
    public static class MoveEvaluator
    {
        public static Vector2 Move(Unit unit, Vector2 direction)
        {
            var currPos = unit.Position;
            var speed = unit.getSpeed();
            return new Vector2(currPos.x + speed * direction.x, currPos.y + speed * direction.y);
        }

        public static Vector2 CheckCollisionThenMove(Unit unit, Vector2 direction)
        {
            if (direction.x > 0 && IsCollidingRight(unit))
            {
                return Move(unit, new Vector2(0, direction.y));
            }
            if (direction.x < 0 && IsCollidingLeft(unit))
            {
                return Move(unit, new Vector2(0, direction.y));
            }
            if (direction.y > 0 && IsCollidingTop(unit))
            {
                return Move(unit, new Vector2(direction.x, 0));
            }
            if (direction.y < 0 && IsCollidingBottom(unit))
            {
                return Move(unit, new Vector2(direction.x, 0));
            }

            return Move(unit, direction);
        }

        private static bool castRay(Unit unit, Vector2 direction)
        {
            var height = unit.Height;
            var width = unit.Width;
            var position = unit.Position;
            // Need buffer to make sure that the unit does not get stuck inside another collider2d.
            var buffer = unit.getSpeed();
            var rayDistanceX = direction.x * (width / 2 + buffer);
            var rayDistanceY = direction.y * (height / 2 + buffer);
            var rayDistance = Mathf.Abs(rayDistanceY + rayDistanceX);
            var rayOffsetX = Mathf.Abs(direction.y) * width / 2;
            var rayOffsetY = Mathf.Abs(direction.x) * height / 2;
            var rayOrigin = new Vector2(position.x - rayOffsetX, position.y - rayOffsetY);
            var raycastList = new List<RaycastHit2D[]>();
            var rayNumber = 5;
            var rayRepeatX = Mathf.Abs(direction.y) * height / rayNumber;
            var rayRepeatY = Mathf.Abs(direction.x) * width / rayNumber;

            for (int i = 0; i < rayNumber+1; i++)
            {
                var origin = new Vector2(rayOrigin.x + rayRepeatX * i, rayOrigin.y + rayRepeatY * i);
                var debugEndpoint = new Vector2(origin.x + rayDistanceX , origin.y + rayDistanceY);
                Debug.DrawLine(origin, debugEndpoint, Color.white, 5f, false);
                var hit = Physics2D.RaycastAll(origin, direction, rayDistance);
                raycastList.Add(hit);
            }

            foreach (var hits in raycastList)
            {
                foreach (var hit in hits)
                {
                    if (hit.collider != null
                        && hit.collider.name != unit.Id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool IsCollidingRight(Unit unit)
        {
            return castRay(unit, Vector2.right);
        }

        public static bool IsCollidingLeft(Unit unit)
        {
            return castRay(unit, Vector2.left);

        }

        public static bool IsCollidingTop(Unit unit)
        {
            return castRay(unit, Vector2.up);

        }

        public static bool IsCollidingBottom(Unit unit)
        {
            return castRay(unit, Vector2.down);
        }
    }
}