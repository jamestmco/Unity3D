using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fada : MonoBehaviour
{
    //private float distancia;
    public float movimento;

    //public float velocidadeVerticalidade;
    //public float amplitude;

    private Vector3 posicaoHolder;

    private GameObject pontoFada;

    //public GameObject braco;
    public Vector3 posicaoJogador;

    private GameObject jogadorCilindro;
    public FadaHolder referencia;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    public void Start()
    {
        pontoFada = GameObject.Find("FadaHolder");
        jogadorCilindro = GameObject.Find("FadaJogador");
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (referencia.poderOn == false)
        {
            posicaoHolder = new Vector3(pontoFada.transform.position.x, pontoFada.transform.position.y, pontoFada.transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, posicaoHolder, movimento * Time.deltaTime);
        }
        else if (referencia.poderOn == true)
        {
            posicaoJogador = new Vector3(jogadorCilindro.transform.position.x, jogadorCilindro.transform.position.y, jogadorCilindro.transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, posicaoJogador, movimento * Time.deltaTime);
        }

        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 4)
        {
            Destroy(gameObject);
        }
    }
}
