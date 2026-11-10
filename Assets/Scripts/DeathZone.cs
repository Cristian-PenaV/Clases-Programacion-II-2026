using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Aquí puedes agregar la lógica para manejar la muerte del jugador
            Debug.Log("El jugador ha muerto al entrar en la zona de muerte.");
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(999); // Resta toda la vida del jugador
            }
        }
    }
}
