using System.Collections;
using UnityEngine;

public class Controller : MonoBehaviour
{

	[SerializeField]
	private GameObject lobo;

	[SerializeField]
	private int cuantosLobos;

	[SerializeField]
	[Tooltip("Tiempo para que los lobos spawneen")]
	private float tiempoSpawn;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (cuantosLobos > 0)
		{
			StartCoroutine(spawnearLobos());
			cuantosLobos--;
		}
    }

	IEnumerator spawnearLobos()
	{
		yield return new WaitForSeconds(tiempoSpawn);
		Instantiate(lobo);
	}
}
