using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambiarEscena : MonoBehaviour
{

	public AudioSource boton;

    public void nivel(int i)
	{
		boton.Play();
		SceneManager.LoadScene(i);
	}
}
