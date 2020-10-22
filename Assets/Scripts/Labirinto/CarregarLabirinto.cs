using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarregarLabirinto : MonoBehaviour
{
    public int linha, coluna;
    public GameObject parede;
    public float tamanho = 5f;
    private Celula[,] celulas;

    void Start()
    {
        ComecaLab();

        Algoritmo algor = new Elimina(celulas);
        algor.CriarLab();
    }


    private void ComecaLab()
    {
        celulas = new Celula[linha, coluna];

        for (int l=0; l < linha; l++)
        {
            for (int c=0; c < coluna; c++)
            {
                celulas[l,c] = new Celula();

                if (c == 0)
                {
                    celulas[l,c].paredeEsquerda = Instantiate(parede, new Vector3(l*tamanho, 0, (c*tamanho) - (tamanho/2f)), Quaternion.identity) as GameObject;
                }

                celulas[l, c].paredeDireita = Instantiate(parede, new Vector3(l * tamanho, 0, (c * tamanho) + (tamanho/2f)), Quaternion.identity) as GameObject;

                if (l == 0)
                {
                    celulas[l, c].paredeCima = Instantiate(parede, new Vector3((l * tamanho) - (tamanho/2f), 0, c * tamanho), Quaternion.identity) as GameObject;
                    celulas[l, c].paredeCima.transform.Rotate(Vector3.up * 90f);
                }

                celulas[l,c].paredeBaixo = Instantiate(parede, new Vector3((l*tamanho) + (tamanho/2f), 0, c*tamanho), Quaternion.identity) as GameObject;
                celulas[l,c].paredeBaixo.transform.Rotate(Vector3.up * 90f);
            }
        }
    }
}
