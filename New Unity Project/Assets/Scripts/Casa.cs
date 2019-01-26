using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casa : MonoBehaviour
{
    public int recursos;
    public int recursosParaNivel2;
    public int recursosParaNivel3;


    // Start is called before the first frame update
    void Start()
    {

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
            }
        }
    }

    void OnDestroy()
    {

    }

    public void anadirRecursos(int cantidadRecursos)
    {
        recursos += cantidadRecursos;
        Debug.Log("recursos actuales " + recursos);
    }
}