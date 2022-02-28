using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barril : MonoBehaviour
{
    public GameObject Barrill;
    public GameManager gameManager;
    public List<GameObject> Barriles;
    private Rigidbody2D rigidbody2D; // variable para las fisicas del personaje
    private Animator animator; // variable para controlar la animacion
    public bool barrilNuevo;
    public int numeroBarril;

    void Start()
    {
      numeroBarril = 0;
      barrilNuevo = true;
        Barrill.transform.localScale = new Vector2(2, 2);
        Barrill.transform.position = new Vector3(9.5f, -4, -1);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (numeroBarril > 5)
        {
            barrilNuevo = false;
        }


        if (gameManager.start == true && gameManager.gameOver == false)
        {
            if (barrilNuevo == true)
            {
                for (int i = 0; i < 1; i++)
                {
                    Barriles.Add(Instantiate(Barrill, new Vector3(12 + i, 6,-2), Quaternion.identity));
                    numeroBarril += 1;
                    barrilNuevo = false;
                    Invoke("enfriamiento", 30f);
                }
            }
        }
        for (int i = 0; i < Barriles.Count; i++)
        {
            if (Barriles[i].transform.position.x <= -9.5f)
            {
                Barriles[i].transform.position = new Vector3(9.5f, -4, -2);
            }
            Barriles[i].transform.position = Barriles[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * gameManager.velociadObstaculo;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("Tocando", true);
            Destroy(Barrill, 1);
        }
    }

    void enfriamiento()
    {
        barrilNuevo = true;
    }
}
