using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
	//--------------------
	public Escenario escenario;
	public GameObject Muerte;
	public GameObject MenuGameOver;
	public bool enfriamientoVelocidad =true;
	public bool gameOver = false;
	public bool start = false;
	public float velocidadFondo;
	public float velocidadSuelo;
	public float velociadObstaculo;
	//----------------------
    void Start()
	{
		velocidadFondo = 0.3f;
		velocidadSuelo = 1;
		velociadObstaculo = 1;
		MenuGameOver.SetActive(false);
		start = true;
		gameOver = false;
		Muerte.transform.position = new Vector2(0, -7f);
	}

	// Update is called once per frame
	void Update()
	{
        if (enfriamientoVelocidad == true)
        {
			velocidadFondo += 0.03f;
			velocidadSuelo += 1;
			velociadObstaculo += 1;
			enfriamientoVelocidad = false;
			Invoke("enfriamiento", 10f);

		}
		if (gameOver == true)
		{
			MenuGameOver.SetActive(true);
			if (Input.GetKeyDown(KeyCode.X))
			{
				Destroy(gameObject);
				SceneManager.LoadScene(1);
			}
		}

	}

	void enfriamiento()
	{
		enfriamientoVelocidad = true;
	}

}
