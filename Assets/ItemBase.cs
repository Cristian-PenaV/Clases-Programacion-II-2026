using UnityEngine;
public class ItemBase : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("¡Ítem base tocado por: " + collision.name);
            Destroy(gameObject); // Elimina el objeto 
        }
    }
}
