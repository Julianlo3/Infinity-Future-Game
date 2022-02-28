using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escenario : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject Suelo;
    public GameObject Techo;
    public GameObject Limite;
    public GameObject Limite1;
    public List<GameObject> Suelos;
    public bool Hueco = true;
    public bool tiempoSuelo = true;
    public int XSuelo;
    public int randoms;

    void Start()
    {
        Techo.transform.position = new Vector2(-4.4f, 5.5f);
        Limite1.transform.localScale = new Vector2(1, 3);
        Limite.transform.position = new Vector2(-10.5f, 0);
        Limite1.transform.localScale = new Vector2(1,10);
        Limite1.transform.localScale = new Vector2(8, -6);
        XSuelo = -5;
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


        // mover suelo

        for (int i = 0; i < Suelos.Count; i++)
        {
            if (Suelos[i].transform.position.x <= -10)
            {
                Suelos[i].transform.position = new Vector3(10, XSuelo, 0);
            }
            Suelos[i].transform.position = Suelos[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * gameManager.velocidadSuelo;
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
