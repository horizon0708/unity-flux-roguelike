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
        public GoManager GoManager;

        public List<IUpdater> Updaters;

        public CameraManager CameraManager { get; private set; }

        // Use this for initialization

        // Saving References for easy access ... do i need to?
        public GlobalStore GlobalStore;
        public Level CurrentLevel;
        public Room CurrentRoom;

        void Awake()
        {
            // load asssets;
            CameraManager = new CameraManager();
            StoreManager = new StoreManager();
            ReducerManager = new ReducerManager(this);
            GlobalStore = StoreManager.GlobalStore;
            CurrentLevel = StoreManager.CurrentLevel;
            CurrentRoom = CurrentLevel.getCurrentRoom();

            GoManager = gameObject.AddComponent<GoManager>();


            Updaters = new List<IUpdater>();
            //I think this could be abstracted away later
            RenderManager = AddUpdater(new RenderManager(this)) as RenderManager;
            RenderManager.AddUpdateRenderer(new Mover(this));
            //RenderManager.AddInitialRenderer(new RoomRenderer(this));

            RuleManager = AddUpdater(new RuleManager(this)) as RuleManager;
            RuleManager.AddRule(new GoLifecycle());  // this rule must come before any position altering rules like 

            //RuleManager.AddRule(new ResetSpeed());
            RuleManager.AddRule(new BenFlipperRule());
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
            gameObject.AddComponent<PipeGenerator>();
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

