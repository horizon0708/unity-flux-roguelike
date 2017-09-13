using UnityEngine;

namespace MyRogueLike.reducers
{
    public class ReducerManager: MonoBehaviour
    {
        // gets action object {type: string, payload: Object, date: DateTime.Now }
        
        // sends actions to different Reducers, depending on type.

        // sends them to Logger, to be recorded.

        public GameplayReducer GameplayReducer;

        void Start()
        {
            GameplayReducer = new GameplayReducer();
        }

        public void Dispatch(Action action)
        {
            GameplayReducer.Evaluate(action);
        }
    }
}