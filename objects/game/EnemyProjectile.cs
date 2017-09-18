using UnityEngine;

namespace MyRogueLike
{
    public class EnemyProjectile: BaseProjectile, ISpiky
    {
        public EnemyProjectile(string id, Vector2 direction) : base(id, direction)
        {

        }
    }
}