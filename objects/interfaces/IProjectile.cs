using UnityEngine;

namespace MyRogueLike
{
    public interface IProjectile : IMovable, ISpiky
    {
        Vector2 Direction { get; set; }
        Vector2 PreviousDirection { get; set; }

        Vector2 GetDirection();
        void ChangeDirection(Vector2 newDir);
    }
}