using UnityEngine;
using UnityEngine.UI;

public class HUD_Manager : MonoBehaviour
{
    public Slider healthBar;
    public GameObject pauseMenuPanel;

    private bool esPausado = false;

    void Start()
    {
        PausarJuego(false); // Asegúrate de que el juego no esté pausado al inicio

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // playerScript = player.GetComponent<PlayerHealth>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            esPausado = !esPausado;
            PausarJuego(esPausado);
        }
    }

    private void PausarJuego(bool pausar) // true = pausar, false = reanudar
    {
        esPausado = pausar;
        pauseMenuPanel.SetActive(pausar);
        Time.timeScale = pausar ? 0f : 1f;
    }

    public void TogglePauseMenu(bool show)
    {
        PausarJuego(show);
    }

    // 🚪 FUNCIÓN PARA EL BOTÓN DE CERRAR JUEGO
    public void CerrarJuego()
    {
        Debug.Log("Saliendo del juego... (Esto solo se verá en la compilación final)");

        // Cierra la aplicación (Funciona en el juego ejecutable ya compilado .exe/.app)
        Application.Quit();

#if UNITY_EDITOR
        // Si estás probando dentro del editor de Unity, esto detiene el modo Play automáticamente
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
