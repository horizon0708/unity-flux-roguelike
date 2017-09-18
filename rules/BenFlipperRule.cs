using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace MyRogueLike
{
    public class BenFlipperRule : IRule
    {
        private float _cameraHeight;
        private float _cameraWidth;
        private float _topOfScreen;
        private float _bottomOfScreen;
        private float _rightOfScreen;
        private float _leftOfScreen;
        private float _offscreenMargin = 0.5f;
        private GeneralManager _gm = GeneralManager.Instance;
        private Room room;

        public BenFlipperRule()
        {
            var cam = _gm.CameraManager;
            _cameraHeight = cam.Height;
            _cameraWidth = cam.Width;
            _topOfScreen = cam.Top;
            _bottomOfScreen = cam.Bottom;
            _rightOfScreen = cam.Right;
            _leftOfScreen = cam.Left;
            room = _gm.CurrentRoom;

        }

        public void GameUpdate()
        {
            MoveProjectiles();
            KillPlayerOnScreenLeave();
            DestroyPlatformsOnScreenLeave();
            KillPlayerOnZeroHp();
            AgeUp();
        }

        void MoveProjectiles()
        {
            var movables = room.GetMovablesExcept("player");

            foreach (var mov in movables)
            {
                if (mov is IProjectile)
                {
                _gm.ReducerManager.Dispatch(new Action("MOVE_PROJECTILE", new Payload(mov)));

                }
            }
        }

        void KillPlayerOnScreenLeave()
        {
            var player = room.GetMovableObject("player");
            if (player != null)
            {
                if (player.Position.y > _topOfScreen + _offscreenMargin
                    || player.Position.y < _bottomOfScreen - _offscreenMargin
                    || player.Position.x < _leftOfScreen - _offscreenMargin
                    || player.Position.x > _rightOfScreen + _offscreenMargin)
                {
                    _gm.ReducerManager.Dispatch(new Action("GO_DESTROY", new Payload(player)));
                }
            }
            
        }

        void KillPlayerOnZeroHp()
        {
            var player = room.GetMovableObject("player") as IDamagable;
            if (player != null)
            {
                if (player.GetHp() < 1)
                {
                    _gm.ReducerManager.Dispatch(new Action("GO_DESTROY", new Payload(player)));
                }
            }          
        }

        void DestroyPlatformsOnScreenLeave()
        {
            var movables = room.GetMovablesExcept("player");
            foreach (var mov in movables)
            {
                if (mov.Position.x < _leftOfScreen - _offscreenMargin)
                {
                    _gm.ReducerManager.Dispatch(new Action("GO_DESTROY", new Payload(mov)));
                }
            }
        }

        void AgeUp()
        {
            var movables = room.GetMovablesExcept("player");
            foreach (var mov in movables)
            {
                if (mov.GetId() == "pipe" 
                    && mov.PreviousPosition.x > 0 
                    && mov.Position.x < 0 
                    && mov.Position.y > 0)
                {
                    UnityEngine.Debug.Log("age up ");
                    _gm.GlobalStore.CurrentAge++;
                }
            }
        }

    }
}