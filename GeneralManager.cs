using System;
using System.Collections;
using System.Collections.Generic;
using MyRogueLike.reducers;
using UnityEngine;

namespace MyRogueLike
{
    public class GeneralManager : MonoBehaviour
    {
        public ActionManager ActionManager;
        public InputManager InputManager;
        public StoreManager StoreManager;
        public RoomManager RoomManager;
        public ReducerManager ReducerManager;
        public Mover Mover;
        public GlobalStore GlobalStore;

        // Use this for initialization

        // Saving References ... do i need to?
        public Level CurrentLevel;
        public Room CurrentRoom;
        public Unit Player;
        public Terrains Terrains;

        void Awake()
        {
            GlobalStore = new GlobalStore();
            Level level = GlobalStore.AddToLevelList(new Level(1, new List<Room>()));
            Room room = level.addRoom();
            room.addObject("player", Vector2.left);
            room.addObject("test", Vector2.right);
            CurrentLevel = GlobalStore.GetCurrentLevel();
            CurrentRoom = CurrentLevel.getCurrentRoom();
            Terrains = new Terrains();
        }

        void Start()
        {
            ActionManager = gameObject.AddComponent<ActionManager>();
            InputManager = gameObject.AddComponent<InputManager>();
            StoreManager = gameObject.AddComponent<StoreManager>();
            RoomManager = gameObject.AddComponent<RoomManager>();
            ReducerManager = gameObject.AddComponent<ReducerManager>();
            Mover = gameObject.AddComponent<Mover>();
            Debug.Log(Terrains.TerrainList[0].Id);
        }


        // Update is called once per frame
        void Update()
        {
            InputManager.CheckInputs();
            Mover.MoveStuff();
        }
    }

}

