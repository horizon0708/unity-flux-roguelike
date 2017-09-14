using System.Collections.Generic;

namespace MyRogueLike
{
    public class Payload
    {
        public IBaseObject Instigator;
        public IMovable Target;
        public object Parameters;

        public Payload(IMovable target, object parameters)
        {
            Target = target;
            Parameters = parameters;
        }

    }
}