using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    // Variables públicas para cambiarlas fácilmente desde el Inspector
    public int life = 3;
    public int damage = 1;
    [SerializeField] private GameObject coinPrefab;
    private bool isDead = false;

    // Función que llamaremos cuando el jugador ataque a este enemigo
    public void TakeDamage(int cantidad)
    {
        life -= cantidad; // Restamos la vida

        // Comprobamos si el enemigo se quedó sin vida
        if (life <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (!isDead)
        {
            isDead = true;

            if (coinPrefab != null)
            {
                Instantiate(coinPrefab, transform.position + Vector3.right * 0.5f, Quaternion.identity);
            }

            Destroy(gameObject, 2f); // Destruye el objeto después de 2 segundos
        }
    }

    // Usamos las colisiones físicas de Unity para lastimar al jugador
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si el objeto con el que chocamos tiene la etiqueta "Player" (Jugador)
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("¡Enemigo tocó al jugador! " + damage + " de daño.");

            PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(damage); // Llamamos a la función TakeDamage del jugador
            }
        }
    }
}
