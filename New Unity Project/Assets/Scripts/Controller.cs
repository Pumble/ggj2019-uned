using System.Collections;
using UnityEngine;

public class Controller : MonoBehaviour
{
	[Header("Enemigos")]
	[Space]
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

	private float _tiempoSpawn;

	[Space]
	[Header("Musica")]
	[Space]
	[SerializeField]
	private AudioSource introMusicaLobos;

	[SerializeField]
	private AudioSource MusicaLobos;

	[SerializeField]
	private AudioSource musicaPrincipal;

	[SerializeField]
	private AudioSource introMusicaPrincipal;

	[SerializeField]
	private AudioSource musicaNoche;

	private AudioSource musicaEnUso;

	private bool spawneado = false;
	private bool spawnearHorda = true;

	private bool musicaIntroTocando = false;
	private bool bajarVolumen = false;



	void Start()
    {
		introMusicaPrincipal.Play();
		_tiempoSpawn = tiempoSpawn;
    }

	// Update is called once per frame
	void Update()
	{
		/*print(string.Format("musicaNoche{0} introMusicaPrincipal{1} musicaPrincipal{2} introMusicaLobos{3} MusicaLobos{4} musicaIntroTocando{5}",
			!musicaNoche.isPlaying, !introMusicaPrincipal.isPlaying,
			!musicaPrincipal.isPlaying, !introMusicaLobos.isPlaying, !MusicaLobos.isPlaying, !musicaIntroTocando));
            */

		if (!musicaNoche.isPlaying && !introMusicaPrincipal.isPlaying && 
			!musicaPrincipal.isPlaying && !introMusicaLobos.isPlaying && !MusicaLobos.isPlaying && !musicaIntroTocando)
		{
			musicaPrincipal.Play();
		}
		else if(false)
		{
			musicaPrincipal.Stop();
		}


		if (musicaIntroTocando && !introMusicaLobos.isPlaying && !MusicaLobos.isPlaying)
		{ MusicaLobos.Play();
			musicaIntroTocando = false;
		}

		if (cuantosLobos > 0 && !spawneado)
		{
			
			spawneado = true;
			StartCoroutine(spawnearLobos());
			
		}else if(cuantosLobos <= 0 && !spawnearHorda)
		{

			MusicaLobos.Stop();
			if (_tiempoSpawn<=0)
			{
				_tiempoSpawn = tiempoSpawn;
				spawnearHorda = true;
			}
			_tiempoSpawn -= Time.deltaTime;
		}

		
	}

	IEnumerator spawnearLobos()
	{
		yield return new WaitForSeconds(tiempoSpawn);
		cuantosLobos--;
		musicaPrincipal.Stop();

		if (!introMusicaLobos.isPlaying && !MusicaLobos.isPlaying && spawnearHorda)
		{
			musicaIntroTocando = true;
			spawnearHorda = false;
			introMusicaLobos.Play();
		}
		GameObject obj = Instantiate(lobo, Random.insideUnitCircle*radioDeSpawn, Quaternion.identity) ;
		Vector2 posNueva = new Vector2(-obj.transform.position.x+spawnDeLobos.position.x,
									-obj.transform.position.y+spawnDeLobos.position.y);
		obj.transform.position = posNueva;
		spawneado = false;
	}

	public void tocarMusicaNoche()
	{
		musicaPrincipal.Stop();
		MusicaLobos.Stop();
		introMusicaPrincipal.Stop();
		introMusicaLobos.Stop();

		musicaNoche.Play();
	}

	public void detenerMusicaNoche()
	{
		musicaNoche.Stop();
	}
}
