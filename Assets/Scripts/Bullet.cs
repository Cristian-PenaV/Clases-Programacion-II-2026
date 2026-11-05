using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Configuración de la Bala")]
    public float speed = 15f;          // Velocidad del proyectil
    public int damageAmount = 10;     // Daño que inflige
    public float lifeTime = 5f;        // Tiempo máximo de vida

    private void Start()
    {
        // Se destruye automáticamente tras pasar el tiempo de vida
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        // Avanza en la dirección hacia la que apunta la bala (eje X local / derecha)
        // Como fue instanciada con 'shootPoint.rotation', 'transform.right' apunta hacia donde se disparó.
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si colisionó con un objeto con Tag "Enemy"
        if (collision.CompareTag("Enemy"))
        {
            // Intenta obtener el script EnemyBase
            EnemyBase enemy = collision.GetComponent<EnemyBase>();

            if (enemy != null)
            {
                // Aplica el daño invocando TakeDamage
                enemy.TakeDamage(damageAmount);
            }

            // Destruye la bala al impactar
            Destroy(gameObject);
        }
    }
}