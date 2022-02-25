using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
	//--------------------
	private string mantenerPuntuacion = "distancia";


	public Renderer Fondo; // La  variable que se usa para manejar el fondo
	public float velocidadFondo;
	public float velocidadSuelo;
	public GameObject Suelo;
	public GameObject Techo;
	public GameObject Policia;
	public GameObject Muerte;
	public GameObject CambiarEscena;
	public List<GameObject> Suelos;
	public List<GameObject> Policias;
	public Text score;
	public Text recordJugador;
	public bool Hueco = true;
	public GameObject MenuGameOver;
	public bool gameOver = false;
	public bool start = false;
	public int distancia;
	public bool tiempoPuntaje = true;
	public bool tiempoSuelo = true;
	public bool subirVelocidad;
	public int Xcarro;
	public int randoms;
	public int velocidadObstaculo;
	public bool policiaNuevo;
	public int numeroPolicia;
	public int record;
	//----------------------
	// Start is called before the first frame update
	private void Awake()
	{
		cargarDatos();
	}

   

    void Start()
	{


		CambiarEscena.transform.localScale = new Vector2(1,1);
		CambiarEscena.transform.position = new Vector3(19, -1.13f, -1);
		record = PlayerPrefs.GetInt("GuardarPuntaje");
		numeroPolicia = 0;
		policiaNuevo = true;
		velocidadFondo = 10;
		Techo.transform.position = new Vector2(-4.7f, -3.3f);
		Xcarro = -5;
		subirVelocidad = true;
		velocidadSuelo = 7;
		Muerte.transform.position = new Vector2(-7f, -7f);
		velocidadFondo = 0.3f;
		distancia = 0;
		// crear suelo
		for (int i = 0; i < 21; i++)
		{
			Suelos.Add(Instantiate(Suelo, new Vector2(-10 + i, -5), Quaternion.identity));
		}
	}

	// Update is called once per frame
	void Update()
	{
        if (distancia > record)
        {
			record = distancia;
			PlayerPrefs.SetInt("GuardarPuntaje", record);
		}

		recordJugador.text = "Record" + record;

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

		if (distancia > 100)
        {
			for (int i = 0; i < 1; i++)
			{
				if (CambiarEscena.transform.position.x <= -18)
				{
					CambiarEscena.transform.position = new Vector3(19, -1.13f, -1);
				}
				CambiarEscena.transform.position = CambiarEscena.transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidadSuelo;
				Fondo.material.mainTextureOffset = Fondo.material.mainTextureOffset + new Vector2(velocidadFondo, 0) * Time.deltaTime * velocidadFondo;
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
				velocidadObstaculo += 1;
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
			Fondo.material.mainTextureOffset = Fondo.material.mainTextureOffset + new Vector2(velocidadFondo, 0) * Time.deltaTime * velocidadFondo;

		


			// crear policias

			if (policiaNuevo == true)
			{

				for (int i = 0; i < 1; i++)
				{
					Policias.Add(Instantiate(Policia, new Vector2(12 + i, 6), Quaternion.identity));
					numeroPolicia += 1;
					policiaNuevo = false;
					Invoke("enfriamiento5", 20f);
				}

			}


			//Obstaculos (policias)
			for (int i = 0; i < Policias.Count; i++)
			{
				if (Policias[i].transform.position.x <= -15)
				{

					float randomx = Random.Range(11, 18);
					float randomy = Random.Range(-4, 5);
					Policias[i].transform.position = new Vector3(randomx, randomy, -2);
				}
				Policias[i].transform.position = Policias[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidadObstaculo;
			}
		}
	}

	private void OnDestroy()
	{
		mantenerDatos();
	}
	private void mantenerDatos()
    {
		PlayerPrefs.SetInt(mantenerPuntuacion, distancia);
    }
	private void cargarDatos()
    {
		distancia = PlayerPrefs.GetInt(mantenerPuntuacion, distancia);
    }

	private void RefreshUI()
    {
		
    }


    

    void cambioEscena()
    {

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

	void enfriamiento5()
    {
		policiaNuevo = true;
    }

}
