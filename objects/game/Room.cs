using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MyRogueLike
{
    public class Room
    {
        public List<IMovable> MovableObjects;
        public List<IProjectile> Projectiles = new List<IProjectile>();
        public List<IBaseObject> AllObjects = new List<IBaseObject>();
        public int Id;

        public Room(int id, List<IMovable> units)
        {
            Id = id;
            MovableObjects = units;
        }

        // surely could abstract this away with AddMovableObject<T> somehow?
        public Unit AddUnit(string id, Vector2 startingPos)
        {
            var newObj = new Unit(id, startingPos);
            MovableObjects.Add(newObj);
            return newObj;
        }

        public void Add<T>(T target, Vector2 startingPos) where T: IBaseObject
        {
            target.Position = startingPos;
                AllObjects.Add(target);
                if (target is IMovable)
                {
                    MovableObjects.Add((IMovable)target);

                    if (target is IProjectile)
                    {
                        Projectiles.Add((IProjectile) target);
                    }
                }
        }

        public IMovable AddMovable(IMovable movable, Vector2 startingPos)
        {
            movable.Position = startingPos;
            MovableObjects.Add(movable);
            AllObjects.Add(movable);
            
            return movable;
        }

        public void RemoveMovable(string ingameid)
        {
            var mov = GetMovableObject(ingameid);
            MovableObjects.Remove(mov);
            AllObjects.Remove(mov);
        }
        

        public IMovable GetMovableObject(string id)
        {
            return MovableObjects.Find(x => x.InGameId == id);
        }

        public List<IMovable> GetMovablesExcept(string id)
        {
            return MovableObjects.Where(x => x.GetId() != id).ToList();
        }
    }
}