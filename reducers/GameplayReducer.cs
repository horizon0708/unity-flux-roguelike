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
                    var payload = action.Payload;
                    var target = payload.Target;
                    dynamic paras = payload.Parameters;
                    var direction = paras.direction;
                    if (target != null) target.Position = MoveController.CheckCollisionThenMove(target, direction);
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