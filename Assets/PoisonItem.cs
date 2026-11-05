using UnityEngine;

public class PoisonItem : MonoBehaviour
{
    public int poisonAmount = 2;

    private void Start()
    {
        if (poisonAmount > 0) poisonAmount = -poisonAmount;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerStats stats = col.GetComponent<PlayerStats>();
            if (stats != null)
            {
                stats.SetHealth(poisonAmount);
                // o .restaurarvida(2) 
                Destroy(gameObject);
            }
        }
    }
}
