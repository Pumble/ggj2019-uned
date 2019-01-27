﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidos : MonoBehaviour
{
	public AudioSource madera;
	public AudioSource ataqueCastor;
	public AudioSource ataqueLobo;
	public AudioSource upgradeCasa;


	public void sndMadera()
	{
		madera.Play();
	}
	public void sndAtaqueCastor()
	{
		ataqueCastor.Play();
	}
	public void sndAtaqueLobo()
	{
		ataqueLobo.Play();
	}
	public void sndUpgradeCasa()
	{
		upgradeCasa.Play();
	}
}
