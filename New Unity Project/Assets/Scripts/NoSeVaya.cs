using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://docs.unity3d.com/ScriptReference/Collider2D.html
// https://docs.unity3d.com/ScriptReference/Component-gameObject.html
// https://docs.unity3d.com/ScriptReference/GameObject.html

public class NoSeVaya : MonoBehaviour
{
    
	public Transform centro;
	public float velocidad;
	public float tiempo;
	private float _tiempo;
	private bool mover = false;
	private bool parar = false;
	private GameObject jugador;

	private void Start()
	{
		jugador = GameObject.FindGameObjectWithTag("Player");
		_tiempo = tiempo;
	}


	void OnTriggerExit2D(Collider2D col)
    {
		mover = true;
		jugador.GetComponent<walk>().inmovil = true;
    }


    // Update is called once per frame
    void Update()
    {
		if (mover) {

			if (_tiempo <= 0)
			{
				//parar = true;
				mover = false;
				jugador.GetComponent<walk>().inmovil = false;
				_tiempo = tiempo;
			}

			jugador.transform.position = Vector2.Lerp(jugador.transform.position, centro.position, velocidad * Time.deltaTime);
			_tiempo -= Time.deltaTime;
			
		}
    }
}
