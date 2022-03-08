using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveRoja : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject naveroja;
    public FondosManager fondosManager;
    public List<GameObject> naves;
    public bool naveNueva;
    public int numeroNave;
    void Start()
    {
        numeroNave = 0;
        naveNueva = true;
    }

    void Update()
    {
        if (naves.Count == 3)
        {
            naveNueva = false;
        }

        if (fondosManager.SeleccionFondo == 1)
        {
            if (gameManager.start == true && gameManager.gameOver == false)
            {
                if (naveNueva == true)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        naves.Add(Instantiate(naveroja, new Vector2(12 + i, 6.5f), Quaternion.identity));
                        numeroNave += 1;
                        naveNueva = false;
                        Invoke("enfriamiento", 110);
                    }
                }
            }
            for (int i = 0; i < naves.Count; i++)
            {
                if (naves[i].transform.position.x <= -15)
                {

                    float randomx = Random.Range(11, 18);
                    float randomy = Random.Range(-4, 5);
                    naves[i].transform.position = new Vector3(randomx, randomy, -2);
                }
                naves[i].transform.position = naves[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * gameManager.velociadObstaculo;
            }
        }
            
    }

    void enfriamiento()
    {
        naveNueva = true;
    }
}
