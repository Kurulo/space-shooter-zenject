public class EnemyHealth
{
    private int _health;
    
    public int Health => _health;

    public EnemyHealth(int health)
    {
        _health = health;
    }
    
    public void TakeDamage(int dmg)
    {
        _health -= dmg;
    }
    
    private bool CheckDeath()
    {
        return _health < 0;
    }
}
