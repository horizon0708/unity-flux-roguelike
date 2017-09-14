using UnityEngine;

namespace MyRogueLike
{
    public class RoomRenderer : IInitialRenderer
    {   
        // this guy should handle all info for movement handling etc.
        private Room room;
        private Level level;
        private GeneralManager generalManager;
        private GlobalStore globalStore;

        public RoomRenderer(GeneralManager gm)
        {
            generalManager = gm; // inject reference to gm on construction.
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
            foreach (var unit in room.MovableObjects)
            {
                UnitCreator.CreateUnit(new GameObject(), unit as Unit);
            }
        }

        public void GameRender()
        {
            throw new System.NotImplementedException();
        }
    }
}