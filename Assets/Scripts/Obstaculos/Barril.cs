using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barril : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject barril;
    public List<GameObject> Barriles;
    private Rigidbody2D rigidbody2D; // variable para las fisicas del personaje
    private Animator animator; // variable para controlar la animacion
    public bool barrilNuevo;
    public int numeroBarril;
    public int i;

    void Start()
    {
      numeroBarril = 0;
      barrilNuevo = true;
        barril.transform.localScale = new Vector2(1, 1);
        barril.transform.position = new Vector3(9.5f, -4, -1);
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {

        if(gameManager.gameOver == false)
        {
            if (Barriles.Count > 5)
            {
                barrilNuevo = false;
            }
            if (barrilNuevo == true)
            {
                for (i = 0; i < 1; i++)
                {
                    barril.transform.localScale = new Vector2(1, 1);
                    Barriles.Add(Instantiate(barril, new Vector2(12 + i, 6), Quaternion.identity));
                    barrilNuevo = false;
                    Invoke("enfriamiento", 10);
                }
            }

            for (int i = 0; i < Barriles.Count; i++)
            {
                if (Barriles[i].transform.position.x <= -9.5f)
                {
                    Barriles[i].transform.position = new Vector3(9.5f, -4, -2);
                }
                Barriles[i].transform.position = Barriles[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * 1;
            }
        }

        

    }
    void enfriamiento()
    {
        barrilNuevo = true;
    }
}
