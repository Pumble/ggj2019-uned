﻿using System.Collections;
using UnityEngine;
using Cinemachine;

// https://docs.unity3d.com/ScriptReference/MonoBehaviour.InvokeRepeating.html
// https://www.youtube.com/watch?v=PuXUCX21jJU
// https://docs.unity3d.com/Packages/com.unity.cinemachine@2.1/api/Cinemachine.CinemachineVirtualCamera.html

public class transicionDiaNoche : MonoBehaviour
{
    // spriteIsla
    //public CinemachineVirtualCamera vcam;
    public Sprite fondo1;
    public Sprite fondo2;
    public Sprite fondo3;
    public Sprite fondo4;
    public SpriteRenderer spriteRenderer;
    private int archivoFondoIndice = 0;
    public float tiempoTransicion; // 10
    public int tiempoParaReiniciarCamara;

    public CinemachineVirtualCamera vcam;
    private LensSettings defaultLens;
    private LensSettings zoomOutLens;

    public float lerpTime;
    private float lerpTimeAux = 0f;

	private GameObject controller;
    private bool transition = true;

    public float zoomIn = 2f;
    public float zoomOut = 4f;


    // Start is called before the first frame update
    void Start()
    {
		controller = GameObject.FindGameObjectWithTag("Controller");

		InvokeRepeating("cambiarFondo", 1.0f, tiempoTransicion);
        // INICIA CON UN SEGUNDO DESPUES Y SE EJECUTA CADA 30s

        defaultLens = new LensSettings(19.6f, 2f, 0.1f, 5000f, 0f, true, 1);
        zoomOutLens = new LensSettings(19.6f, 4f, 0.1f, 5000f, 0f, true, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (transition) // ZOOM OUT
        {
            vcam.m_Lens.OrthographicSize = Mathf.Lerp(zoomIn, zoomOut, lerpTimeAux);
        }
        else // ZOOM IN
        {
            vcam.m_Lens.OrthographicSize = Mathf.Lerp(zoomOut, zoomIn, lerpTimeAux);
        }
        lerpTimeAux += 0.25f * Time.deltaTime;
        /*
        if (lerpTimeAux >= lerpTime)
        {
            lerpTimeAux = 0f;
        }
        */
    }

    void cambiarFondo()
    {
        // vcam.m_Lens = zoomOutLens;
        //vcam.m_Lens = LensSettings.Lerp(defaultLens, zoomOutLens, lerpTime * Time.deltaTime);
        //vcam.m_Lens.OrthographicSize = Mathf.Lerp(zoomIn, zoomOut, lerpTime * Time.deltaTime);

        transition = true;
        lerpTimeAux = 0f;
        Debug.Log("Inicia el zoom out");

        switch (archivoFondoIndice)
        {
            case 0:
				controller.GetComponent<Controller>().detenerMusicaNoche();
				spriteRenderer.sprite = fondo1;
                break;
            case 1:
                spriteRenderer.sprite = fondo2;
                break;
            case 2:
                spriteRenderer.sprite = fondo3;
                break;
            case 3:
				controller.GetComponent<Controller>().tocarMusicaNoche();
                spriteRenderer.sprite = fondo4;
                break;
            default:
                archivoFondoIndice = 0;
                break;
        }

        archivoFondoIndice++;
        StartCoroutine(reiniciarCamara());
    }
    IEnumerator reiniciarCamara() {
        // AQUI SOLO DEBEMOS VOLVER LA CAMARA A LA ORIGINALIDAD
        yield return new WaitForSeconds(tiempoParaReiniciarCamara);
        //vcam.m_Lens.OrthographicSize = zoomIn;
        transition = false;
        lerpTimeAux = 0f;
        Debug.Log("Inicia el zoom in");
        // vcam.m_Lens = defaultLens;
        //vcam.m_Lens.OrthographicSize = Mathf.Lerp(zoomOut, zoomIn, lerpTime * Time.deltaTime);
        // vcam.m_Lens = LensSettings.Lerp(zoomOutLens, defaultLens, lerpTime * Time.deltaTime);
    }
}
