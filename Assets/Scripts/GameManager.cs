using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
	//--------------------
	public PersonajePrincipal personajePrincipal;
	public FondosManager fondosManager;
	public Escenario escenario;
	public Puntuacion puntuacion;
	public GameObject Muerte;
	public GameObject MenuGameOver;
	public bool gameOver = false;
	public bool start = false;
	public bool cambiarFondo;
	//----------------------
    void Start()
	{
		MenuGameOver.SetActive(false);
		start = true;
		gameOver = false;
		Muerte.transform.position = new Vector2(-7f, -7f);
	}

	// Update is called once per frame
	void Update()
	{
       
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

}
