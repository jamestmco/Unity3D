using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Poder : MonoBehaviour
{
    public Material maosterial;
    Color corBase = new Color(0.5f, 0.53f, 0.53f, 1f);
    private GameObject braco;
    private Animator animaBraco;
    private FadaHolder referencia;

    public void Start()
    {
        maosterial.DisableKeyword("_EMISSION");
        maosterial.SetColor("_EmissionColor", Color.black);
        braco = this.transform.parent.gameObject;
        animaBraco = braco.GetComponent<Animator>();
        referencia = GameObject.Find("FadaHolder").GetComponent<FadaHolder>();
    }

    public void FixedUpdate()
    {
        if (referencia.poderOn == true)
        {
            StartCoroutine("AtivaPoder");
        }
        else if(referencia.poderOn==false)
        {
            Debug.Log("Mudar");
            maosterial.DisableKeyword("_EMISSON");
            maosterial.SetColor("_EmissionColor", Color.black);
        }
    }

    IEnumerator AtivaPoder()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            maosterial.EnableKeyword("_EMISSION");
            maosterial.SetColor("_EmissionColor", new Color(0.4f, 0.8f, 0.3f, 1f) * 1.8f);
            animaBraco.SetTrigger("Poder");
            yield return new WaitForSeconds(0.1f);
            animaBraco.ResetTrigger("Poder");
            animaBraco.SetTrigger("Idle");
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            maosterial.EnableKeyword("_EMISSION");
            maosterial.SetColor("_EmissionColor", new Color(0.3f, 0f, 1f, 0.5f) * 1.6f);
            animaBraco.SetTrigger("Poder");
            yield return new WaitForSeconds(0.1f);
            animaBraco.ResetTrigger("Poder");
            animaBraco.SetTrigger("Idle");
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            maosterial.EnableKeyword("_EMISSION");
            maosterial.SetColor("_EmissionColor", new Color(0.2f, 0.8f, 1f, 1f) * 1.5f);
            animaBraco.SetTrigger("Poder");
            yield return new WaitForSeconds(0.1f);
            animaBraco.ResetTrigger("Poder");
            animaBraco.SetTrigger("Idle");
        }
    }
}