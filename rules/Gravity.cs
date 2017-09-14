using UnityEngine;

namespace MyRogueLike
{
    public class Gravity : IRule
    {
        private GeneralManager _gm = GeneralManager.Instance;

        public void GameUpdate()
        {
            var room = _gm.CurrentRoom;
            var movables = room.MovableObjects;

            foreach (var movable in movables)
            {
                GeneralManager.Instance.ReducerManager.Dispatch( new Action("FALL", new Payload(movable)));
            }

            foreach (var movable in movables)
            {
                if (movable.PreviousPosition.y > movable.Position.y)
                {
                    movable.IsFalling = true;
                }
                else
                {
                    movable.IsFalling = false;
                }
            }
        }
    }
}