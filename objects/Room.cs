using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MyRogueLike
{
    public class Room
    {
        public List<Unit> ObjectsInRoom = new List<Unit>();
        public int Id;

        public Room(int id, List<Unit> objects)
        {
            Id = id;
            ObjectsInRoom = objects;
        }

        public Unit addObject(string id, Vector2 startingPos)
        {
            var newObj = new Unit(id, startingPos);
            ObjectsInRoom.Add(newObj);
            return newObj;
        }

        public Unit getObject(string id)
        {
            return ObjectsInRoom.Find(x => x.Id == id);
        }
    }
}