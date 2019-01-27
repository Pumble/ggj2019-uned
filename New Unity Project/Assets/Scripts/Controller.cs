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
	private int _cuantosLobos;

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
	private walk jugador;



	void Start()
    {
		_cuantosLobos = cuantosLobos;
		jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<walk>();
		introMusicaPrincipal.Play();
		_tiempoSpawn = tiempoSpawn;
    }

	// Update is called once per frame
	void Update()
	{
		if (!jugador.muerto)
		{
			if(_cuantosLobos <= 0 && Lobo.cantidadDeLobos <= 0)
			{
				_cuantosLobos = cuantosLobos;
				_tiempoSpawn = tiempoSpawn;
			}

			if (!musicaNoche.isPlaying && !introMusicaPrincipal.isPlaying &&
			  !musicaPrincipal.isPlaying && !introMusicaLobos.isPlaying && !MusicaLobos.isPlaying && !musicaIntroTocando && Lobo.cantidadDeLobos <= 0)
			{
				musicaPrincipal.Play();
			}
			else if (MusicaLobos.isPlaying || introMusicaLobos.isPlaying)
			{
				musicaPrincipal.Stop();
			}


			if ((musicaIntroTocando && !introMusicaLobos.isPlaying && !MusicaLobos.isPlaying))
			{
				MusicaLobos.Play();
				musicaPrincipal.Stop();
				musicaIntroTocando = false;
			}

			if (_cuantosLobos > 0 && !spawneado)
			{

				spawneado = true;
				StartCoroutine(spawnearLobos());

			}
			else if (Lobo.cantidadDeLobos <= 0 && !spawnearHorda)
			{

				MusicaLobos.Stop();
				if (_tiempoSpawn <= 0)
				{
					_tiempoSpawn = tiempoSpawn;
					spawnearHorda = true;
				}
				_tiempoSpawn -= Time.deltaTime;
			}
		}
		else
		{
			musicaPrincipal.Stop();
			MusicaLobos.Stop();
			introMusicaPrincipal.Stop();
			introMusicaLobos.Stop();
			musicaNoche.Stop();
		}
		
	}

	IEnumerator spawnearLobos()
	{
		yield return new WaitForSeconds(tiempoSpawn);
		_cuantosLobos--;
		musicaPrincipal.Stop();

		if (!introMusicaLobos.isPlaying && !MusicaLobos.isPlaying && spawnearHorda)
		{
			musicaIntroTocando = true;
			spawnearHorda = false;
			musicaPrincipal.Stop();
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

	public void detenerTodaMusicaDeEsteComponente()
	{
		musicaPrincipal.Stop();
		MusicaLobos.Stop();
		introMusicaPrincipal.Stop();
		introMusicaLobos.Stop();
		musicaNoche.Stop();
	}
}
