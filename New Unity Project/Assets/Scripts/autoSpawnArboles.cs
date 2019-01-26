//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoSpawnArboles : MonoBehaviour
{
    public Jugador jugador;
    public Casa casa;
    public Arbol arbol;
    public float spawnTime = 3f;
    public int limite;
    public int cuantosArboles = 10;
    
    public float radioDeSpawn;
    public Transform spawnDeArboles;

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
            // TODAVIA PODEMOS SPAWNEAR
            if (revisarArbolesVivos())
            {
                // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
                Arbol arbolCopia = Instantiate<Arbol>(arbol, Random.insideUnitCircle * radioDeSpawn, Quaternion.identity);
                arbolCopia.transform.position = new Vector2(arbolCopia.transform.position.x + spawnDeArboles.position.x, -arbolCopia.transform.position.y + spawnDeArboles.position.y);
                arbolCopia.jugador = jugador;
                arbolCopia.casa = casa;
                // alborlesEnJuego.Add(arbolCopia);
            }
        }
    }

    bool revisarArbolesVivos()
    {
        var foundObjects = FindObjectsOfType<Arbol>();
        return foundObjects.Length < cuantosArboles;
    }
}
