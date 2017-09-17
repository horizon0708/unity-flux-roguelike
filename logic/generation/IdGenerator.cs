namespace MyRogueLike
{
    public static class IdGenerator
    {
        private static int _idCounter = 0;

        public static string GenerateId()
        {
            var _gm = GeneralManager.Instance;
            var levelId = GlobalStore.CurrentLevelId;
            var roomId = GlobalStore.CurrentRoomId;
            //var numberOfObj = _gm.CurrentRoom.MovableObjects.Count;
            _idCounter++;
            return levelId + "-" + roomId + " " + (_idCounter + 1);
        }
    }
}