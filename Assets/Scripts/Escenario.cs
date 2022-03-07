using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escenario : MonoBehaviour
{
    public GameManager gameManager;
    public Puntuacion puntuacion;
    public GameObject Bandera;
    public FondosManager fondosManager;
    public GameObject Suelo;
    public GameObject Suelo2;
    public GameObject Suelo3;
    public GameObject Techo;
    public GameObject Limite;
    public GameObject Limite1;
    public List<GameObject> Suelos;
    public List<GameObject> Suelos2;
    public List<GameObject> Suelos3;
    public bool Hueco = true;
    public bool tiempoSuelo = true;
    public int YSuelo;
    public int randoms;
    public bool nuevoRecord;
    public int parar;
    void Start()
    {
        parar = 0;
        nuevoRecord = false;
        Bandera.transform.position = new Vector3(12, 5);
        Techo.transform.position = new Vector2(-4.4f, 5.5f);
        Limite1.transform.localScale = new Vector2(1, 3);
        Limite.transform.position = new Vector2(-10.5f, 0);
        Limite1.transform.localScale = new Vector2(1,10);
        Limite1.transform.localScale = new Vector2(8, -6);
        YSuelo = -5;
    }
    void Update()
    {
        if(fondosManager.SeleccionFondo == 1)
        {
            if(Suelos.Count < 21)
            {
                for (int i = 0; i < 21; i++)
                {
                    Suelos.Add(Instantiate(Suelo, new Vector2(-10 + i, -5), Quaternion.identity));
                }
            }


            for (int i = 0; i < Suelos.Count; i++)
            {
                if (Suelos[i].transform.position.x <= -10)
                {
                    Suelos[i].transform.position = new Vector3(10, YSuelo, 0);
                }
                Suelos[i].transform.position = Suelos[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * gameManager.velocidadSuelo;
            }

        }
        if (fondosManager.SeleccionFondo == 2)
        {
            if (Suelos2.Count < 21)
            {
                for (int i = 0; i < 21; i++)
                {
                    Suelos2.Add(Instantiate(Suelo2, new Vector2(-10 + i, -5), Quaternion.identity));
                }
            }
            for (int i = 0; i < Suelos2.Count; i++)
            {
                if (Suelos2[i].transform.position.x <= -10)
                {
                    Suelos2[i].transform.position = new Vector3(10, YSuelo, 0);
                }
                Suelos2[i].transform.position = Suelos2[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * gameManager.velocidadSuelo;
            }
        }
        if (fondosManager.SeleccionFondo == 3)
        {
            if (Suelos3.Count < 5)
            {

                for (float i = 0; i < 24;)
                {
                    Suelos3.Add(Instantiate(Suelo3, new Vector2(-6.5f + i, -5), Quaternion.identity));
                    i += 4.8f;
                }
            }

            for (int i = 0; i < Suelos3.Count; i++)
            {
                if (Suelos3[i].transform.position.x <= -11.5)
                {
                    Suelos3[i].transform.position = new Vector3(12, YSuelo, 0);
                }
                Suelos3[i].transform.position = Suelos3[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * gameManager.velocidadSuelo;
            }
        }

    

        if(puntuacion.distancia == puntuacion.record - 20)
        {
            Bandera.transform.position = new Vector3(10, 0, -2);
            parar = 1;
        }

        Bandera.transform.position = Bandera.transform.position + new Vector3((gameManager.velocidadSuelo*-1), 0, 0) * Time.deltaTime * 1.2f * parar;

        if ( Bandera.transform.position.x < -10)
        {
            parar = 0;        }



        if (Hueco == true)
        {
            randoms = Random.Range(1, 3);
            Hueco = false;
            Invoke("enfriamiento4", 5f);
        }

        if (randoms == 1)
        {
            YSuelo = -5;
        }
        else if (randoms == 2)
        {
            YSuelo = -8;
        }

    }
    void enfriamiento2()
    {
        tiempoSuelo = true;
    }


    void enfriamiento4()
    {
        Hueco = true;
    }


}
