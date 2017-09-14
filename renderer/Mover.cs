using UnityEngine;

namespace MyRogueLike
{
    public class Mover: IUpdateRenderer
    {
        private GameObject playerObj;
        private Unit player;
        private Vector2 playerPosition;
        private Vector2 previousPosition;
        private Room currentRoom;
        private Level currentLevel;
        private GeneralManager _gm;
        private GlobalStore globalStore;

        public Mover(GeneralManager gm)
        {
            _gm = gm;
        }

        void Start()
        {
            playerObj = GameObject.Find("player");
            generalManager = gameObject.GetComponent<GeneralManager>();
            globalStore = generalManager.GlobalStore;

            currentLevel = globalStore.GetCurrentLevel();
            currentRoom = currentLevel.getRoomById(GlobalStore.CurrentRoomId);
            player = currentRoom.GetMovableObject("player");
        }

        public void MoveStuff()
        {
            playerObj.transform.position = player.Position;
        }

        public void GameRender()
        {
            throw new System.NotImplementedException();
        }
    }
}