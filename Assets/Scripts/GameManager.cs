using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //--------------------
    public Renderer Fondo; // La  variable que se usa para manejar el fondo
    public float velocidadFondo;
    public GameObject Suelo;
    public GameObject Techo;
    public List<GameObject> Suelos;
    public List<GameObject> Techos;
    //----------------------
    // Start is called before the first frame update
    void Start()
    {
        // crear suelo
        for (int i = 0; i < 21; i++)
        {
            Suelos.Add(Instantiate(Suelo, new Vector2(-10 + i, -5), Quaternion.identity));
        }
        // crear techo
        for (int i = 0; i < 2; i++)
        {
            Techos.Add(Instantiate(Techo, new Vector2(0.5f + i, 8.5f), Quaternion.identity));
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fondo.material.mainTextureOffset = Fondo.material.mainTextureOffset + new Vector2(velocidadFondo, 0) * Time.deltaTime;

        // mover mapa
        for (int i = 0; i < Suelos.Count; i++)
        {
            if (Suelos[i].transform.position.x <= -10)
            {
                Suelos[i].transform.position = new Vector3(10, -5, 0);
            }
            Suelos[i].transform.position = Suelos[i].transform.position + new Vector3(-1,0,0) * Time.deltaTime * 2;
        }
        for (int i = 0; i < Techos.Count; i++)
        {
            if (Techos[i].transform.position.x <= -3)
            {
                Techos[i].transform.position = new Vector3(0.5f, 8.5f, 0);
            }
            Techos[i].transform.position = Techos[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * 2;
        }


    }
}
