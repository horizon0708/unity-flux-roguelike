using UnityEngine;

namespace MyRogueLike
{
    public class CameraManager
    {
        public float Height;
        public float Width;
        public float Top;
        public float Right;
        public float Bottom;
        public float Left;

        public CameraManager()
        {
            Height = 2 * Camera.main.orthographicSize;
            Width = Height * Camera.main.aspect;
            Top = Height / 2;
            Bottom = -Top;
            Right = Width / 2;
            Left = -Right;
        }
    }
}