using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajePrincipal : MonoBehaviour
{
    public float velocidad; // variable para ponerle velocidad al personaje
    public float direccionX; // variable para usar el método para que el personaje se mueva en el eje X
    private Rigidbody2D rigidbody2D; // variable para las fisicas del personaje
    private Animator animator; // variable para controlar la animacion
    public float fuerzaSalto; // variable para la fuerza del salto

    void Start()
    {
        velocidad = 0.1f;// se inicializa la velocidad al iniciar el juego
        fuerzaSalto = 150; 
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transform.position=(new Vector3(-7.64f, -3.36f, 0));
    }

   
    void Update()
    {
       // direccionX = Input.GetAxis("Horizontal");

        // transform.position += new Vector3(direccionX * velocidad, 0, 0); //método para que el personaje se mueva
        //transform.Translate(Vector3.right * direccionX * velocidad); // método para que el personaje se mueva

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
            animator.SetBool("AccionSaltar", true);
            
        }
    }

    public void Saltar()
    {
        rigidbody2D.AddForce(Vector2.up * fuerzaSalto);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            animator.SetBool("AccionSaltar", false);
        }
    }

}
