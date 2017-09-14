using UnityEngine;
using UnityEngine.Assertions.Comparers;

namespace MyRogueLike
{
    public interface IMovable : IBaseObject
    {
        float Speed { get; set; }
        float GetSpeed();
    }
}