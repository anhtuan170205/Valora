using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private const int MAX_HEALTH = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = MAX_HEALTH;
    }

    public void Damage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
