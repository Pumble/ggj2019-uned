﻿using System;
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

	private bool ataco = false;//atacó

	// Start is called before the first frame update
	void Start()
    {
		casa = GameObject.FindGameObjectWithTag("Casa");
		posCasa = casa.transform.position;
		jugador = GameObject.FindGameObjectWithTag("Player");
	}

    // Update is called once per frame
    void Update()
	{

		bool enRangoJugador = estaCerca(transform.position, jugador.transform.position);
		bool enRangoCasa = estaCerca(transform.position, casa.transform.position);
		if (enRangoJugador || enRangoCasa)
		{
			//Atacar jugador
			if (!ataco && enRangoJugador)
			{
				ataco = true;
				StartCoroutine(AtacarJugador());
			}

			if (!ataco && enRangoCasa)
			{
				ataco = true;
				StartCoroutine(AtacarCasa());
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
		
		int vidaJugador = jugador.GetComponent<Jugador>().getVida();
		jugador.GetComponent<Jugador>().setVida(vidaJugador-=danno);
		ataco = false;
		
	}

	private IEnumerator AtacarCasa()
	{
		yield return new WaitForSeconds(velocidadDeAtaque);

		//int vidaJugador = Casa.GetComponent<Casa>().getVida();
		//casa.GetComponent<Casa>().setVida(vidaJugador -= danno);
		ataco = false;
	}

	private bool estaCerca(Vector2 objeto, Vector2 destino)
	{
		
		return Vector2.Distance(destino, objeto) <= rango;
	}
}