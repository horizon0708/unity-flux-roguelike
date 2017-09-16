using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace MyRogueLike
{
    public class StoreManager 
    {
        public GlobalStore GlobalStore { get; }
        public Level CurrentLevel { get; }
        public Room CurrentRoom { get; }
        public Terrains Terrains { get; }

        public StoreManager()
        {
            GlobalStore = new GlobalStore();
            Level level = GlobalStore.AddToLevelList(new Level(1, new List<Room>()));
            Room room = level.addRoom();
            CurrentLevel = GlobalStore.GetCurrentLevel();
            CurrentRoom = CurrentLevel.getCurrentRoom();
            //room.AddUnit("player", Vector2.left);
            //room.AddUnit("test", Vector2.right);
            room.AddMovable(new Unit("player"), Vector2.left);
            room.AddMovable(new Obstacle("pipe"), Vector2.right);
            
            //var testObs = new Obstacle("1", Vector2.zero);
            //room.AddMovable(testObs, Vector2.zero);


        }
    }
}
