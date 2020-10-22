using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class RaposaAlt : MonoBehaviour
{
    //public GameObject poder;
    //public GameObject braco;
    //public Vector3 posicao;

    //public bool poderOn;
    //public GameObject cura;

    private FadaHolder referencia;
    private Animator raposaAnimador;

    public bool estaLevantada;

    private Transform jogador;

    private float distancia;
    public bool ativarRaposa;
    public GazeAware gazeAware;

    // Start is called before the first frame update
    void Start()
    {
        referencia = GameObject.Find("FadaHolder").GetComponent<FadaHolder>();
        raposaAnimador = GetComponent<Animator>();
        estaLevantada = false;

        //jogador = GameObject.Find("Cylinder").transform;
        jogador = GameObject.FindGameObjectWithTag("Player").transform;

        ativarRaposa = false;
    }

    // Update is called once per frame
    public void Update()
    {
            if (referencia.poderOn == false)
            {
                //raposaAnimador.SetTrigger("Levanta");
                Debug.Log("Poder Off!");

            }
            else if(referencia.poderOn == true)
            {
                raposaAnimador.SetTrigger("Levanta");
                Debug.Log("Poder On!");
            }

        if (raposaAnimador.GetCurrentAnimatorStateInfo(0).IsName("Armature|Idle"))
        {
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, jogador.rotation, 1f);
            Vector3 rotacaoAlvo = new Vector3(jogador.position.x, this.transform.position.y, jogador.position.z);
            this.transform.LookAt(rotacaoAlvo * 0.01f);
            transform.Rotate(0, 180, 0);
        }

        distancia = Vector3.Distance(jogador.position, transform.position);

        if (distancia < 5f || gazeAware.HasGazeFocus)
        {
            StartCoroutine("LigaDesliga");
        }
    }

    public void EsperaPortal()
    {
        StartCoroutine("LigarPortal");
    }

    IEnumerator LigaDesliga()
    {
        ativarRaposa = true;
        yield return new WaitForSeconds(0.1f);
        ativarRaposa = false;
    }

    IEnumerator LigarPortal()
    {
        yield return new WaitForSeconds(1f);
        estaLevantada = true;
    }
}
