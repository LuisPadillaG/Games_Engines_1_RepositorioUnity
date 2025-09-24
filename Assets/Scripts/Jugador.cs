using UnityEngine;
using UnityEngine.InputSystem;

public class Jugador : MonoBehaviour
{ 
    CharacterController componenteCharacterController;
    Vector3 velocidad;
    Vector3 rotacion;
    bool dobleSalto;

    public Animator componenteAnimator;

    public GameObject objetoManejadorUI;
    ManejadorUI scriptManejadorUI;

    public GameObject prefabMarioMuerto;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
        scriptManejadorUI = objetoManejadorUI.GetComponent<ManejadorUI>();
        componenteCharacterController = this.GetComponent<CharacterController>();
        velocidad = Vector3.zero;
        rotacion = Vector3.zero;
        dobleSalto = true;
        componenteAnimator.SetInteger("Estado", 0);
        /*velocidad.y = -10;
        componenteCharacterController.Move(velocidad);*/

        //Gamepad.current.SetMotorSpeeds(0.1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetAxis("Horizontal"));
        /*if (!componenteCharacterController.isGrounded)
        {

            velocidad.y -= 20 * Time.deltaTime;
        }
        else
        {
            velocidad.y = 0;
        }*/
        //Debug.Log(componenteCharacterController.isGrounded);
        velocidad.x = 0;

        if (componenteCharacterController.isGrounded) // cuando estoy en el suelo
        {
            dobleSalto = true;
            //velocidad.y = -1f;
            if (Input.GetButtonDown("Jump"))
            {
                componenteAnimator.SetInteger("Estado", 2);
                velocidad.y = 10;
            }
        }
        else // Cuando estoy en el aire
        {
            Debug.Log(Input.GetButtonDown("Jump"));
            velocidad.y -= 20 * Time.deltaTime;
            if (Input.GetButtonDown("Jump"))
            {
                if (dobleSalto)
                {
                    componenteAnimator.SetInteger("Estado", 2);
                    velocidad.y = 10;
                    dobleSalto = false;
                }
            } 
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            
            velocidad.x = Input.GetAxisRaw("Horizontal") * 5;
            //rotacion.y = 0;
            if(Input.GetAxisRaw("Horizontal") < 0)
            {
                rotacion.y = 180;
            }
            else
            {
                rotacion.y = 0;
            }
            componenteAnimator.SetInteger("Estado", 1);
        }
        else { 
            componenteAnimator.SetInteger("Estado", 0);
        }
        if (!componenteCharacterController.isGrounded)
        {
            componenteAnimator.SetInteger("Estado", 2);
        }

        componenteCharacterController.Move(velocidad * Time.deltaTime);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(rotacion), Time.deltaTime * 600);

        //Debug.Log(velocidad);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Moneda")
        {
            scriptManejadorUI.SumarMoneda();
            Destroy(other.gameObject);
            //Debug.Log("Collision " + other.gameObject.name); 
        }

        if (other.gameObject.tag == "Enemigo")
        {
            if (componenteCharacterController.isGrounded)
            {
                Instantiate(prefabMarioMuerto, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            else
            {
                velocidad.y = 10;
                Destroy(other.gameObject);
                return;
            }
        }
    }
}
