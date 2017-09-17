using System.Collections.Generic;
using UnityEngine;

namespace MyRogueLike
{
    public class Mover : IUpdateRenderer
    {
        private List<IMovable> _movables;

        public Mover(GeneralManager gm)
        {
            var generalManager = gm;
            var globalStore = generalManager.GlobalStore;
            var currentLevel = globalStore.GetCurrentLevel();
            var currentRoom = currentLevel.getRoomById(GlobalStore.CurrentRoomId);
            _movables = currentRoom.MovableObjects;
        }

        public void GameRender()
        {
            foreach (var obj in _movables)
            {
                var id = obj.InGameId;
                var go = GameObject.Find(id);
                if (go != null)
                {
                    go.transform.position = obj.GetPosition();
                }
            }
        }
    }
}