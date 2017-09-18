using System.Collections.Generic;

namespace MyRogueLike
{
    public static class Library
    {
        //Holds original objects to be cloned from.
        public static List<Obstacle> Obstacles = SerializationHelper.Deserialize<Obstacle>("obstacles.json");
        public static List<Terrain> Terrains = SerializationHelper.Deserialize<Terrain>("terrains.json");
        public static List<Unit> Units = SerializationHelper.Deserialize<Unit>("units.json");
        public static List<BaseProjectile> Projectiles = SerializationHelper.Deserialize<BaseProjectile>("projectiles.json");
    }
}