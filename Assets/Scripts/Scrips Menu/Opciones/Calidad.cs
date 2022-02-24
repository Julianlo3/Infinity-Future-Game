using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calidad : MonoBehaviour
{

    public TMP_Dropdown dropdown;
    public int calidad;

    void Start()
    {

        calidad = PlayerPrefs.GetInt("numeroDeCalidad", 3);
        dropdown.value = calidad;
        ajustarCalidad();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ajustarCalidad()
    {

        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("numeroDeCalidad", dropdown.value);
        calidad = dropdown.value;

    }

}
