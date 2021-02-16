using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearCuerdita : MonoBehaviour
{
    public Rigidbody esfera;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 forward = esfera.transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.black);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
