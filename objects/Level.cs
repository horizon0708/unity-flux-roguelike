using System.Collections.Generic;
using System.Linq;

namespace MyRogueLike
{
    public class Level
    {
        public List<Room> Rooms;
        public int Id;

        public Level(int id, List<Room> rooms)
        {
            Id = id;
            Rooms = rooms;
        }

        public Room addRoom()
        {
            var room = new Room(Rooms.Count, new List<Unit>());
            Rooms.Add(room);
            return room;
        }

        public Room getRoomById(int id)
        {
            return Rooms.Find(x => x.Id == id);
        }

        public Room getCurrentRoom()
        {
            return Rooms.Find(x => x.Id == GlobalStore.CurrentRoomId);
        }
    }
}