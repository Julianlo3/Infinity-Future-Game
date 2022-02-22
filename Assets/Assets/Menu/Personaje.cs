using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    private Animator animator;
    Vector3 posicionInicial;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = (new Vector3(-2, -4, -2));
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 
}
