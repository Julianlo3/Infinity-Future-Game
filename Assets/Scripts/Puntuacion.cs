using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntuacion : MonoBehaviour
{
    public GameManager gameManager;
    public Text score;
    public Text recordJugador;
    public int record;
    public int distancia;
    public bool enfriamientoPuntaje;

    void Start()
    {
        enfriamientoPuntaje=true;
        record = PlayerPrefs.GetInt("GuardarPuntaje"); // guardar puntaje localmente
        distancia = 0;
    }
    void Update()
    {
        if (gameManager.gameOver == true)
        {
            Destroy(gameObject);
        }
        //----------- metodo para guardar el puntaje mayor -----------------
        if (distancia > record)
        {
            record = distancia;
            PlayerPrefs.SetInt("GuardarPuntaje", record);
        }
        //------------------------------------------------

        recordJugador.text = "Record" + record; // Texto para mostrarlo en el juego
        score.text = "Puntaje " + distancia; // Texto para mostrarlo en el juego

        //------------------ suma de puntaje -------------

        if (gameManager.start == true && gameManager.gameOver == false)
        {
            if (enfriamientoPuntaje == true)
            {
                distancia++;
                enfriamientoPuntaje = false;
                Invoke("enfriamiento", 0.2f);
            }
        }
        //------------------------------------------------
    }
    // ------ metodo de enfriamiento ------
    void enfriamiento()
    {
        enfriamientoPuntaje = true;
    }
    //--------------------------------------
}
