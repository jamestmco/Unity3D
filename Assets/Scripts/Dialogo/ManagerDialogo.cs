using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerDialogo : MonoBehaviour
{
    public Text textoNome;
    public Text textoDialogo;
    public Animator animacao;
    public AudioClip escrita;
    public GameObject[] objetosDialogo;

    private Queue<string> frases;

    private MovimentoJogador referencia;

    void Awake()
    {
        frases = new Queue<string>();

        referencia = GameObject.Find("JogadorFP").GetComponent<MovimentoJogador>();
    }

    public void iniciaDialogo(Dialogo dialogo)
    {
        referencia.GetComponent<MovimentoJogador>().aCaminhar = false;
        Camera.main.GetComponent<MovimentoCamara>().enabled = false;
        animacao.SetBool("CaixaAberta", true);

        textoNome.text = dialogo.nome;

        frases.Clear();
        foreach (string frase in dialogo.frases)
        {
            frases.Enqueue(frase);
        }
        mostraProxima();
    }

    /*public void Update()
    {
        if (textoDialogo.isActiveAndEnabled)
        {
            mostraProxima();
        }
    }*/

    public void mostraProxima()
    {
        if(frases.Count == 0)
        {
            fimDialogo();
            return;
        }

        string frase = frases.Dequeue();
        //textoDialogo.text = frase;
        StopAllCoroutines();
        StartCoroutine(FraseAnimacao(frase));
    }

    IEnumerator FraseAnimacao(string frase)
    {
        AudioSource som = GetComponent<AudioSource>();
        som.PlayOneShot(escrita);
        textoDialogo.text = "";
        foreach (char letra in frase.ToCharArray())
        {
            textoDialogo.text += letra;
            yield return new WaitForSeconds(0.03f);
        }
        som.Stop();
        //yield return new WaitForSeconds(4f);
    }

    void fimDialogo()
    {
        animacao.SetBool("CaixaAberta", false);
        objetosDialogo = GameObject.FindGameObjectsWithTag("Dialogo");
        foreach( GameObject objetoDialogo in objetosDialogo)
        {
            objetoDialogo.SetActive(false);
        }
        referencia.GetComponent<MovimentoJogador>().aCaminhar = true;
        Camera.main.GetComponent<MovimentoCamara>().enabled = true;
        
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -4);
        }
    }
}

 