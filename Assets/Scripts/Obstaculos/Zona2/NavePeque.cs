using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavePeque : MonoBehaviour
{
    private Animator animator;
    public GameManager gameManager;
    public FondosManager fondoManager;
    public GameObject navePeque;
    public List<GameObject> Naves;
    public bool naveNueva;
    public int numeroNaves;
    void Start()
    {
        numeroNaves = 0;
        naveNueva = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Naves.Count == 3)
        {
            naveNueva = false;
        }


        if (fondoManager.SeleccionFondo == 2)
        {
            if (gameManager.start == true && gameManager.gameOver == false)
            {
                if (naveNueva == true)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        Naves.Add(Instantiate(navePeque, new Vector2(12 + i, 7), Quaternion.identity));
                        numeroNaves += 1;
                        naveNueva = false;
                        Invoke("enfriamiento", 120);
                    }
                }
            }
            for (int i = 0; i < Naves.Count; i++)
            {
                if (Naves[i].transform.position.x <= -15)
                {

                    float randomx = Random.Range(11, 18);
                    float randomy = Random.Range(-4, 3);
                    Naves[i].transform.position = new Vector3(randomx, randomy, -2);
                }
                Naves[i].transform.position = Naves[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * (gameManager.velociadObstaculo + 1);
            }
        }
    }

    void enfriamiento()
    {
        naveNueva = true;
    }
}

