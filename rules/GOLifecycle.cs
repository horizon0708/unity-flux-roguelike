using MyRogueLike;
using UnityEngine;

namespace Assets.scripts.rules
{
    public class GoLifecycle : IRule
    {
        private GeneralManager _gm = GeneralManager.Instance;

        public void GameUpdate()
        {
            var room = _gm.GlobalStore.GetCurrentLevel().getCurrentRoom();
            var allObj = room.MovableObjects;
            foreach (var anObj in allObj)
            {

                if (anObj.PreviousPosition.x < -100 && anObj.Position.x > -900f)
                {
                    _gm.ReducerManager.Dispatch(new Action("GO_CREATE", new Payload(anObj)));
                    Debug.Log("create");
                }
                if (anObj.PreviousPosition.x > -900 && anObj.Position.x  < - 900)
                {
                    _gm.ReducerManager.Dispatch(new Action("GO_DESTROY", new Payload(anObj)));
                }
            }
        }
    }
}