using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntuacion : MonoBehaviour
{
    public GameManager gameManager;
    public Text score;
    public Text recordJugador;
    public Text recordNuevo;
    public int record;
    public int distancia;
    public bool enfriamientoPuntaje;
    public AudioSource audio;

    void Start()
    {
        audio.Stop();
        enfriamientoPuntaje=true;
        record = PlayerPrefs.GetInt("GuardarPuntaje"); // guardar puntaje localmente
        distancia = 0;
    }
    void Update()
    {
        //----------- metodo para guardar el puntaje mayor -----------------
        if (distancia > record)
        {
            
            record = distancia;
            PlayerPrefs.SetInt("GuardarPuntaje", record);
        }

        if( distancia == record-1 )
        {
            audio.Play();
        }
        //------------------------------------------------

        recordJugador.text = "Record" + " "+record; // Texto para mostrarlo en el juego
        score.text = "Puntaje " +  distancia; // Texto para mostrarlo en el juego
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
        if( gameManager.gameOver == true)
        {
            if (distancia == record)
            {
                recordNuevo.text = "¡¡ NUEVO RECORD !!" + " " + record;
            }
        }


    }
    // ------ metodo de enfriamiento ------
    void enfriamiento()
    {
        enfriamientoPuntaje = true;
    }
    //--------------------------------------
}
