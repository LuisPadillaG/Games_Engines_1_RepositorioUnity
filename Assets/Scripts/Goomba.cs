using UnityEngine;

public class Goomba : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector3 posicion, rotacion;
    float contador;
    bool movimientoDerecha;

    void Start()
    {
        posicion = this.transform.position;
        contador = 0;
        movimientoDerecha = true;
        rotacion = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (movimientoDerecha) {
            posicion.x += Time.deltaTime * 2;
            rotacion.y = 0; 
        }
        else
        {
            posicion.x -= Time.deltaTime * 2;
            rotacion.y = 180;
        }
        contador += Time.deltaTime;
        if (contador > 2) {
            if (movimientoDerecha)
            {
                movimientoDerecha = false;

            }
            else
            {
                movimientoDerecha = true;
            }
            contador = 0;
        }
        
        this.transform.position = posicion;
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(rotacion), Time.deltaTime * 600);
    }
    
}
