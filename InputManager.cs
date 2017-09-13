using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyRogueLike
{
    public class InputManager : MonoBehaviour
    {
        private GeneralManager generalManager;
        private GlobalStore globalStore;
        private Unit player;
        private Room currentRoom;
        private Level currentLevel;

        private void Start()
        {
            generalManager = gameObject.GetComponent<GeneralManager>();
            globalStore = generalManager.GlobalStore;

            currentLevel = globalStore.GetCurrentLevel();
            currentRoom = currentLevel.getRoomById(GlobalStore.CurrentRoomId);

            player = currentRoom.getObject("player");
        }

        public void CheckInputs()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                
            }
            if (Input.GetButtonDown("Fire2"))
            {
            }
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                var payload = new
                {
                    instigator = player,
                    direction = Vector2.up
                };
                var action = new Action("MOVE", payload);
                generalManager.ReducerManager.Dispatch(action);

            }
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                var payload = new
                {
                    instigator = player,
                    direction = Vector2.down
                };
                var action = new Action("MOVE", payload);
                generalManager.ReducerManager.Dispatch(action);

            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                var payload = new
                {
                    instigator = player,
                    direction = Vector2.left
                };
                var action = new Action("MOVE", payload);
                generalManager.ReducerManager.Dispatch(action);

            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                var payload = new
                {
                    instigator = player,
                    direction = Vector2.right
                };
                var action = new Action("MOVE", payload);
                generalManager.ReducerManager.Dispatch(action);

            }
        }
    }
}