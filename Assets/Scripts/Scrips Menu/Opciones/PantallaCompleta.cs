using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PantallaCompleta : MonoBehaviour
{

    public Toggle toogle;

    void Start()
    {

        if (Screen.fullScreen)
        {
            toogle.isOn = true;
        }
        else
        {
            toogle.isOn = false;
        }
        
    }


    void Update()
    {
        
    }

    public void ActivarPantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

}
