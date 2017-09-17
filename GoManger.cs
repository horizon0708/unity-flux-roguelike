using UnityEngine;

namespace MyRogueLike
{
    public class GoManager : MonoBehaviour
    {
        public void CreateMovable(IMovable target)
        {
            MovableCreator.CreateMovable(new GameObject(), target);
        }

        public void DestroyMovable(IMovable target)
        {
            var go = GameObject.Find(target.InGameId);
            if (go != null)
            {
                Destroy(go);
            }
            else
            {
                Debug.Log("Tried to destroy one of" + target.GetId() + " but failed!");
            }

        }
    }
}