using UnityEngine;

namespace MyRogueLike
{
    public interface IBaseObject
    {
        //JSONutility.FromJSON does not work with getters and setters... sigh.
        Vector2 Position { get; set; }
        Vector2 PreviousPosition { get; set; }
        string InGameId { get; set; }

        void ChangePosition(Vector2 newPos);
        string GetId();
        float GetHeight();
        float GetWidth();
        string GetSlug();
        Vector2 GetPosition();
    }
    
}