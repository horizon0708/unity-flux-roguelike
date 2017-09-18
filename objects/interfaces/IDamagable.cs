namespace MyRogueLike
{
    public interface IDamagable : IBaseObject
    {
        void TakeDamage(int damage);
        int GetHp();
    }
}