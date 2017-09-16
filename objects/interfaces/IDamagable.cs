namespace MyRogueLike
{
    public interface IDamagable
    {
        int Hp { get; set; }

        void TakeDamage();
    }
}