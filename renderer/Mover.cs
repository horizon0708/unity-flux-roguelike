using UnityEngine;

namespace MyRogueLike
{
    public class Mover: MonoBehaviour
    {
        private GameObject playerObj;
        private Unit player;
        private StoreManager storeManager;
        private Vector2 playerPosition;
        private Vector2 previousPosition;
        private Room currentRoom;
        private Level currentLevel;
        private GeneralManager generalManager;
        private GlobalStore globalStore;

        void Start()
        {
            playerObj = GameObject.Find("player");
            storeManager = gameObject.GetComponent<StoreManager>();
            generalManager = gameObject.GetComponent<GeneralManager>();
            globalStore = generalManager.GlobalStore;

            currentLevel = globalStore.GetCurrentLevel();
            currentRoom = currentLevel.getRoomById(GlobalStore.CurrentRoomId);
            player = currentRoom.getObject("player");
        }

        public void MoveStuff()
        {
            playerObj.transform.position = player.Position;
        }
    }
}