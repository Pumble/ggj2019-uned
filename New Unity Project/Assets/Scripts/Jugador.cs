using UnityEngine;

public class Jugador : MonoBehaviour
{
    private Vida v;

    public Casa casa;
    public int danoInflinge;

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
            Destroy(gameObject);
        }

        if (Input.GetKeyDown("space"))
        {
            //casa.anadirRecursos(5);
        }
    }

	public int getVida()
	{
		return v.getVida();
	}

	public void setVida(int _vida)
	{
		// vida = _vida;
        v.vida = _vida;
	}
}
