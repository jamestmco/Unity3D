using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public static bool jogoPausado = false;
    public GameObject menuPausa;
    public GameObject menuOpcoes;
    public GameObject menuVolume;
    public GameObject menuSensibilidade;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(menuPausa.activeInHierarchy == false && menuOpcoes.activeInHierarchy == false && menuVolume.activeInHierarchy == false && menuSensibilidade.activeInHierarchy == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (jogoPausado)
                {
                    RetomarJogo();
                }
                else
                {
                    Pausar();
                }
            }
        }
    }

    public void RetomarJogo()
    {
        Camera.main.GetComponent<MovimentoCamara>().enabled = true;
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        jogoPausado = false;
    }

    public void Pausar()
    {
        Camera.main.GetComponent<MovimentoCamara>().enabled = false;
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        jogoPausado = true;
    }

    public void SairJogo()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Time.timeScale = 1f;
            Destroy(gameObject);
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
            Time.timeScale = 1f;
            Destroy(gameObject);
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
            Time.timeScale = 1f;
            Destroy(gameObject);
        }
    }
}
