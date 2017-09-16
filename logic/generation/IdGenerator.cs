namespace MyRogueLike
{
    public static class IdGenerator
    {
        public static string GenerateId()
        {
            var _gm = GeneralManager.Instance;
            var levelId = GlobalStore.CurrentLevelId;
            var roomId = GlobalStore.CurrentRoomId;
            var numberOfObj = _gm.CurrentRoom.MovableObjects.Count;
            return levelId + "-" + roomId + " " + (numberOfObj + 1);
        }
    }
}