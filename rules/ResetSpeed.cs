using MyRogueLike;
using UnityEngine;

namespace Assets.scripts.rules
{
    public class ResetSpeed: IRule
    {
        private GeneralManager _gm = GeneralManager.Instance;

        public void GameUpdate()
        {
            var room = _gm.CurrentRoom;
            var movables = room.MovableObjects;
            foreach (var movable in movables)
            {
                if (movable.IsMoving == false)
                {
                    movable.Speed = 0.01f;
                }
            }

            foreach (var movable in movables)
            {
                if (movable.PreviousPosition == movable.Position)
                {
                    movable.IsMoving = false;
                }
                else
                {
                    movable.IsMoving = true;
                }
            }

            foreach (var movable in movables)
            {
                var parameters = new
                {
                    direction = Vector2.zero
                };

                _gm.ReducerManager.Dispatch(new Action("MOVE", new Payload(movable, parameters)));
            }
        }
    }
}