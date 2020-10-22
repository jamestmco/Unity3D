using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalHolder : MonoBehaviour
{
    private RaposaAlt referenciaRaposa;
    private Lobo referenciaLobo;

    private MovimentoJogador referenciaJogador;

    public GameObject portal;

    // Start is called before the first frame update
    public void Start()
    {
        referenciaRaposa = GameObject.Find("FoxMix").GetComponent<RaposaAlt>();

        referenciaJogador = GameObject.Find("JogadorFP").GetComponent<MovimentoJogador>();    
        
        portal = transform.GetChild(0).transform.gameObject;
    }

    // Update is called once per frame
    public void Update()
    {
        portal = transform.GetChild(0).transform.gameObject;
        //var portalPosicao = new Vector3(transform.GetChild(0).transform.rotation.x, transform.GetChild(0).transform.rotation.y, transform.GetChild(0).transform.rotation.z);
        //var eView = GetComponent<ExtendedViewFirstPerson>();
        //Camera eViewCamera = eView.CameraWithExtendedView;
        //Transform eViewTransform = eViewCamera.transform;
        //Quaternion eViewQuat = eViewTransform.rotation;

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (referenciaRaposa.estaLevantada == true)
            {
                //transform.GetChild(0).transform.gameObject.SetActive(true);
                portal.SetActive(true);
                //eViewQuat.SetLookRotation(portalPosicao);
                //referenciaJogador.aCaminhar = true;
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            referenciaLobo = GameObject.Find("WolfMix").GetComponent<Lobo>();

            if (referenciaLobo.rodeado == false)
            {
                StartCoroutine("Espera");
            }
        }
    }

    IEnumerator Espera()
    {
        yield return new WaitForSeconds(2f);
        //transform.GetChild(0).transform.gameObject.SetActive(true);
        portal.SetActive(true);
    }
}
