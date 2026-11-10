using UnityEngine;

public class ItemHealth : MonoBehaviour
{
    public int healAmount = 2;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerStats stats = col.GetComponent<PlayerStats>();
            if (stats != null)
            {
                stats.SetHealth(healAmount);
                // o .restaurarvida(2) 
                Destroy(gameObject);
            }
        }
    }
}
