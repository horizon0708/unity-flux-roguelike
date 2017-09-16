using System;
using System.Collections;
using System.Collections.Generic;
using Assets.scripts.rules;
using MyRogueLike.reducers;
using MyRogueLike.rules;
using MyRogueLike.utilities;
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
        public AssetLoader AssetLoader;

        public List<IUpdater> Updaters;
        public Obstacles Obstacles;
        public Terrains Terrains;
        public Units Units;

        // Use this for initialization

        // Saving References for easy access ... do i need to?
        public GlobalStore GlobalStore;
        public Level CurrentLevel;
        public Room CurrentRoom;

        void Awake()
        {
            // load asssets;
            AssetLoader = new AssetLoader();
            Obstacles = AssetLoader.Obstacles;
            Terrains = AssetLoader.Terrains;
            Units = AssetLoader.Units;

            StoreManager = new StoreManager();
            ReducerManager = new ReducerManager(this);
            GlobalStore = StoreManager.GlobalStore;
            CurrentLevel = StoreManager.CurrentLevel;
            CurrentRoom = CurrentLevel.getCurrentRoom();


            Updaters = new List<IUpdater>();
            //I think this could be abstracted away later
            RenderManager = AddUpdater(new RenderManager(this)) as RenderManager;
            RenderManager.AddUpdateRenderer(new Mover(this));
            RenderManager.AddInitialRenderer(new RoomRenderer(this));

            RuleManager = AddUpdater(new RuleManager(this)) as RuleManager;
            //RuleManager.AddRule(new ResetSpeed());
            RuleManager.AddRule(new Gravity());

            InputManager = AddUpdater(new InputManager(this)) as InputManager;          

            
        }

        public void AddToCurrentRoom()
        {
            
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
            var pipe = new PipeGenerator(2000f);
         
            //start inspector for debugging
            gameObject.AddComponent<DebugInspector>();
        }

        void Update()
        {
            foreach (var updater in Updaters)
            {
                updater.ManageUpdate();
            }
        }

        private static GeneralManager _instance;
        public static GeneralManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GameObject.FindObjectOfType<GeneralManager>();

                    if (_instance == null)
                    {
                        GameObject container = new GameObject("manager");
                        _instance = container.AddComponent<GeneralManager>();
                    }
                }

                return _instance;
            }
        }
    }

}

