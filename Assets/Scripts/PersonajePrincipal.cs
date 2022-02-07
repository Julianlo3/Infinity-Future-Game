using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajePrincipal : MonoBehaviour
{
    public float velocidad; // variable para ponerle velocidad al personaje
    public float direccionX; // variable para usar el método para que el personaje se mueva en el eje X


    // Start is called before the first frame update
    void Start()
    {
       // se inicializa la velocidad al iniciar el juego
    }

    // Update is called once per frame
    void Update()
    {
        direccionX = Input.GetAxis("Horizontal");

        // transform.position += new Vector3(direccionX * velocidad, 0, 0); //método para que el personaje se mueva
        transform.Translate(Vector3.right * direccionX * velocidad); // método para que el personaje se mueva
    }
}
