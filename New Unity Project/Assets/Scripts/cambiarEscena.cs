using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambiarEscena : MonoBehaviour
{

    public void nivel(int i)
	{
		SceneManager.LoadScene(i);
	}
}
