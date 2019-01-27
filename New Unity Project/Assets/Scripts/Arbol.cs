using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Arbol : MonoBehaviour
{
    public Jugador jugador;
    public Casa casa;
    private Vida v;
    [SerializeField]
    public Sprite[] tiposArboles;

    private SpriteRenderer spriteRender;

    // Start is called before the first frame update
    void Start()
    {
        v = GetComponentInParent<Vida>();
        spriteRender = GetComponentInChildren<SpriteRenderer>();
        spriteRender.sprite = tiposArboles[Random.Range(0, 2)];
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

		if(Vector2.Distance(transform.position, jugador.transform.position) <= 0.5f)
		{
			jugador.Alerta();
			if (Input.GetMouseButtonDown(1))
			{
				jugador.AlertaDesactivar();
				v.reducirVida(jugador.danoInflinge);
			}
		}
		else
		{
			jugador.AlertaDesactivar();
		}
		
	}


    public int getVida() {
        return v.getVida();
    }
}
