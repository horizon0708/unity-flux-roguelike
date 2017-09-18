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

                case "MOVE_PROJECTILE":
                {
                    var target = action.Payload.Target as IMovable;
                    var proj = target as IProjectile;
                    var direction = proj.Direction;
                    target?.ChangePosition(MoveController.Move(target, direction));
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
                    target.YSpeed = 15f;
                    break;
                }

                case "TOUCH":
                {
                    var payload = action.Payload;
                    var target = payload.Target;
                    var instigator = payload.Instigator;
                    Touch.Evaluate(target, instigator);
                    Debug.Log("touch");
                    break;
                }

                case "DAMAGE":
                {
                    var payload = action.Payload;
                    var target = payload.Target as IDamagable;
                    var instigator = payload.Instigator as ISpiky;
                    var damage = instigator.GetDamage();
                    Debug.Log("damage");
                    //target.Hp -= damage;
                    target.TakeDamage(damage);
                    break;
                }

                case "KILL_PLAYER":
                {
                    
                    break;
                }

                default:
                    break;
            }
        }
    }
}