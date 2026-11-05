using System.Collections;
using UnityEngine;

public class NitroItem : MonoBehaviour
{
    public float speedBoost = 2f;
    public float boostDuration = 5f;

    private bool collected = false; // Evita que se active dos veces en el mismo frame

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !collected)
        {
            PlayerController mov = col.GetComponent<PlayerController>();

            if (mov != null)
            {
                collected = true;

                // Ejecutamos la corutina en el Player para que no se interrumpa
                // cuando este objeto NitroItem sea destruido.
                mov.StartCoroutine(BoostRoutine(mov, boostDuration));

                // Desactivamos la imagen y la colisión del ítem inmediatamente
                GetComponent<Collider2D>().enabled = false;

                SpriteRenderer sprite = GetComponent<SpriteRenderer>();
                if (sprite != null)
                {
                    sprite.enabled = false;
                }

                // Destruimos el objeto del ítem en la escena
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator BoostRoutine(PlayerController mov, float time)
    {
        // 1. Aumenta la velocidad
        mov.speed += speedBoost;

        // 2. Espera la duración indicada
        yield return new WaitForSeconds(time);

        // 3. Restaura la velocidad original
        mov.speed -= speedBoost;
    }
}