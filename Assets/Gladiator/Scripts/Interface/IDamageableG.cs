/*
 Author: Antti Sironen
Interface for damageable objects
 */

public interface IDamageableG
{
    int currentHealth { get; set; }
    int maxHealth { get; set; }

    public void TakeDamage(int damage);

}
