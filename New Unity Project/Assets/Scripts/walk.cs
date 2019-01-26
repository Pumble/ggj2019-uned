using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    public float speed;
	private Animator animacion;

    // Start is called before the first frame update
    void Start()
    {
		animacion = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.D))
        {
			animacion.SetFloat("Speed", 1);
			animacion.SetFloat("EjeX", 1);
			animacion.transform.localRotation = Quaternion.Euler(Vector3.up);
			transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
			animacion.SetFloat("Speed", -1);
			animacion.SetFloat("EjeX", -1);
			animacion.transform.localRotation = Quaternion.Euler(Vector3.up * 180);
			//transform.localRotation= Quaternion.Euler(new Vector3(0, 0, -10));
			transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
			animacion.SetFloat("Speed", -1);
			animacion.SetFloat("EjeY", -1);
			transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
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

        if (Input.GetKeyDown("space"))
        {
            animacion.SetFloat("Speed", 0);
            animacion.SetFloat("EjeY", 0);
            animacion.SetFloat("EjeX", 0);
            animacion.SetBool("Speed", 0);
        }
    }
}
