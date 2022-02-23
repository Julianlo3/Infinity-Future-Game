using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
	//--------------------
	public Renderer Fondo; // La  variable que se usa para manejar el fondo
	public float velocidadFondo;
	public float velocidadSuelo;
	public GameObject Suelo;
	public GameObject Techo;
	public GameObject Policia;
	public GameObject Muerte;
	public List<GameObject> Suelos;
	public List<GameObject> Techos;
	public List<GameObject> Policias;
	public Text score;
	public bool Hueco = true;
	public GameObject MenuGameOver;
	public bool gameOver = false;
	public bool start = false;
	public double distancia;
	public bool tiempoPuntaje = true;
	public bool tiempoSuelo = true;
	public bool subirVelocidad;
	public int Xcarro;
	public int randoms;


	//----------------------
	// Start is called before the first frame update
	void Start()
	{

		Xcarro = -5;
		subirVelocidad = true;
		velocidadSuelo = 5;
		Muerte.transform.position = new Vector2(-7f, -7f);
		velocidadFondo = 0.3f;
		distancia = 0;
		// crear suelo
		for (int i = 0; i < 21; i++)
		{
			Suelos.Add(Instantiate(Suelo, new Vector2(-10 + i, -5), Quaternion.identity));
		}
		// crear techo
		for (int i = 0; i < 2; i++)
		{
			Techos.Add(Instantiate(Techo, new Vector2(0.5f + i, 8.5f), Quaternion.identity));
		}
		// crear policias
		for (int i = 0; i < 3; i++)
		{
			Policias.Add(Instantiate(Policia, new Vector2(12 + i, 6), Quaternion.identity));
		}
	}

	// Update is called once per frame
	void Update()
	{

		start = true;
		score.text = "Puntaje " + distancia;
		
		if (gameOver == true)
		{
			MenuGameOver.SetActive(true);
			if (Input.GetKeyDown(KeyCode.X))
			{
				SceneManager.LoadScene(1);
			}
		}

			if (Hueco == true)
        {
			randoms = Random.Range(1, 3);
			Hueco = false;
			Invoke("enfriamiento4", 5f);
		}
		
			if (randoms == 1)
			{
				Xcarro = -5;
			}
			else if (randoms == 2)
			{
				Xcarro = -8;
			}
			Hueco = false;

			
		




		if (start == true && gameOver == false)
		{

		


			if (tiempoPuntaje == true)
			{
				
				distancia++;
				tiempoPuntaje = false;
				Invoke("enfriamiento", 0.2f);
			}

			if (subirVelocidad == true)
			{
				velocidadFondo += 0.02f;
				velocidadSuelo += 0.2f;

				subirVelocidad = false;
				Invoke("enfriamiento3", 5f);
			}
			

			// mover suelo

			for (int i = 0; i < Suelos.Count; i++)
			{
				if (Suelos[i].transform.position.x <= -10)
				{
					Suelos[i].transform.position = new Vector3(10, Xcarro, 0);
				}
				Suelos[i].transform.position = Suelos[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * 2;
			}

			// mover mapa
			Fondo.material.mainTextureOffset = Fondo.material.mainTextureOffset + new Vector2(velocidadFondo, 0) * Time.deltaTime;

			// techo

			for (int i = 0; i < Techos.Count; i++)
			{
				if (Techos[i].transform.position.x <= -3)
				{
					Techos[i].transform.position = new Vector3(0.5f, 8.5f, 0);
				}
				Techos[i].transform.position = Techos[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * 2;
			}

			//Obstaculos (policias)
			for (int i = 0; i < Policias.Count; i++)
			{
				if (Policias[i].transform.position.x <= -15)
				{

					float randomx = Random.Range(11, 18);
					float randomy = Random.Range(-4, 4);
					Policias[i].transform.position = new Vector3(randomx, randomy, 0);
				}
				Policias[i].transform.position = Policias[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * 10;
			}
		}
	}



	 void enfriamiento()
    {
			tiempoPuntaje = true;
    }
		void enfriamiento2()
    {
			tiempoSuelo = true;
	}

	 void enfriamiento3()
	{
		subirVelocidad = true;
	}

	void enfriamiento4()
    {
		Hueco = true;
    }

}
