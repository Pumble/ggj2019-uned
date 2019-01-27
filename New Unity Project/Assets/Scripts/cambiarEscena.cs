using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambiarEscena : MonoBehaviour
{

	public AudioSource boton;
	int x = 0;
	bool n = false;


	private void Update()
	{
		if (n)
		{
			StartCoroutine(esperarParaCambiar());

		}
	}

	public void nivel(int i)
	{

		n = true;
		x = i;

	}

	IEnumerator esperarParaCambiar()
	{
		if(!boton.isPlaying)
			boton.Play();
		
		yield return new WaitForSecondsRealtime(x);
		SceneManager.LoadScene(x);
	}
}
