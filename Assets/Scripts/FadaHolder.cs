using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadaHolder : MonoBehaviour
{
    private GameObject pontoFada;

    private GameObject jogadorCilindro;
    //public RaposaAlt referencia;

    public bool poderOn;
    public GameObject cura;
    private GameObject tempoRewind;
    private GameObject vedacao;

    private Animator vedacaoAnimacao;

    private GameObject natura;

    private Nivel referenciaNivel;

    private MovimentoJogador referenciaJogador;

    private RaposaAlt referenciaRaposa;
    private Lobo referenciaLobo;
    private Veado referenciaVeado;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        pontoFada = GameObject.Find("FadaHolder");
        jogadorCilindro = GameObject.Find("FadaJogador");
        poderOn = false;
        cura.SetActive(false);
        referenciaJogador = GameObject.Find("JogadorFP").GetComponent<MovimentoJogador>();

        referenciaRaposa = GameObject.Find("FoxMix").GetComponent<RaposaAlt>();
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            tempoRewind = GameObject.Find("TempoRewind");
            vedacao = GameObject.Find("Vedacao");
            vedacaoAnimacao = vedacao.GetComponent<Animator>();
            referenciaLobo = GameObject.Find("WolfMix").GetComponent<Lobo>();
        }

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            natura = GameObject.Find("Natura");
            referenciaVeado = GameObject.Find("DeerMix").GetComponent<Veado>();
        }

        if (Input.GetKeyDown(KeyCode.X) || referenciaRaposa.ativarRaposa==true || referenciaLobo.ativarLobo==true || referenciaVeado.ativarVeado==true)
        {
            if (referenciaRaposa.estaLevantada==false || referenciaLobo.rodeado==true || referenciaVeado.prontoADestruir==false)
            {
                StartCoroutine("Ativar");
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);
        }
    }

    /*public void AtualizaPosicao()
    {
        pontoFada.transform.position = transform.position;
    }

    public void AlteraPosicao()
    {
        jogadorCilindro.transform.position = transform.position;
    }*/

    IEnumerator Ativar()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (poderOn == false)
            {
                referenciaJogador.GetComponent<MovimentoJogador>().aCaminhar = false;
                poderOn = true;
                cura.SetActive(true);
                Debug.Log("Alteração recebida");
                yield return new WaitForSeconds(6f);
                poderOn = false;
                cura.SetActive(false);
                referenciaJogador.GetComponent<MovimentoJogador>().aCaminhar = true;
                StopAllCoroutines();
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (poderOn == false)
            {
                referenciaJogador.GetComponent<MovimentoJogador>().aCaminhar = false;
                poderOn = true;
                tempoRewind.transform.GetChild(0).transform.gameObject.SetActive(true);
                Debug.Log("Alteração recebida");
                vedacaoAnimacao.SetTrigger("Retroceder");
                yield return new WaitForSeconds(0.5f);
                vedacao.SetActive(false);
                yield return new WaitForSeconds(5.5f);
                poderOn = false;
                tempoRewind.SetActive(false);
                referenciaJogador.GetComponent<MovimentoJogador>().aCaminhar = true;
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (poderOn == false)
            {
                referenciaJogador.GetComponent<MovimentoJogador>().aCaminhar = false;
                poderOn = true;
                natura.transform.GetChild(0).transform.gameObject.SetActive(true);
                Debug.Log("Alteração recebida");
                yield return new WaitForSeconds(6f);
                poderOn = false;
                natura.SetActive(false);
                //referenciaNivel.Proximo();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
