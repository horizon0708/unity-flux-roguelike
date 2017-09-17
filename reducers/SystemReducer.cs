namespace MyRogueLike.reducers
{
    public class SystemReducer
    {
        private GeneralManager _gm = GeneralManager.Instance;

        public void Evaluate(Action action)
        {
            var payload = action.Payload;
            switch (action.Type)
            {

                case "GO_CREATE":
                {
                    var target = payload.Target as IMovable;
                    _gm.GoManager.CreateMovable(target);
                    break;
                }

                case "GO_DESTROY":
                {
                    var target = payload.Target as IMovable;
                    _gm.GoManager.DestroyMovable(target);
                    break;
                }

                default:
                    break;
            }
        }
    }
}