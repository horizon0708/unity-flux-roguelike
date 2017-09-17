using UnityEngine;
using UnityEngine.Assertions.Comparers;

namespace MyRogueLike
{
    public interface IMovable : IBaseObject
    {
        float YSpeed { get; set; }
        bool IsFalling { get; set; }
        bool IsMoving { get; set; }
        bool IsJumping { get; set; }

        float GetSpeed();
        float GetXSpeed();
        float GetYSpeed();

        void SetYSpeed(float speed);
    }
}