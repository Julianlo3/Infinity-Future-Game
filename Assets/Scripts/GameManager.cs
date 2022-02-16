using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	//--------------------
	public Renderer Fondo; // La  variable que se usa para manejar el fondo
	public float velocidadFondo;
	public GameObject Suelo;
	public GameObject Techo;
	public GameObject Policia;
	public List<GameObject> Suelos;
	public List<GameObject> Techos;
	public List<GameObject> Policias;

	public GameObject MenuGameOver;
	public bool gameOver = false;
	public bool start = false;

	//----------------------
	// Start is called before the first frame update
	void Start()
	{
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
		for (int i = 0; i < 1; i++)
		{
			Policias.Add(Instantiate(Policia, new Vector2(12 + i, 6), Quaternion.identity));
		}
	}

	// Update is called once per frame
	void Update()
	{

		start = true;

		if (gameOver == true)
		{
			MenuGameOver.SetActive(true);
			if (Input.GetKeyDown(KeyCode.X))
			{
				SceneManager.LoadScene(1);
			}
		}


		if (start == true && gameOver == false)
		{

			Fondo.material.mainTextureOffset = Fondo.material.mainTextureOffset + new Vector2(velocidadFondo, 0) * Time.deltaTime;

			// mover mapa
			for (int i = 0; i < Suelos.Count; i++)
			{
				if (Suelos[i].transform.position.x <= -10)
				{
					Suelos[i].transform.position = new Vector3(10, -5, 0);
				}
				Suelos[i].transform.position = Suelos[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * 2;
			}
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
					PersonajePrincipal personaje = new PersonajePrincipal();

					float randomx = Random.Range(11, 18);
					float randomy = Random.Range(-4, 4);
					Policias[i].transform.position = new Vector3(randomx, randomy, 0);
				}
				Policias[i].transform.position = Policias[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * 11;
			}
		}
	}
}
