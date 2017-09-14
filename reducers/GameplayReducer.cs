using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

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
                    if (target != null) target.ChangePosition(MoveController.CheckCollisionThenMove(target, direction));
                    break;
                }

                case "FALL":
                {
                    var payload = action.Payload;
                    var target = payload.Target;
       
                    target.ChangePosition(MoveController.Fall(target));
                    break;
                }

                case "JUMP":
                {
                    var payload = action.Payload;
                    var target = payload.Target;

                    target.YSpeed = 30f;                   

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