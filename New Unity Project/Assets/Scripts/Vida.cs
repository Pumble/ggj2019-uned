using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public int vida;
	public SimpleHealthBar healthBar;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		try
		{
			healthBar.UpdateBar(vida, 5);
		}
		catch
		{

		}
    }

    public int getVida()
    {
        return vida;
    }

    public void reducirVida(int puntosVida)
    {
        vida -= puntosVida;
    }

    public void aumentarVida(int puntosVida)
    {
        vida += puntosVida;
    }
}
