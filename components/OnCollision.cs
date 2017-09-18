using UnityEngine;

namespace MyRogueLike.components
{
    public class OnCollision : MonoBehaviour
    {


        void OnCollisionEnter2D(Collision2D coll)
        {
            Debug.Log("coll");
            
        }

        void OnTriggerEnter2D(Collider2D coll)
        {
            Debug.Log("trigg");
            if (coll.gameObject.name != null && gameObject.name != null)
            {
                var targetName = coll.gameObject.name;
                var instigatorName = gameObject.name;

                var _gm = GeneralManager.Instance;
                var room = _gm.CurrentRoom;
                var target = room.GetMovableObject(targetName) as IBaseObject;
                var instigator = room.GetMovableObject(instigatorName) as IBaseObject;

                _gm.ReducerManager.Dispatch(new Action("TOUCH", new Payload(target, instigator)));
            }
        }
    }
}