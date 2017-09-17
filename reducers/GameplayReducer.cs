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
                    var target = payload.Target as IMovable;
                    dynamic paras = payload.Parameters;
                    var direction = paras.direction;
                    target?.ChangePosition(MoveController.CheckCollisionThenMove(target, direction));
                    break;
                }

                case "PLATFORM_MOVE":
                {
                    var target = action.Payload.Target as IMovable;
                    
                    target?.ChangePosition(MoveController.Move(target, Vector2.left, 2f));
                    break;
                    }

                case "FALL":
                {
                    var payload = action.Payload;
                    var target = payload.Target as IMovable;
       
                    target?.ChangePosition(MoveController.Fall(target));
                    break;
                }

                case "JUMP":
                {
                    var payload = action.Payload;
                    var target = payload.Target as IMovable;

                    //target.SetYSpeed(100f);
                    //
                    target.YSpeed = 20f;
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