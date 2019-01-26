using System.Collections;
using UnityEngine;

public class Controller : MonoBehaviour
{

	[SerializeField]
	private GameObject lobo;

	[SerializeField]
	private float radioDeSpawn;

	[SerializeField]
	private Transform spawnDeLobos;

	[SerializeField]
	private int cuantosLobos;

	[SerializeField]
	[Tooltip("Tiempo para que los lobos spawneen")]
	private float tiempoSpawn;

	[SerializeField]
	private AudioSource introMusicaLobos;

	[SerializeField]
	private AudioSource MusicaLobos;

	private AudioSource musicaEnUso;

	private bool spawneado = false;
	private bool spawnearHorda = false;

	private bool musicaIntroTocando = false;


	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (musicaIntroTocando && !introMusicaLobos.isPlaying && !MusicaLobos.isPlaying)
			MusicaLobos.Play();

		if (cuantosLobos > 0 && !spawneado)
		{
			spawneado = true;
			if (!introMusicaLobos.isPlaying && !MusicaLobos.isPlaying)
			{
				musicaIntroTocando = true;
				introMusicaLobos.Play();
			}
			StartCoroutine(spawnearLobos());
			cuantosLobos--;
		}

	}

	IEnumerator spawnearLobos()
	{
		yield return new WaitForSeconds(tiempoSpawn);
		spawnearHorda = true;
		GameObject obj = Instantiate(lobo, Random.insideUnitCircle*radioDeSpawn, Quaternion.identity) ;
		Vector2 posNueva = new Vector2(-obj.transform.position.x+spawnDeLobos.position.x,
									-obj.transform.position.y+spawnDeLobos.position.y);
		obj.transform.position = posNueva;
		spawneado = false;
	}
}
