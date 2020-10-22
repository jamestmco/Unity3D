using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimentoCamara : MonoBehaviour
{
    public Transform Jogador;
    float movimentoX;
    float movimentoY;
    float rodaX;
    public float sensibilidade = 150f;
    //private bool naProximidade;
    public Slider sliderSensibilidade;

    public CharacterController controlador;
    private MovimentoJogador referencia;

    private ExtendedViewFirstPerson eView;
    private Camera eViewCamera;
    private Transform eViewTransform;

    public Slider sliderVelocidade;
    public float velocidade = 1f;

    public Vector3 direcao;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        rodaX = 0f;

        sliderSensibilidade.minValue = 10f;
        sliderSensibilidade.maxValue = 1000f;
        sliderSensibilidade.value = 400f;
        sliderSensibilidade.wholeNumbers = true;

        eView = GetComponent<ExtendedViewFirstPerson>();

        referencia = GameObject.Find("JogadorFP").GetComponent<MovimentoJogador>();

        sliderVelocidade.minValue = 1f;
        sliderVelocidade.maxValue = 15f;
        sliderVelocidade.value = 1f;
        sliderVelocidade.wholeNumbers = true;
    }

    /*void OnTriggerEnter(Collider NPC1)
    {
        if (NPC1.gameObject.tag == "NPC")
        {
            naProximidade = true;
        }
    }*/

    public void Update()
    {
        movimentoX = Input.GetAxisRaw("Mouse X") * sensibilidade * Time.deltaTime;
        movimentoY = Input.GetAxisRaw("Mouse Y") * sensibilidade * Time.deltaTime;
        Jogador.Rotate(Vector3.up * movimentoX);

        rodaX -= movimentoY;
        transform.localRotation = Quaternion.Euler(rodaX, 0f, 0f);
        rodaX = Mathf.Clamp(rodaX, -35f, 35f);
        
        eView = GetComponent<ExtendedViewFirstPerson>();

        eViewCamera = eView.CameraWithExtendedView;
        eViewTransform = eViewCamera.transform;

        Vector3 direcao = new Vector3(eViewTransform.transform.forward.x, 0, eViewTransform.transform.forward.z);

        if (referencia.aCaminhar == true)
        {
            controlador.Move(direcao * velocidade * Time.deltaTime);
        }
        else
        {
            controlador.Move(new Vector3(0,0,0));
        }

        /* if (naProximidade)
         {
             Cursor.lockState = CursorLockMode.None;
         }
         else
         {
             Cursor.lockState = CursorLockMode.Locked;
         }*/
    }

    public void AlterarSensibilidade(float valorSensibilidade)
    {
        sensibilidade = valorSensibilidade;
    }

    public void AlterarVelocidade(float valorVelocidade)
    {
        velocidade = valorVelocidade;
    }
}
