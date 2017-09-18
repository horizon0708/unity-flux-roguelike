using System.Collections.Generic;

namespace MyRogueLike
{
    public class Payload
    {
        public IBaseObject Instigator;
        public IBaseObject Target;
        public object ParamOne;
        public object ParamTwo;

        public object Parameters;

        public Payload(IBaseObject target, object parameters)
        {
            Target = target;
            Parameters = parameters;
        }
        public Payload(IBaseObject target)
        {
            Target = target;
        }

        public Payload(IBaseObject target, IBaseObject instigator)
        {
            Target = target;
            Instigator = instigator;
        }

    }
}