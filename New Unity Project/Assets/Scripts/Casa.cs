using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

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

    public CinemachineVirtualCamera vcam;
    public BebeCastor bebeCastorReferencia;
    public GameObject bebeMensajeCanvas;

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

            // UNA VEZ GANA, HAY QUE DETENER LAS TRANSICIONES Y HACER ZOOM IN EN EL CASTOR BEBE
            vcam.GetComponent<transicionDiaNoche>().detenerTransicion = true; // DETENER LAS TRANSCIONES
            //vcam.m_Follow = bebeCastorReferencia.GetComponent<Transform>();
            // vcam.m_LookAt = bebeCastorReferencia.GetComponent<Transform>();
            vcam.Follow = bebeCastorReferencia.GetComponent<Transform>();
            //bebeMensajeCanvas.enabled = true;
            bebeMensajeCanvas.SetActive(true);
            bebeCastorReferencia.besitos();
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