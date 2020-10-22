using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming; //AQUI

public class Lobo : MonoBehaviour
{
    public AnimationClip uivo;
    private Animator loboAnimador;
    private float esperar;
    public AudioClip au;

    public bool rodeado;
    public FadaHolder referencia;

    public GazeAware gazeAware; //AQUI
    private Transform jogador;
    private float distancia;
    public bool ativarLobo;

    public void Start()
    {
        rodeado = true;

        referencia = GameObject.Find("FadaHolder").GetComponent<FadaHolder>();

        if (rodeado)
        {
            loboAnimador = GetComponent<Animator>();
            esperar = uivo.length + 8f;
            InvokeRepeating("TocaUivar", 8f, esperar);
        }

        jogador = GameObject.FindGameObjectWithTag("Player").transform;

        gazeAware = GetComponent<GazeAware>(); //AQUI
        ativarLobo = false; //AQUI
    }

    public void Update()
    {
        if (referencia.poderOn == true)
        {
            rodeado = false;
        }

        distancia = Vector3.Distance(jogador.position, transform.position); //AQUI

        if (distancia < 7f || gazeAware.HasGazeFocus) //AQUI
        {
            StartCoroutine("LigaDesliga");
        }
    }
    
    void TocaUivar()
    {
        if (rodeado)
        {
            loboAnimador.SetTrigger("Uivar");
            AudioSource som = GetComponent<AudioSource>();
            som.PlayOneShot(au);
        }
        else
        {
            loboAnimador.ResetTrigger("Uivar");
            loboAnimador.SetTrigger("Livre");
        }
    }

    IEnumerator LigaDesliga() //AQUI
    {
        ativarLobo = true;
        yield return new WaitForSeconds(0.1f);
        ativarLobo = false;
    }
}
