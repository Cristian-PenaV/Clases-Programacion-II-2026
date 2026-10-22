using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private HUD_Manager HUD;
    private bool inPause = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyUp(KeyCode.Escape)) // Pauso al apretar ESC 
        {
            Pause();
        }
        
    }

    public void Pause()
    {
        inPause = !inPause;

        Debug.Log(inPause);

        if(inPause) // Pauso
            Time.timeScale = 0.0f;

        else      //reanudo
            Time.timeScale = 1.0f;

        HUD.TogglePauseMenu(inPause); // Muestro/Oculto el panel de Pausa
    }
}
