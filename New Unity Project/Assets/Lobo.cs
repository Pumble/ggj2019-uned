using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		if (estaCerca(transform.position, jugador.transform.position) || estaCerca(transform.position, casa.transform.position))
		{
			//Atacar
			Atacar();
		}
		else
		{
			//Ir a la casa a destruirla
			transform.position = Vector2.Lerp(transform.position, posCasa, velocidad * Time.deltaTime);
		}
	}

	private void Atacar()
	{
		Debug.Log("Atacar sin implementar");
	}

	private bool estaCerca(Vector2 objeto, Vector2 destino)
	{
		return Vector2.Distance(objeto, destino) <= rango;
	}
}
