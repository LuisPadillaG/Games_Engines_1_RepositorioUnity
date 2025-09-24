using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject Jugador;
    Vector3 posicion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicion = Jugador.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Movimiento de todo y salto
        //this.transform.position = Jugador.transform.position;

        if (Jugador != null) {
            posicion.x = Jugador.transform.position.x;
            this.transform.position = posicion;
        }

        // cuando el jugador deja de existir, pasa a ser nulo
    }
}
