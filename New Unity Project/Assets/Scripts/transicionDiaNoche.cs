using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://docs.unity3d.com/ScriptReference/MonoBehaviour.InvokeRepeating.html
// https://www.youtube.com/watch?v=PuXUCX21jJU

public class transicionDiaNoche : MonoBehaviour
{
    // spriteIsla
    //public CinemachineVirtualCamera vcam;
    public Sprite fondo1;
    public Sprite fondo2;
    public Sprite fondo3;
    public Sprite fondo4;
    private Sprite[] archivosFondo;
    public SpriteRenderer spriteRenderer;

    private int archivoFondoIndice = 0;

    public float tiempoTransicion = 10f; // 10


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("cambiarFondo", 1.0f, tiempoTransicion);
        // INICIA CON UN SEGUNDO DESPUES Y SE EJECUTA CADA 30s
    }

    // Update is called once per frame
    void Update()
    {

    }

    void cambiarFondo()
    {
        Debug.Log("Cambiando el fondo"); 
        switch(archivoFondoIndice)
        {
            case 0:
                spriteRenderer.sprite = fondo1;
                break;
            case 1:
                spriteRenderer.sprite = fondo2;
                break;
            case 2:
                spriteRenderer.sprite = fondo3;
                break;
            case 3:
                spriteRenderer.sprite = fondo4;
                break;
            default:
                archivoFondoIndice = 0;
                break;
        }
        archivoFondoIndice++;
    }
}
