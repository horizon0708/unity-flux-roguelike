using UnityEngine;

namespace MyRogueLike.reducers
{
    public class ReducerManager
    {
        // gets action object {type: string, payload: Object, date: DateTime.Now }
        
        // sends actions to different Reducers, depending on type.

        // sends them to Logger, to be recorded.

        private GameplayReducer _gameplayReducer;
        private SystemReducer _systemReducer;
        private GeneralManager _gm;

        public ReducerManager(GeneralManager gm)
        {
            _gm = gm;
            _gameplayReducer = new GameplayReducer();
            _systemReducer = new SystemReducer();
        }

        public void Dispatch(Action action)
        {
            if (_gm.GlobalStore.SysState == GlobalStore.SystemState.Playing)
            {
                _gameplayReducer.Evaluate(action);
            }
            _systemReducer.Evaluate(action);
        }
    }
}