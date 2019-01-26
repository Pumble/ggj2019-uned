using UnityEngine;
using System.Collections;

public class Jugador : MonoBehaviour
{
    private Vida v;

    public Casa casa;
    public int danoInflinge;
	public GameObject gameOver;

	public AudioSource muerteMusica;

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
			{ muerteMusica.Play(); print("a"); }
			//Destroy(gameObject);
			//Animación
			gameObject.GetComponent<walk>().muerto = true;
			Reiniciar();
        }

        if (Input.GetKeyDown("space"))
        {
            //casa.anadirRecursos(5);
        }
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
}
