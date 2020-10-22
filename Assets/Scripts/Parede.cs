using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parede : MonoBehaviour
{
    private Animator paredeAnimador;
    private Veado referencia; 

    // Start is called before the first frame update
    void Start()
    {
        paredeAnimador = GetComponent<Animator>();
        referencia = GameObject.Find("DeerMix").GetComponent<Veado>();
    }

    // Update is called once per frame
    void Update()
    {
        if (referencia.prontoADestruir)
        {
            paredeAnimador.SetTrigger("Destruir");
        }
    }
}
