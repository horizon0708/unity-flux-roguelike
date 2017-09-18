﻿using UnityEngine;

namespace MyRogueLike
{
    public class GoManager : MonoBehaviour
    {
        public void CreateMovable(IMovable target)
        {
            GoCreator.CreateMovable(new GameObject(), target);
        }

        public void DestroyMovable(IMovable target)
        {
            var go = GameObject.Find(target.InGameId);
            if (go != null)
            {
                Destroy(go);
                GeneralManager.Instance.CurrentRoom.RemoveMovable(target.InGameId);
            }
            else
            {
                Debug.Log("Tried to destroy one of" + target.GetId() + " but failed!");
            }

        }
    }
}