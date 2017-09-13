using System;
using System.Collections.Generic;
using System.Reflection;

namespace MyRogueLike.reducers
{
    public class GameplayReducer
    {
        public void Evaluate(Action action)
        {
            switch (action.Type)
            {
                case "MOVE":
                    dynamic payload = action.Payload;
                    var instigator = payload.instigator;
                    var direction = payload.direction;
                    instigator.Position = MoveEvaluator.CheckCollisionThenMove(instigator, direction);
                    break;

                default:
                    break;
            }
        }
        
    }
}