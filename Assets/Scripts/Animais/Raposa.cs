using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class Raposa : MonoBehaviour
{
    private Transform jogador;
    private float distancia;
    public GameObject dialogoRaposa;

    public Color corSelecao;
    private GazeAware componenteGazeAware;
    private MeshRenderer mesh;
    private Color corNormal;
    private Color corLerp;
    private float velocidadeFade = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
        componenteGazeAware = GetComponent<GazeAware>();
        mesh = GetComponent<MeshRenderer>();
        corLerp = mesh.material.color;
        corNormal = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector3.Distance(jogador.position, transform.position);

        if(distancia <= 5f)
        {
            dialogoRaposa.SetActive(true);
        }

        if (mesh.material.color != corLerp)
        {
            mesh.material.color = Color.Lerp(mesh.material.color, corLerp, velocidadeFade);
        }

        // Change the color of the cube
        if (componenteGazeAware.HasGazeFocus)
        {
            SetLerpColor(corSelecao);
        }
        else
        {
            SetLerpColor(corNormal);
        }
    }

    public void SetLerpColor(Color lerpCor)
    {
        this.corLerp = lerpCor;
    }
}
