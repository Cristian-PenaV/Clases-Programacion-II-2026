using UnityEngine;
using UnityEngine.UI;

public class HUD_Manager : MonoBehaviour
{
    public Slider healthBar;
    //private PlayerHealth playerScript;
    public GameObject pauseMenuPanel;

    void Start()
    {
        // Busca al jugador en la escena al iniciar
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // playerScript = player.GetComponent();

        }
    }

    // ... en HUDManager ...

    // Función llamada por el GameManager
    public void TogglePauseMenu(bool show)
    {
        pauseMenuPanel.SetActive(show);
    }



}
