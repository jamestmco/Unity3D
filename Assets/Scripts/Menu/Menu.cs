using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Tobii.Gaming;

public class Menu : MonoBehaviour
{
    public Nivel referencia;
    private GazeAware gazeAware;

    public void IniciarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnTriggerEnter(Collider colisao)
    {
        referencia.Proximo();
    }

    public void Start()
    {
        gazeAware = GetComponent<GazeAware>();
    }

    public void Update()
    {
        if (gazeAware.HasGazeFocus)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void FecharJogo()
    {
        Application.Quit();
    }
}
