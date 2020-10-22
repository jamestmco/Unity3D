using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class DialogoSeguinte : MonoBehaviour
{
    public GazeAware gazeAware;
    public ManagerDialogo referencia;

    // Start is called before the first frame update
    void Start()
    {
        gazeAware = GetComponent<GazeAware>();
        referencia = GameObject.Find("ManagerDialogo").GetComponent<ManagerDialogo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gazeAware.HasGazeFocus)
        {
            StartCoroutine("EsperaSeguinte");
        }
    }

    IEnumerator EsperaSeguinte()
    {
        yield return new WaitForSeconds(5f);
        referencia.mostraProxima();
    }
}
