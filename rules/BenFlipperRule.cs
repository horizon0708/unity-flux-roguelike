using UnityEditor.Rendering;

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
            MovePlatforms();
            KillPlayerOnScreenLeave();
            DestroyPlatformsOnScreenLeave();
        }

        void MovePlatforms()
        {
            var movables = room.GetMovablesExcept("player");

            foreach (var mov in movables)
            {
                _gm.ReducerManager.Dispatch(new Action("PLATFORM_MOVE", new Payload(mov)));
            }
        }

        void KillPlayerOnScreenLeave()
        {
            var player = room.GetMovableObject("player");
            if (player.Position.y > _topOfScreen + _offscreenMargin 
                || player.Position.y < _bottomOfScreen - _offscreenMargin
                || player.Position.x < _leftOfScreen - _offscreenMargin
                || player.Position.x > _rightOfScreen + _offscreenMargin)
            {
                _gm.ReducerManager.Dispatch(new Action("KILL_PLAYER", new Payload(player)));
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
    }
}