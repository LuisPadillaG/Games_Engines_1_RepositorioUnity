using UnityEngine;
using UnityEngine.SceneManagement;
public class MarioMuerto : MonoBehaviour
{
    Vector3 posicion, velocidad;
    float contador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicion = this.transform.position;
        velocidad = Vector3.zero;
        velocidad.y = 10;
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        posicion.y += velocidad.y * Time.deltaTime;
        velocidad.y -= 20 * Time.deltaTime;
        this.transform.position = posicion;
        contador += Time.deltaTime;
        if (contador > 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
