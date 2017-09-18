using System;
using System.Collections;
using System.Timers;
using UnityEngine;

namespace MyRogueLike
{
    public class PipeGenerator : MonoBehaviour
    {
        public int Difficulty;
        public float Interval;
        public float Speed;
        private GeneralManager _gm;
        private Timer _timer;
        private Room room;

        private float _cameraHeight;
        private float _cameraWidth;
        private float _topOfScreen;
        private float _bottomOfScreen;
        private float _rightOfScreen;
        private float _leftOfScreen;
        private float _gap = 4f;
        private float _offset = 2f;

        void Start()
        {
            _gm = GeneralManager.Instance;
            Interval = 2f;
            room = _gm.GlobalStore.GetCurrentLevel().getCurrentRoom();
            StartCoroutine(PipeGenerateTimer());

            _cameraHeight = 2 * Camera.main.orthographicSize;
            _cameraWidth = _cameraHeight * Camera.main.aspect;
            _topOfScreen = _cameraHeight / 2;
            _bottomOfScreen = -_topOfScreen;
            _rightOfScreen = _cameraWidth / 2;
            _leftOfScreen = -_rightOfScreen;

        }

        IEnumerator PipeGenerateTimer()
        {
            while (true)
            {
                
                yield return new WaitForSeconds(3);
                CreatePipes();

            }
        }

        public void CreatePipes()
        {
            var pipeOne = new Projectile("pipe", Vector2.left);
            var pipeTwo = new Projectile("pipe", Vector2.left);
            var topPipeY = _topOfScreen + _gap / 2 + _offset;
            var bottomPipeY = _bottomOfScreen - _gap / 2 + _offset;
            room.AddMovable(pipeOne, new Vector2(_rightOfScreen, topPipeY));
            room.AddMovable(pipeTwo, new Vector2(_rightOfScreen, bottomPipeY));
        }

    }
}