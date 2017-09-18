using System;
using System.Collections;
using System.Timers;
using UnityEngine;
using Random = UnityEngine.Random;

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
        private int _age;

        private float _cameraHeight;
        private float _cameraWidth;
        private float _topOfScreen;
        private float _bottomOfScreen;
        private float _rightOfScreen;
        private float _leftOfScreen;
        private float _gap = 4f;
        private float _offset;
        private float _delay = 0f;
        private float _alternate = 1;

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
            while (_gm.GlobalStore.SysState == GlobalStore.SystemState.Playing)
            {
                yield return new WaitForSeconds(getDelay());
                Debug.Log(getDelay());
                CreatePipes();

            }
        }

        private float getDelay()
        {
            var startDelay = 2f;
            var max = 1.2f;
            var formula = _gm.GlobalStore.CurrentAge * 1.6f / 60;
            if (formula > max)
            {
                return startDelay - max;
            }
            return startDelay - formula;
        }

        public void CreatePipes()
        {
            var pipeOne = new EnemyProjectile("pipe", Vector2.left);
            var pipeTwo = new EnemyProjectile("pipe", Vector2.left);
            _gap = 8f - _gm.GlobalStore.CurrentAge * 4f / 100;
            _offset = _alternate * Random.Range(0f, 5f);
            _alternate = Random.Range(0, 1f) > 0.2f ? _alternate * -1 : _alternate;
            var topPipeY = _topOfScreen + _gap / 2 + _offset;
            var bottomPipeY = _bottomOfScreen - _gap / 2 + _offset;
            room.AddMovable(pipeOne, new Vector2(_rightOfScreen, topPipeY));
            room.AddMovable(pipeTwo, new Vector2(_rightOfScreen, bottomPipeY));
        }

    }
}