using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BebeCastor : MonoBehaviour
{
    public Jugador jugador;
    public float cooldown;
    public bool tocandoHijo = false;
    public float tiempoAnimacionCura = 2f;
    public GameObject gameOver;
    private Animator animacion;
    private float _cooldown;
    private float tiempoParaSaludar;
    private Vida v;

    // Start is called before the first frame update
    void Start()
    {
        v = GetComponent<Vida>(); // OBTENER COMPONENTES HERMANOS
        animacion = GetComponentInChildren<Animator>();
        _cooldown = cooldown;
        tiempoParaSaludar = Random.Range(5f, 12f);
        StartCoroutine(saludar());
    }

    // Update is called once per frame
    void Update()
    {
        _cooldown -= Time.deltaTime;
        if (v.getVida() <= 0)
        {
            animacion.SetBool("morir", true);
        }
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

    public void sndAtaqueLobo()
    {
        v.reducirVida(1);
        if (v.getVida() <= 0)
        {
            Debug.Log("Muerte del bebe");
            // PARAR LA MUSICA
            // GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>().detenerTodaMusicaDeEsteComponente();
            jugador.GetComponent<walk>().muerto = true; // ESTE CAMBIO HACE LAS 2 COSAS DE ARRIBA
            // TOCAR LA MUSICA MUERTE
            GameObject.FindGameObjectWithTag("snd").GetComponent<Sonidos>().sndPerder();
            // PANTALLA DE GAME OVER
            gameOver.SetActive(true);
        }
    }

    public void besitos()
    {
        animacion.SetBool("saludar", true);
    }
}
