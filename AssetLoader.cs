namespace MyRogueLike
{
    public class AssetLoader
    {
        private GeneralManager _gm = GeneralManager.Instance;
        public Obstacles Obstacles;
        public Units Units;
        public Terrains Terrains;

        public AssetLoader()
        {
            Load();
        }

        public void Load()
        {
            Obstacles = new Obstacles();
            Units = new Units();
            Terrains = new Terrains();
            var Test = new Tests();
        }
    }
}