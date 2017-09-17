using MyRogueLike;
using UnityEngine;

namespace Assets.scripts.rules
{
    public class PipeMovement : IRule
    {
        public void GameUpdate()
        {
            var _gm = GeneralManager.Instance;
            var room = _gm.CurrentRoom;
            var movables = room.GetMovablesExcept("player");  


            foreach (var mov in movables)
            {
                _gm.ReducerManager.Dispatch(new Action("PLATFORM_MOVE", new Payload(mov)));
            }
        }
    }
}