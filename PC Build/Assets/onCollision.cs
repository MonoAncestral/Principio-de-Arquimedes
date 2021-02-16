using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class onCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody esfera;
    public Rigidbody esfera2;
    public Rigidbody esfera3;
    public Rigidbody cubo;
    public TMP_Text material;
    public TMP_Text peso;
    private Vector3 pos;
    private Vector3 inicial;
    void Start()
    {
        pos = transform.position;
        inicial = pos;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if(material.text=="Material 1")
        {
            esfera = esfera.GetComponent<Rigidbody>();
            esfera.GetComponent<Rigidbody>().drag = 15F;
            peso.text = "3.4";
            pos.y += 0.04F;
            transform.position = pos;
        }
        else if (material.text == "Material 2")
        {
            esfera2 = esfera2.GetComponent<Rigidbody>();
            esfera2.GetComponent<Rigidbody>().drag = 10F;
            peso.text = "6.10";
            pos.y += 0.08F;
            transform.position = pos;
        }
        else if (material.text == "Material 3")
        {
            esfera3 = esfera3.GetComponent<Rigidbody>();
            esfera3.GetComponent<Rigidbody>().drag = 45F;
            peso.text = "2.80";
            pos.y += 0.01F;
            transform.position = pos;

        }
    }
    public void soltar()
    {
        if (material.text == "Material 1")
        {
            esfera.useGravity = true;
        }
        else if(material.text=="Material 2")
        {
            esfera2.useGravity = true;
        }
        else if (material.text == "Material 3")
        {
            esfera3.useGravity = true;
            StartCoroutine(Wait());

            IEnumerator Wait()
            {
                yield return new WaitForSeconds(2);
                esfera3.useGravity = false;
                esfera3.isKinematic = true;
            }
        }
    }

    public void cambiar()
    {
        pos = inicial;
        esfera.useGravity = false;
        esfera2.useGravity = false;
        esfera3.useGravity = false;
        esfera.GetComponent<Rigidbody>().drag = 1F;
        esfera2.GetComponent<Rigidbody>().drag = 1F;
        esfera3.GetComponent<Rigidbody>().drag = 1F;

        if (material.text == "Material 1")
        {
            esfera.transform.position = esfera2.transform.position;
            esfera2.transform.position = cubo.transform.position;
            material.text = "Material 2";
            peso.text = "10";
            transform.position = inicial;
        }
        else if (material.text == "Material 2")
        {
            esfera2.transform.position = esfera3.transform.position;
            esfera3.transform.position = cubo.transform.position;
            material.text = "Material 3";
            peso.text = "3.10";
            transform.position = inicial;
            esfera3.isKinematic = false;
        }
        else if (material.text == "Material 3")
        {
            esfera3.transform.position = esfera.transform.position;
            esfera.transform.position = cubo.transform.position;
            material.text = "Material 1";
            peso.text = "4.90";
            transform.position = inicial;
        }
    }
}
