using UnityEngine;

namespace MyRogueLike.utilities
{
    public class DebugInspector : MonoBehaviour
    {
        public float HeroSpeed;
        public float HeroMaxSpeed;
        public bool IsMoving;
        public Vector2 PreviousPosition;
        public Vector2 Position;
        public GeneralManager GeneralManager;

        void Start()
        {
            GeneralManager = gameObject.GetComponent<GeneralManager>();
        }

        void Update()
        {
            var player = GeneralManager.CurrentRoom.GetMovableObject("player");
            if (player != null)
            {
                HeroSpeed = player.GetSpeed();
                IsMoving = player.IsMoving;
                Position = player.Position;
                PreviousPosition = player.PreviousPosition;
            }
           
        }
    }
}