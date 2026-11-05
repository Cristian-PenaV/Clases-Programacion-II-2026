using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private int currentHealth = 7;
    private int currentCoins = 0;

    void Start()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Vida actual: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die() //Al morir, reinicio el nivel
    {
        //Destroy(gameObject);

        //Reset Level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);

        Debug.Log("El jugador ha muerto. Reiniciando nivel...");
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        Debug.Log("Monedas actuales: " + currentCoins);
    }

    public float GetHealth() => currentHealth;

    public int GetMaxHealth() => maxHealth;

    public void SetHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

}