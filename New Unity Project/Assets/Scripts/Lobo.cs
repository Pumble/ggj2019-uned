using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Lobo : MonoBehaviour
{
	private GameObject jugador;
	private GameObject casa;
	private Vector2 posCasa;

	[SerializeField]
	[Range(0,10)]
	private float rango;
	[SerializeField]
	[Range(0, 10)]
	private float velocidad;
	[SerializeField]
	[Range(0, 10)]
	private float velocidadDeAtaque;
	[SerializeField]
	[Range(0, 5)]
	private int danno;

	public Animator anim;

	private bool ataco = false;//atacó
    [SerializeField]
    private float tiempoMuerte = 2f;

	static public int cantidadDeLobos = 0;

	// Start is called before the first frame update
	void Start()
    {
		casa = GameObject.FindGameObjectWithTag("Casa");
		posCasa = casa.transform.position;
		jugador = GameObject.FindGameObjectWithTag("Player");
		cantidadDeLobos++;
	}

	private void OnDestroy()
	{
		cantidadDeLobos--;
	}

	// Update is called once per frame
	void Update()
	{
		if(GetComponent<Vida>().vida <= 0)
		{
            anim.SetBool("Idle", false);
            anim.SetBool("Corriendo", false);
            anim.SetBool("Atacando", false);
            anim.SetBool("morir", true);
            Destroy(gameObject, tiempoMuerte);
        }

		bool enRangoJugador = estaCerca(transform.position, jugador.transform.position);
		bool enRangoCasa = estaCerca(transform.position, casa.transform.position);
		if (enRangoJugador || enRangoCasa)
		{
			//Atacar jugador
			if (!ataco && enRangoJugador)
			{
				ataco = true;
				anim.SetBool("Idle", true);
				anim.SetBool("Corriendo", false);
				anim.SetBool("Atacando", false);
                anim.SetBool("morir", false);
                StartCoroutine(AtacarJugador());
			}

			else if (!ataco && enRangoCasa)
			{
				ataco = true;
				anim.SetBool("Idle", true);
				anim.SetBool("Corriendo", false);
				anim.SetBool("Atacando", false);
                anim.SetBool("morir", false);
                StartCoroutine(AtacarCasa());
			}
			else if(!ataco)
			{
                anim.SetBool("morir", false);
                anim.SetBool("Idle", false);
				anim.SetBool("Corriendo", true);
				anim.SetBool("Atacando", false);
			}

		}
		else
		{
			//Ir a la casa a destruirla
			//Debug.Log(1);
			transform.position = Vector2.Lerp(transform.position, posCasa, velocidad * Time.deltaTime);
		}
	}

	private IEnumerator AtacarJugador()
	{
		
		yield return new WaitForSeconds(velocidadDeAtaque);

		anim.SetBool("Idle", false);
		anim.SetBool("Corriendo", false);
		anim.SetBool("Atacando", true);

		GameObject.FindGameObjectWithTag("snd").GetComponent<Sonidos>().sndAtaqueLobo();
		yield return new WaitForSeconds(velocidadDeAtaque);

		int vidaJugador = jugador.GetComponent<Jugador>().getVida();
		jugador.GetComponent<Jugador>().setVida(vidaJugador-=danno);
		ataco = false;
		
	}

	private IEnumerator AtacarCasa()
	{
		yield return new WaitForSeconds(velocidadDeAtaque);
		

		anim.SetBool("Idle", false);
		anim.SetBool("Corriendo", false);
		anim.SetBool("Atacando", true);

		GameObject.FindGameObjectWithTag("snd").GetComponent<Sonidos>().sndAtaqueLobo();
		yield return new WaitForSeconds(velocidadDeAtaque);

		//Cambiar por quitar vida al hogar
		//int vidaJugador = jugador.GetComponent<Jugador>().getVida();
		//jugador.GetComponent<Jugador>().setVida(vidaJugador -= danno);
		
		ataco = false;
	}

	public bool estaCerca(Vector2 objeto, Vector2 destino)
	{
		
		return Vector2.Distance(destino, objeto) <= rango;
	}
}
