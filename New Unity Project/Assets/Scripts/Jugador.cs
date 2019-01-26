using UnityEngine;

public class Jugador : MonoBehaviour
{

	[SerializeField]
	[Range(0,10)]
	private int vida = 1;

    public Casa casa;
    public int danoInflinge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
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
		return vida;
	}

	public void setVida(int _vida)
	{
		vida = _vida;
	}
}
