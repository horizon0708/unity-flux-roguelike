using System.Collections.Generic;
using System.Linq;

namespace MyRogueLike
{
    // probably could add interface for stores
    public class GlobalStore
    {
        public List<Level> Levels;
        public static int CurrentLevelId = 1;
        public static int CurrentRoomId = 0;
        public Level CurrentLevel;
        public Room CurrentRoom;
        public enum SystemState
        {
            Playing,
            Paused,
        }

        public SystemState SysState;

        public GlobalStore()
        {
            Levels = new List<Level>();
            CurrentRoomId = 1;
            CurrentRoomId = 0;
        }

        public Level AddToLevelList(Level level)
        {
            Levels.Add(level);
            return level;
        }

        public Level GetLevelById(int id)
        {
            return Levels.Find(x => x.Id == id);
        }

        public Level GetCurrentLevel()
        {
            return Levels.Find(x => x.Id == CurrentLevelId);
        }

    }
}