using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Jugador : MonoBehaviour
{
    private Vida v;

    public Casa casa;
    public int danoInflinge;
	public GameObject gameOver;
    public Slider sliderVida;
    public AudioSource muerteMusica;
	public GameObject alerta;

    // Start is called before the first frame update
    void Start()
    {
        v = GetComponentInParent<Vida>();
    }

    // Update is called once per frame
    void Update()
    {
        if (v.getVida() <= 0)
        {
			if (!muerteMusica.isPlaying)
			{ muerteMusica.Play(); }
			//Destroy(gameObject);
			//Animación
			gameObject.GetComponent<walk>().muerto = true;
            //gameObject.GetComponent<walk>().inmovil = true;

            Reiniciar();
        }

        if (Input.GetKeyDown("space"))
        {
            //casa.anadirRecursos(5);
        }
        sliderVida.value = v.getVida();
    }

	public int getVida()
	{
		return v.getVida();
    }

	public void setVida(int _vida)
	{
		// vida = _vida;
        v.vida = _vida;
	}

	void Reiniciar()
	{
		gameOver.SetActive(true);
	}

	public void Alerta()
	{
		alerta.SetActive(true);
	}

	public void AlertaDesactivar()
	{
		alerta.SetActive(false);
	}
}
