using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    private int currentCoins = 0;

    void Start()
    {
        currentHealth = maxHealth;
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
}