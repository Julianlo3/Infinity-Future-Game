using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject ParedObjeto;
    public bool PasarPared;
    public int parar;
    public int posicion;
    public int pasarPared;
    void Start()
    {
        parar = 1;
        PasarPared = true;
        ParedObjeto.transform.localScale = new Vector2(1, 1);
        ParedObjeto.transform.position = new Vector3(15, 0, -2);
        pasarPared = Random.Range(10, 15);
        posicion = Random.Range(1, 4);
    }


    void Update()
    {

        ParedObjeto.transform.position = ParedObjeto.transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * gameManager.velociadObstaculo * parar;

        switch (posicion)
        {
            case 1:
                parar = 1;
                ParedObjeto.transform.position = new Vector3(12, 1, -2);
                posicion = 0;
                    break;
                
                case 2:
                parar = 1;

                ParedObjeto.transform.position = new Vector3(12, -2, -2);
                posicion = 0;
                break;
                

            case 3:
                parar = 1;
                ParedObjeto.transform.position = new Vector3(12, -4.5f, -2);
                posicion = 0;
                break;
                
        }

        if(ParedObjeto.transform.position.x <= -9.5f)
        {
            parar = 0;
        }
        
        //-------------- P A R E D --------------------
        if (PasarPared == true)
        {
            
            for (int i = 0; i < 1; i++)
            {
                if (ParedObjeto.transform.position.x <= -9.5f)
                {
                    ParedObjeto.transform.position = new Vector3(12, 0, -2);
                }
            }
            PasarPared = false;
            Invoke("enfriamiento", pasarPared);
        }
        //----------------------------------------------
    }
    void enfriamiento()
    {
        PasarPared = true;
        pasarPared = Random.Range(10, 15);
        posicion = Random.Range(1, 4);

    }



}
