using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MyRogueLike
{
    public class Room
    {
        public List<Unit> UnitsInRoom = new List<Unit>();
        public int Id;

        public Room(int id, List<Unit> units)
        {
            Id = id;
            UnitsInRoom = units;
        }


        public Unit addObject(string id, Vector2 startingPos)
        {
            var newObj = new Unit(id, startingPos);
            UnitsInRoom.Add(newObj);
            return newObj;
        }

        public Unit getObject(string id)
        {
            return UnitsInRoom.Find(x => x.Id == id);
        }
    }
}