using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casa : MonoBehaviour
{
    public int recursos;
    public int recursosParaNivel2;
    public int recursosParaNivel3;
	public TMPro.TextMeshProUGUI TextPro;

	public GameObject victoria;
	public Sprite[] casa;
	public AudioSource musicaVictoria;
	private GameObject cnt;

	private int sigNivel;

	// Start is called before the first frame update
	void Start()
    {

		cnt = GameObject.FindGameObjectWithTag("Controller");
		sigNivel = recursosParaNivel2;
		TextPro.text = String.Format("{0}/{1}", recursos, sigNivel);
		GetComponent<SpriteRenderer>().sprite = casa[0];
	}

    // Update is called once per frame
    void Update()
    {
		TextPro.text = string.Format("{0}/{1}", recursos, sigNivel);
        if (recursos >= recursosParaNivel3 && !victoria.active ) // NIVEL 3
        {
			cnt.GetComponent<Controller>().detenerTodaMusicaDeEsteComponente();
			Destroy(cnt);
			GameObject.FindGameObjectWithTag("snd").GetComponent<Sonidos>().sndUpgradeCasa();
			GetComponent<SpriteRenderer>().sprite = casa[2];
			victoria.SetActive(true);
			musicaVictoria.Play();
			
			GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>().detenerTodaMusicaDeEsteComponente();
		}
        else
        {
			
			if (recursos >= recursosParaNivel2 && sigNivel != recursosParaNivel3)
            {
				GameObject.FindGameObjectWithTag("snd").GetComponent<Sonidos>().sndUpgradeCasa();
				sigNivel = recursosParaNivel3;
				GetComponent<SpriteRenderer>().sprite = casa[1];
			}
        }
    }
	
    public void anadirRecursos(int cantidadRecursos)
    {
        recursos += cantidadRecursos;
    }
}