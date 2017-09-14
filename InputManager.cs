using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyRogueLike
{
    public class InputManager : IUpdater
    {
        private GeneralManager _gm;
        private GlobalStore globalStore;
        private Unit player;
        private Room currentRoom;
        private Level currentLevel;

        public InputManager(GeneralManager gm)
        {
            _gm = gm;
        }

        private void Start()
        {
            globalStore = _gm.GlobalStore;

            currentLevel = globalStore.GetCurrentLevel();
            currentRoom = currentLevel.getRoomById(GlobalStore.CurrentRoomId);

            player = currentRoom.GetMovableObject("player") as Unit;
        }

        public void ManageUpdate()
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
                _gm.ReducerManager.Dispatch(action);

            }
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                var payload = new
                {
                    instigator = player,
                    direction = Vector2.down
                };
                var action = new Action("MOVE", payload);
                _gm.ReducerManager.Dispatch(action);

            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                var payload = new
                {
                    instigator = player,
                    direction = Vector2.left
                };
                var action = new Action("MOVE", payload);
                _gm.ReducerManager.Dispatch(action);

            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                var payload = new
                {
                    instigator = player,
                    direction = Vector2.right
                };
                var action = new Action("MOVE", payload);
                _gm.ReducerManager.Dispatch(action);

            }
        }
    }
}