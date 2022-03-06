using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrilAnimacion : MonoBehaviour
{
    private Animator animator;
    public GameObject barril;
    void Start()
    {
        barril.transform.localScale = new Vector2(1, 1);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("Tocando", true);
            Destroy(barril, 1);
        }
    }
}
