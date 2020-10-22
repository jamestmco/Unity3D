using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class Veado : MonoBehaviour
{
    public FadaHolder referencia;
    public GameObject labirinto;
    public Transform jogador;

    public GameObject[] paredes;
    //public Animator paredeAnimador;

    public bool prontoADestruir;

    public GazeAware gazeAware;
    private float distancia;
    public bool ativarVeado;

    // Start is called before the first frame update
    public void Start()
    {
        referencia = GameObject.Find("FadaHolder").GetComponent<FadaHolder>();
        labirinto = GameObject.Find("Jogo");
        jogador = GameObject.FindGameObjectWithTag("Player").transform;

        prontoADestruir = false;

        gazeAware = GetComponent<GazeAware>(); //AQUI
        ativarVeado = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if (referencia.poderOn)
        {
            labirinto.SetActive(false);
                        
            GameObject[] paredes = GameObject.FindGameObjectsWithTag("Parede");
            foreach (GameObject parede in paredes)
            {
                prontoADestruir = true;
                //Destroy(parede, 5f);
            }
        }

        Vector3 rotacaoAlvo = new Vector3(jogador.position.x, this.transform.position.y, jogador.position.z);
        this.transform.LookAt(rotacaoAlvo);
        transform.Rotate(0, 90, 0);

        distancia = Vector3.Distance(jogador.position, transform.position);

        if (distancia < 7f || gazeAware.HasGazeFocus)
        {
            StartCoroutine("LigaDesliga");
        }
    }

    IEnumerator LigaDesliga()
    {
        ativarVeado = true;
        yield return new WaitForSeconds(0.1f);
        ativarVeado = false;
    }
}
