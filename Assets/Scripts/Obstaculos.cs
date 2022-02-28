using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{
    public GameManager gameManager;
    public Puntuacion puntuacion;
    public GameObject Tunel;
    public bool PasarTunel = true;
    private int parar;
    
    void Start()
    {
        parar = 1;
        Tunel.transform.localScale = new Vector2(1, 1);
        Tunel.transform.position = new Vector3(19, -1.13f, -1);

    }


    void Update()
    {
        Tunel.transform.position = Tunel.transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * gameManager.velociadObstaculo * parar;
        if(Tunel.transform.position.x <= -20)
        {
            parar = 0;
        }
        else
        {
            parar = 1;
        }
        
        //-------------- T U N E L --------------------
        if (PasarTunel == true)
        {
            for (int i = 0; i < 1; i++)
            {
                if (Tunel.transform.position.x <= -18)
                {
                    Tunel.transform.position = new Vector3(19, -1.13f, -1);
                }
            }
            PasarTunel = false;
            Invoke("enfriamiento", 20);
        }
        //----------------------------------------------
    }
    void enfriamiento()
    {
        PasarTunel = true;
    }



}
