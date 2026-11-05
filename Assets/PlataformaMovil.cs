using UnityEngine;
public class PlataformaMovil : MonoBehaviour
{
    [Header("Configuración de Puntos")] public Transform puntoA;
    public Transform puntoB;
    [Header("Parámetros de Movimiento")] public float velocidad = 2f;
    private Transform destinoActual;
    void Start()
    {
        // Establecemos el punto B como el primer objetivo al iniciar el juego 
        destinoActual = puntoB;
    }
    void Update()
    {
        // Desplazamos el objeto suavemente hacia el destino actual 
        transform.position = Vector3.MoveTowards(transform.position, destinoActual.position, velocidad * Time.deltaTime);
        // Si la distancia al destino es casi cero, alternamos el objetivo entre A y B 
        if (Vector3.Distance(transform.position, destinoActual.position) < 0.1f)
        {
            destinoActual = (destinoActual == puntoA) ? puntoB : puntoA;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        // Si el jugador se para sobre la plataforma, se convierte en su hijo
        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        // Al saltar o bajarse de la plataforma, recupera su independencia
        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.SetParent(null);
        }
    }

}
