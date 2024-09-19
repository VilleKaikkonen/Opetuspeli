public interface IDamageableG
{
    int currentHealth { get; set; }
    int maxHealth { get; set; }

    public void TakeDamage(int damage);

}
