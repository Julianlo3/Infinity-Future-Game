using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondosManager : MonoBehaviour
{
    public GameManager gameManager;
    public int SeleccionFondo;
    public bool cambiarFondo1;
    public bool cambiarFondo2;
    public GameObject Fondo1;
    public GameObject Fondo2;
    public GameObject Fondo3;
    public Renderer FondoMover1; 
    public Renderer FondoMover2;
    public Renderer FondoMover3;
    void Start()
    {
        SeleccionFondo = Random.Range(1, 3);
    }
    void Update()
    {
        switch (SeleccionFondo)
        {
            case 1:
                {
                    Fondo1.transform.localScale = new Vector2(18, 10);
                    Fondo1.SetActive(true);
                    Fondo2.SetActive(false);
                    Fondo3.SetActive(false);
                    Fondo1.transform.position = new Vector2(0, 0);
                    FondoMover1.material.mainTextureOffset = FondoMover1.material.mainTextureOffset + new Vector2(gameManager.velocidadFondo, 0) * Time.deltaTime * gameManager.velocidadFondo;
                    break;
                }
            case 2:
                {
                    Fondo2.transform.localScale = new Vector2(18, 10);
                    Fondo1.SetActive(false);
                    Fondo2.SetActive(true);
                    Fondo3.SetActive(false);
                    Fondo2.transform.position = new Vector2(0, 0);
                    FondoMover2.material.mainTextureOffset = FondoMover2.material.mainTextureOffset + new Vector2(gameManager.velocidadFondo, 0) * Time.deltaTime * gameManager.velocidadFondo;
                    break;
                }
            case 3:
                {
                    Fondo3.transform.localScale = new Vector2(18, 10);
                    Fondo1.SetActive(false);
                    Fondo2.SetActive(false);
                    Fondo3.SetActive(true);
                    Fondo3.transform.position = new Vector2(0, 0);
                    FondoMover3.material.mainTextureOffset = FondoMover3.material.mainTextureOffset + new Vector2(gameManager.velocidadFondo, 0) * Time.deltaTime * gameManager.velocidadFondo;
                    break;
                }
        }
    }
}
