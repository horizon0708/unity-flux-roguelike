using System;
using System.Collections.Generic;
using System.Reflection;

namespace MyRogueLike
{
    public class GameplayReducer
    {
        public void Evaluate(Action action)
        {
            switch (action.Type)
            {
                case "MOVE":
                {
                    dynamic payload = action.Payload;
                    var instigator = payload.instigator;
                    var direction = payload.direction;
                    instigator.Position = MoveController.CheckCollisionThenMove(instigator, direction);
                    break;
                }

                case "TOUCH":
                {
                    dynamic payload = action.Payload;
                    
                    break;

                }

                default:
                    break;
            }
        }
        
    }
}