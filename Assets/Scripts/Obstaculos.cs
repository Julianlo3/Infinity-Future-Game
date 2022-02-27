using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject Policia;
    public GameObject Nave;
    public List<GameObject> Naves;
    public FondosManager fondo;
    public List<GameObject> Policias;
    public bool policiaNuevo;
    public int numeroPolicia;
    public int velocidadObstaculo;
    void Start()
    {
        velocidadObstaculo = 2;
        numeroPolicia = 0;
        policiaNuevo = true;
       
    }
    void Update()
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
                    Invoke("enfriamiento", 20f);
                }

                if (fondo.Fondo1 == null)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        Naves.Add(Instantiate(Nave, new Vector2(12 + i, 6), Quaternion.identity));
                        numeroPolicia += 1;
                        policiaNuevo = false;
                        Invoke("enfriamiento", 20f);
                    }
                }
            }

            //Policias
            for (int i = 0; i < Policias.Count; i++)
            {
                if (Policias[i].transform.position.x <= -15)
                {

                    float randomx = Random.Range(11, 18);
                    float randomy = Random.Range(-4, 5);
                    Policias[i].transform.position = new Vector3(randomx, randomy, -2);
                }
                Policias[i].transform.position = Policias[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidadObstaculo;
            }
            // Naves
            for (int i = 0; i < Naves.Count; i++)
            {
                if (Naves[i].transform.position.x <= -15)
                {

                    float randomx = Random.Range(11, 18);
                    float randomy = Random.Range(-4, 5);
                    Naves[i].transform.position = new Vector3(randomx, randomy, -2);
                }
                Naves[i].transform.position = Naves[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidadObstaculo;
            }
        }
    }

    void enfriamiento()
    {
        policiaNuevo = true;
    }


}
