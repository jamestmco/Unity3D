using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Nivel : MonoBehaviour
{
    public GameObject canvasFade;
    public Image fadeInOut;
    public GameObject dialogoInicio;

    private Transform jogador;

    private Veado referenciaVeado;

    public void Start()
    {
        canvasFade.SetActive(true);
        fadeInOut.canvasRenderer.SetAlpha(1f);
        fadeIO();
        if (dialogoInicio.activeInHierarchy) 
        { 
            dialogoInicio.SetActive(false);
        }
        StartCoroutine(EsperaDialogo());

        jogador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            referenciaVeado = GameObject.Find("Veado").GetComponent<Veado>();
        }

        if (referenciaVeado.prontoADestruir)
        {
            StartCoroutine("Aguarda");
        }
    }

    public void fadeIO()
    {
        fadeInOut.CrossFadeAlpha(0f, 2f, false);
    }

    public void OnTriggerEnter(Collider colisao)
    {
        //if (SceneManager.GetActiveScene().buildIndex != 3)
        //{
            StartCoroutine(EsperaFade());
        //} 
    }

    public void Proximo()
    {
        StartCoroutine(EsperaFade());
    }

    IEnumerator EsperaFade()
    {
        fadeInOut.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        jogador.position = new Vector3(0, 1, 0);
        fadeInOut.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);
    }

    IEnumerator EsperaDialogo()
    {
        yield return new WaitForSeconds(1f);
        dialogoInicio.SetActive(true);
    }

    IEnumerator Aguarda()
    {
        yield return new WaitForSeconds(6f);
        fadeInOut.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        fadeInOut.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);
    }
}
