using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavePolicia : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject Policia;
    public FondosManager fondosManager;
    public List<GameObject> Policias;
    public bool policiaNuevo;
    public int numeroPolicia;
    void Start()
    {
        numeroPolicia = 0;
        policiaNuevo = true;
    }

    void Update()
    {
        if(Policias.Count == 3)
        {
            policiaNuevo = false;
        }


        if (fondosManager.SeleccionFondo == 1)
        {
            if (gameManager.start == true && gameManager.gameOver == false)
            {
                if (policiaNuevo == true)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        Policias.Add(Instantiate(Policia, new Vector2(12 + i, 6), Quaternion.identity));
                        numeroPolicia += 1;
                        policiaNuevo = false;
                        Invoke("enfriamiento", 80);
                    }
                }
            }
            for (int i = 0; i < Policias.Count; i++)
            {
                if (Policias[i].transform.position.x <= -15)
                {

                    float randomx = Random.Range(11, 18);
                    float randomy = Random.Range(-4, 5);
                    Policias[i].transform.position = new Vector3(randomx, randomy, -2);
                }
                Policias[i].transform.position = Policias[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * gameManager.velociadObstaculo;
            }
        }
            
    }

    void enfriamiento()
    {
        policiaNuevo = true;
    }


}
