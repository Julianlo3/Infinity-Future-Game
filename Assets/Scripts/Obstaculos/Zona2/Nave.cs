using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject NaveCiudad;
    public List<GameObject> Naves;
    public bool naveNueva;
    public int numeroNaves;
    void Start()
    {
        numeroNaves = 0;
        naveNueva = true;
    }

    void Update()
    {
        if (gameManager.start == true && gameManager.gameOver == false)
        {
            if (naveNueva == true)
            {
                for (int i = 0; i < 1; i++)
                {
                    Naves.Add(Instantiate(NaveCiudad, new Vector2(12 + i, 6), Quaternion.identity));
                    numeroNaves += 1;
                    naveNueva = false;
                    Invoke("enfriamiento", 20f);
                }
            }
        }
        for (int i = 0; i < Naves.Count; i++)
        {
            if (Naves[i].transform.position.x <= -15)
            {

                float randomx = Random.Range(11, 18);
                float randomy = Random.Range(-4, 5);
                Naves[i].transform.position = new Vector3(randomx, randomy, -2);
            }
            Naves[i].transform.position = Naves[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * gameManager.velocidad;
        }
    }

    void enfriamiento()
    {
        naveNueva = true;
    }
}
