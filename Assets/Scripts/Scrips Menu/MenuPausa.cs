using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Puntaje;


    private bool juegoPausado = false;

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Continuar();
            }
            else
            {
                Pausa();
            }
        }

    }
    public void Pausa()
    {

        juegoPausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        Puntaje.SetActive(false);
        Menu.SetActive(true);

    }

    public void Continuar()
    {

        juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        Puntaje.SetActive(true);
        Menu.SetActive(false);

    }

    public void Reiniciar()
    {

        juegoPausado = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);

    }

    public void Salir()
    {

        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }

}
