using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoManager : MonoBehaviour
{
    public Renderer Fondo;
    public float velocidadFondo;
    public GameObject Suelo;
    public List<GameObject> Suelos;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            Suelos.Add(Instantiate(Suelo, new Vector2(-4 + i, -5), Quaternion.identity));
        }
        velocidadFondo = 0.09f;
    }

    // Update is called once per frame
    void Update()
    {
        Fondo.material.mainTextureOffset = Fondo.material.mainTextureOffset + new Vector2(velocidadFondo, 0) * Time.deltaTime;

        for (int i = 0; i < Suelos.Count; i++)
        {
            if (Suelos[i].transform.position.x <= -10)
            {
                Suelos[i].transform.position = new Vector3(10, -5, 0);
            }
            Suelos[i].transform.position = Suelos[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * 2;
        }
    }
}
