using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajePrincipal : MonoBehaviour
{
    private Rigidbody2D rigidbody2D; // variable para las fisicas del personaje
    private Animator animator; // variable para controlar la animacion
    public float fuerzaSalto; // variable para la fuerza del salto
    public float speed;
    public float dirX;
    public GameManager gameManager;
    Vector3 posicionInicial;

    void Start()
    {
        speed = 0.2f;
        fuerzaSalto = 8;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transform.position = (new Vector3(-7.64f, -3.36f, -2));
    }


    void Update()
    {

        if (gameManager.gameOver == true && Input.GetKeyDown(KeyCode.X))
        {
            Destroy(gameObject);
        }


        if (Input.GetButton("Jump") &&  gameManager.gameOver == false)
        {
            Saltar();
            animator.SetBool("AccionSaltar", true);
            animator.SetBool("EnSuelo", false);
            animator.SetBool("Volando", true);
        }
        else
        {
            animator.SetBool("AccionSaltar", false);
            animator.SetBool("Volando",false);
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
            animator.SetBool("EnSuelo", true);
        }
        if (collision.gameObject.tag == "Obstaculo")
        {
            gameManager.gameOver = true;
            animator.SetBool("Muerte", true);
        }
    }

    public Vector3 getPosicion()
    {
        return posicionInicial;
    }
}
