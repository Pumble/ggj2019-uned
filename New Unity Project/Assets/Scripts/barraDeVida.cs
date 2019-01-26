using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barraDeVida : MonoBehaviour
{
    public Vector3 localScale;
    private Vida v;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        v = GetComponentInParent<Vida>();
    }

    // Update is called once per frame
    void Update()
    {
        if(v != null)
        {
            localScale.x = v.getVida();
            transform.localScale = localScale;
        }
    }
}