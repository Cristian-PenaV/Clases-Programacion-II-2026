using UnityEngine;
using UnityEngine.UI;

public class HUD_Manager : MonoBehaviour
{
    public Slider healthBar;
    private PlayerStats playerStats;
    public GameObject pauseMenuPanel;
    float maxHealth = 0, currentHealth = 0;

    void Awake()
    {
        // Busca al jugador en la escena al iniciar
        GameObject player = GameObject.Find("Player");

        if (player != null)
        {
            playerStats = player.GetComponent<PlayerStats>();
            Debug.Log("Datos del jugador conectados al HUD");

            maxHealth = playerStats.GetMaxHealth();
        }
    }

    private void Update()
    {
        if (healthBar != null && playerStats != null)
            HealthBarController();
    }


    // ... en HUDManager ...

    // Función llamada por el GameManager
    public void TogglePauseMenu(bool show)
    {
        pauseMenuPanel.SetActive(show);
    }

    private void HealthBarController()
    {
        currentHealth = playerStats.GetHealth() / maxHealth; //Calculo el % de vida del jugador 0 - 1

        if (currentHealth != healthBar.value)
        {
            healthBar.value = currentHealth;
        }

        if(currentHealth <= 0)
        {
            Debug.Log("GAME OVER");
        }
        
    }
}
