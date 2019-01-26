using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoSpawnArboles : MonoBehaviour
{
    public Jugador jugador;
    public Casa casa;
    public Arbol arbol;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;


    // Start is called before the first frame update
    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("spawnArboles", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnArboles()
    {
        if (jugador.getVida() <= 0)
        {
            return;
        }
        else {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Arbol arbolCopia = Instantiate<Arbol>(arbol, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            arbolCopia.jugador = jugador;
            arbolCopia.casa = casa;
        }
    }
}
