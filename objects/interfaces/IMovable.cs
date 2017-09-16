using UnityEngine;
using UnityEngine.Assertions.Comparers;

namespace MyRogueLike
{
    public interface IMovable : IBaseObject
    {
        float Speed { get; set; }
        float XSpeed { get; set; }
        float YSpeed { get; set; }

        float Acceleration { get; set; }
        float XAcceleration { get; set; }
        float YAcceleration { get; set; }

        float GetSpeed();
        float GetXSpeed();
        float GetYSpeed();

        bool IsMoving { get; set; }
        bool IsFalling { get; set; }
        bool IsJumping { get; set; }
    }
}