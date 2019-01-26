using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://docs.unity3d.com/ScriptReference/Collider2D.html
// https://docs.unity3d.com/ScriptReference/Component-gameObject.html
// https://docs.unity3d.com/ScriptReference/GameObject.html

public class NoSeVaya : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.name == "player")
        {
            if (col.gameObject.transform.position.x < -0.1)
            {
                // SALIENDOSE POR LA IZQUIERDA
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            if (col.gameObject.transform.position.x < 0.1)
            {
                // SALIENDOSE POR LA DERECHA
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            if (col.gameObject.transform.position.y > 0.1)
            {
                // SALIENDOSE POR ARRIBA
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
            if (col.gameObject.transform.position.y > -0.1)
            {
                // SALIENDOSE POR ABAJO
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }

            Debug.Log(col.gameObject.transform.position.x);
            Debug.Log(col.gameObject.transform.position.y);

            //Debug.Log(col.OverlapPoint().ToStiring());
            //transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
