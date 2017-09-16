using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MyRogueLike
{
    public class Room
    {
        public List<IMovable> MovableObjects = new List<IMovable>();
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

        public IMovable AddMovable(IMovable movable, Vector2 startingPos)
        {
            MovableObjects.Add(movable);
            return movable;
        }
        

        public IMovable GetMovableObject(string id)
        {
            return MovableObjects.Find(x => x.Id == id);
        }

        public List<IMovable> GetMovablesExcept(string id)
        {
            return MovableObjects.Where(x => x.Id != id).ToList();
        }
    }
}