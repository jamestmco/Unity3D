using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class Sair : MonoBehaviour
{
    private GazeAware gazeAware;

    // Start is called before the first frame update
    void Start()
    {
        gazeAware = GetComponent<GazeAware>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gazeAware.HasGazeFocus)
        {
            Application.Quit();
        }
    }
}
