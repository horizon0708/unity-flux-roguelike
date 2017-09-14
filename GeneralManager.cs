using System;
using System.Collections;
using System.Collections.Generic;
using MyRogueLike.reducers;
using MyRogueLike.rules;
using UnityEngine;

namespace MyRogueLike
{
    public class GeneralManager : MonoBehaviour
    {
        public InputManager InputManager;
        public StoreManager StoreManager;
        public ReducerManager ReducerManager;
        public RenderManager RenderManager;
        public RuleManager RuleManager;

        public List<IUpdater> Updaters;

        // Use this for initialization

        // Saving References for easy access ... do i need to?
        public GlobalStore GlobalStore;
        public Level CurrentLevel;
        public Room CurrentRoom;
        public Terrains Terrains;

        void Awake()
        {
            StoreManager = new StoreManager();
            ReducerManager = new ReducerManager(this);
            GlobalStore = StoreManager.GlobalStore;
            CurrentLevel = StoreManager.CurrentLevel;
            CurrentRoom = CurrentLevel.getCurrentRoom();
            Terrains = StoreManager.Terrains;


            Updaters = new List<IUpdater>();
            //I think this could be abstracted away later
            RenderManager = AddUpdater(new RenderManager(this)) as RenderManager;
            RenderManager.AddUpdateRenderer(new Mover(this));
            RenderManager.AddInitialRenderer(new RoomRenderer(this));

            RuleManager = AddUpdater(new RuleManager(this)) as RuleManager;
            InputManager = AddUpdater(new InputManager(this)) as InputManager;          

            
        }

        IUpdater AddUpdater(IUpdater updater)
        {
            Updaters.Add(updater);
            return updater;
        }

        void Start()
        {
            //handle inital render
            RenderManager.InitialRender();
        }

        void Update()
        {
            foreach (var updater in Updaters)
            {
                updater.ManageUpdate();
            }
        }
    }

}

