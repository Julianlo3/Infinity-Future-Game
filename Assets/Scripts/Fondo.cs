using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{
    public Puntuacion puntuacion;
    public GameObject Tunel;
    void Start()
    {
        Tunel.transform.localScale = new Vector2(1, 1);
        Tunel.transform.position = new Vector3(19, -1.13f, -1);
        
    }
    void Update()
    {
        if (puntuacion.distancia > 30)
        {
            for (int i = 0; i < 1; i++)
            {
                if (Tunel.transform.position.x <= -18)
                {
                    Tunel.transform.position = new Vector3(19, -1.13f, -1);
                }
                Tunel.transform.position = Tunel.transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * 1;
            }
        }
    }
}
