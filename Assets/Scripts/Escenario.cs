using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escenario : MonoBehaviour
{
    public float velocidadSuelo;
    public GameObject Suelo;
    public GameObject Techo;
    public List<GameObject> Suelos;
    public bool Hueco = true;
    public bool tiempoSuelo = true;
    public int XSuelo;
    public int randoms;
    public bool subirVelocidad;

    void Start()
    {
        subirVelocidad = true;
        Techo.transform.position = new Vector2(-4.7f, -3.3f);
        XSuelo = -5;
        velocidadSuelo = 7;
        // crear suelo
        for (int i = 0; i < 21; i++)
        {
            Suelos.Add(Instantiate(Suelo, new Vector2(-10 + i, -5), Quaternion.identity));
        }
    }

    void Update()
    {
        if (Hueco == true)
        {
            randoms = Random.Range(1, 3);
            Hueco = false;
            Invoke("enfriamiento4", 5f);
        }

        if (randoms == 1)
        {
            XSuelo = -5;
        }
        else if (randoms == 2)
        {
            XSuelo = -8;
        }

        if (subirVelocidad == true)
        {
            velocidadSuelo += 0.2f;

            subirVelocidad = false;
            Invoke("enfriamiento3", 5f);
        }

        // mover suelo

        for (int i = 0; i < Suelos.Count; i++)
        {
            if (Suelos[i].transform.position.x <= -10)
            {
                Suelos[i].transform.position = new Vector3(10, XSuelo, 0);
            }
            Suelos[i].transform.position = Suelos[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * 2;
        }

       

    }
    void enfriamiento2()
    {
        tiempoSuelo = true;
    }

    void enfriamiento3()
    {
        subirVelocidad = true;
    }

    void enfriamiento4()
    {
        Hueco = true;
    }


}
