using UnityEngine;

namespace MyRogueLike
{
    public class RoomManager: MonoBehaviour
    {   
        // this guy should handle all info for movement handling etc.
        private Room room;
        private Level level;
        private GeneralManager generalManager;
        private GlobalStore globalStore;

        void Start()
        {
            generalManager = gameObject.GetComponent<GeneralManager>();
            globalStore = generalManager.GlobalStore;
            level = globalStore.GetCurrentLevel();
            room = level.getCurrentRoom();
            EnterRoom();
        }

        void EnterRoom()
        {
            //instantiate objects
            instantiateObjects();
        }

        void instantiateObjects()
        {
            foreach (var unit in room.UnitsInRoom)
            {
                UnitCreator.CreateUnit(new GameObject(), unit);
            }
        }
    }
}