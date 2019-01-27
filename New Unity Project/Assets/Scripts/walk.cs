using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    public float speed;
    public float tiempoDeAnimacionAtaque;
    private Animator animacion;
	public bool muerto = false;
	public bool inmovil = false;
	public bool tocandoArbol = false;

	public float cooldown;
	private float _cooldown;

	// Start is called before the first frame update
	void Start()
    {
		_cooldown = cooldown;
		animacion = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		_cooldown-=Time.deltaTime;

        if (!muerto || inmovil)
        {
            if (Input.GetKey(KeyCode.D))
            {
                animacion.SetFloat("Speed", 1);
                animacion.SetFloat("EjeX", 1);
                animacion.transform.localRotation = Quaternion.Euler(Vector3.up);
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }

            else if (Input.GetKey(KeyCode.A))
            {
                animacion.SetFloat("Speed", -1);
                animacion.SetFloat("EjeX", -1);
                animacion.transform.localRotation = Quaternion.Euler(Vector3.up * 180);
                //transform.localRotation= Quaternion.Euler(new Vector3(0, 0, -10));
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }

            else if (Input.GetKey(KeyCode.S))
            {
                animacion.SetFloat("Speed", -1);
                animacion.SetFloat("EjeY", -1);
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }

            else if (Input.GetKey(KeyCode.W))
            {
                animacion.SetFloat("Speed", 1);
                animacion.SetFloat("EjeY", 1);
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }

            if (!Input.anyKey)
            {
                animacion.SetFloat("Speed", 0);
                animacion.SetFloat("EjeY", 0);
                animacion.SetFloat("EjeX", 0);
            }
            if (Input.GetMouseButtonDown(0)) // MARIO COLITAS
            {
                animacion.SetFloat("Speed", 0);
                animacion.SetFloat("EjeY", 0);
                animacion.SetFloat("EjeX", 0);
                animacion.SetBool("morder", false);
                animacion.SetBool("morir", false);
                animacion.SetBool("atacando", true);
                StartCoroutine(dejarDeAtacar());
            }
            else if (Input.GetMouseButtonDown(1)) // MORDER
            {
                animacion.SetFloat("Speed", 0);
                animacion.SetFloat("EjeY", 0);
                animacion.SetFloat("EjeX", 0);
                animacion.SetBool("atacando", false);
                animacion.SetBool("morir", false);
                animacion.SetBool("morder", true);
                StartCoroutine(dejarDeMorder());
            }
        }
        else
        {
            inmovil = true;
            animacion.SetBool("morir", true);
        }
    }
    IEnumerator dejarDeAtacar()
    {
        yield return new WaitForSeconds(tiempoDeAnimacionAtaque);
        animacion.SetBool("atacando", false);
    }
    IEnumerator dejarDeMorder()
    {
        yield return new WaitForSeconds(tiempoDeAnimacionAtaque);
        animacion.SetBool("morder", false);
    }


	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.CompareTag("Arbol"))
		{
			tocandoArbol = true;
		} 
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Enemigo") && animacion.GetBool("atacando"))
		{
			GameObject.FindGameObjectWithTag("snd").GetComponent<Sonidos>().sndAtaqueCastor();

			if (_cooldown <= 0)
			{
				collision.gameObject.GetComponent<Vida>().vida--;
				_cooldown = cooldown;
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Arbol"))
		{
			tocandoArbol = false;
		}
	}
}
