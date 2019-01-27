using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casa : MonoBehaviour
{
    public int recursos;
    public int recursosParaNivel2;
    public int recursosParaNivel3;
	public TMPro.TextMeshProUGUI TextPro;

	private int sigNivel;

	// Start is called before the first frame update
	void Start()
    {
		sigNivel = recursosParaNivel2;
    }

    // Update is called once per frame
    void Update()
    {
        if (recursos >= recursosParaNivel3) // NIVEL 3
        {
            Debug.Log("Casa mejorada a nivel 3");
        }
        else
        {
            if (recursos >= recursosParaNivel2)
            {
                Debug.Log("Casa mejorada a nivel 2");
				sigNivel = recursosParaNivel3;
            }
        }
    }

    void OnDestroy()
    {

    }

    public void anadirRecursos(int cantidadRecursos)
    {
        recursos += cantidadRecursos;
		TextPro.text = string.Format("{0}/{1}", recursos, sigNivel);
        Debug.Log("recursos actuales " + recursos);
    }
}