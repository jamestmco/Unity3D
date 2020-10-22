using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovimentoJogador : MonoBehaviour
{
    public CharacterController controlador;
    public float velocidade = 1f;
    public AudioClip caminhar;
    private AudioSource som;
    public Animator esquerda, direita;
    public Slider sliderVelocidade;

    //public GameObject objetoDialogo;
    public bool aCaminhar;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        //inventario.ItemUsado += SeguraUsa;
        som = GetComponent<AudioSource>();

        sliderVelocidade.minValue = 1f;
        sliderVelocidade.maxValue = 15f;
        sliderVelocidade.value = 1f;
        sliderVelocidade.wholeNumbers = true;

        aCaminhar = true;
}

    // Update is called once per frame
    public void Update()
    {
        //transform.Translate(Vector3.forward * (velocidade * Time.deltaTime));
        /*
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movimento = transform.right * horizontal + transform.forward * vertical;
        controlador.Move(movimento * velocidade * Time.deltaTime);
        */
        if (aCaminhar == true)
        {
            //controlador.Move(transform.forward * velocidade * Time.deltaTime);
            esquerda.SetTrigger("Caminhar");
            direita.SetTrigger("Caminhar");
            som.clip = caminhar;
            som.Play();
        }
        else if (aCaminhar == false)
        {
            //controlador.Move(new Vector3(0, 0, 0));
            esquerda.SetTrigger("Idle");
            direita.SetTrigger("Idle");
            som.Stop();
        }

        //objetoDialogo = GameObject.FindGameObjectWithTag("Dialogo");

        /*if (objetoDialogo.activeInHierarchy == false)
        {
            caminha = false;
        }
        if (objetoDialogo.activeInHierarchy == true)
        {
            caminha = true;
        }*/

        /*
        if (controlador.velocity.magnitude > 0.01 && !som.isPlaying)
        {
            esquerda.SetTrigger("Caminhar");
            direita.SetTrigger("Caminhar");
            som.clip = caminhar;
            som.Play();
        }
        else if(controlador.velocity.magnitude < 0.01 && som.isPlaying)
        {
            esquerda.SetTrigger("Idle");
            direita.SetTrigger("Idle");
            som.Stop();
        }*/

        /*
        if ((Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")) && !som.isPlaying)
        {
            esquerda.SetTrigger("Caminhar");
            direita.SetTrigger("Caminhar");
            som.clip=caminhar;
            som.Play();
        }
        else if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical") && som.isPlaying)
        {
            esquerda.SetTrigger("Idle");
            direita.SetTrigger("Idle");
            som.Stop();
        }
        */
        if(SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 4)
        {
            Destroy(gameObject);
        }
    }

    public void AlterarVelocidade(float valorVelocidade)
    {
        velocidade = valorVelocidade;
    }
}
