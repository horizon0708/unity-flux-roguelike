using UnityEngine;

namespace MyRogueLike
{
    public class GoManager : MonoBehaviour
    {
        public void DestroyMovable(IMovable target)
        {
            var go = GameObject.Find(target.InGameId);
            if (go != null)
            {
                Destroy(go);
                Debug.Log(GeneralManager.Instance.CurrentRoom.MovableObjects.Count);
                GeneralManager.Instance.CurrentRoom.RemoveMovable(target.InGameId);
            }
            else
            {
                Debug.Log("Tried to destroy one of" + target.GetId() + " but failed!");
            }

        }
    }
}