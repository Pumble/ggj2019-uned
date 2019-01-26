using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbol : MonoBehaviour
{
    public Jugador jugador;
    public Casa casa;
    private Vida v;

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
            // DISPARAR ANIMACION DE CAIDA DE ARBOL
            casa.anadirRecursos(5);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "player")
        {
            if (Input.GetKeyDown("space"))
            {
                v.reducirVida(jugador.danoInflinge);
            }
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name == "player")
        {
            if (Input.GetKeyDown("space"))
            {
                v.reducirVida(jugador.danoInflinge);
            }
        }
    }
    public int getVida() {
        return v.getVida();
    }
}
