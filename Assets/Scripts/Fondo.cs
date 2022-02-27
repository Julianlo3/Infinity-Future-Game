using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{
    public Puntuacion puntuacion;
    public GameObject Tunel; // Tunel
    public Renderer Fondo1; // La  variable que se usa para manejar el fondo
    public float velocidadFondo;
    public Renderer Fondo2;

    void Start()
    {
        Tunel.transform.localScale = new Vector2(1, 1);
        Tunel.transform.position = new Vector3(19, -1.13f, -1);
        Fondo2.transform.position = new Vector3(19, -1.13f, -1);
        Fondo1.transform.position = new Vector2(0, 0);
        velocidadFondo = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if ( puntuacion.distancia > 5)
        {
            for (int i = 0; i < 1; i++)
            {
                if (Tunel.transform.position.x <= -18)
                {
                    Tunel.transform.position = new Vector3(19, -1.13f, -1);
                }
                Tunel.transform.position = Tunel.transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidadFondo;
            }
        }
        if(Fondo1 != null)
        {
            Fondo1.material.mainTextureOffset = Fondo1.material.mainTextureOffset + new Vector2(velocidadFondo, 0) * Time.deltaTime * velocidadFondo;
        }

        if (Tunel.transform.position.x <= 0)
        {
            Destroy(Fondo1);
            Fondo2.transform.position = new Vector3(0, 0,0);

        }
        Fondo2.material.mainTextureOffset = Fondo2.material.mainTextureOffset + new Vector2(velocidadFondo, 0) * Time.deltaTime * velocidadFondo;
    }

    


}
