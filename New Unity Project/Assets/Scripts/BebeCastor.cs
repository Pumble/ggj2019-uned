using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BebeCastor : MonoBehaviour
{
    public Jugador jugador;
    public float cooldown;
    public bool tocandoHijo = false;
    public float tiempoAnimacionCura = 2f;
    private Animator animacion;
    private float _cooldown;
    private float tiempoParaSaludar;

    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponentInChildren<Animator>();
        _cooldown = cooldown;
        tiempoParaSaludar = Random.Range(5f, 12f);
        StartCoroutine(saludar());
    }

    // Update is called once per frame
    void Update()
    {
        _cooldown -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            tocandoHijo = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && tocandoHijo)
        {
            if (_cooldown <= 0 && tocandoHijo)
            {
                animacion.SetBool("curar", true);
				GameObject.FindGameObjectWithTag("snd").GetComponent<Sonidos>().sndGanarVida();
                StartCoroutine(dejarDeCurar());
                _cooldown = cooldown;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tocandoHijo = false;
        }
    }

    IEnumerator dejarDeCurar()
    {
        yield return new WaitForSeconds(tiempoAnimacionCura);
        animacion.SetBool("curar", false);
        jugador.setVida(6);
        tocandoHijo = false;
    }

    IEnumerator saludar()
    {
        yield return new WaitForSeconds(tiempoParaSaludar);
        animacion.SetBool("saludar", true);
        StartCoroutine(dejarDeSaludar());
    }
    IEnumerator dejarDeSaludar()
    {
        yield return new WaitForSeconds(2f);
        animacion.SetBool("saludar", false);

        tiempoParaSaludar = Random.Range(5f, 12f);
        StartCoroutine(saludar());
    }
}
