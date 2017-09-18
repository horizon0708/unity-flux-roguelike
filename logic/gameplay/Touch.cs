using System.Reflection;

namespace MyRogueLike
{
    public static class Touch
    {
        public static void Evaluate(IBaseObject target, IBaseObject instigator)
        {
            if (target is IDamagable && instigator is ISpiky)
            {
               GeneralManager.Instance.ReducerManager.Dispatch(new Action("DAMAGE", new Payload(target, instigator)));
            }
        }
    }
}