using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elimina : Algoritmo
{
    private int linhaAtual = 0;
    private int colunaAtual = 0;

    private bool correutudo = false;

    public Elimina(Celula[,] celulas) : base(celulas)
    {
    }

    public override void CriarLab()
    {
        ProcuraElimina();
    }

    private void ProcuraElimina()
    {
        celulas[linhaAtual, colunaAtual].esteveaqui = true;
        while (!correutudo)
        {
            Eliminar();
            Procurar();
        }
    }

    private void Eliminar()
    {
        while (RotaDisponivel(linhaAtual, colunaAtual))
        {
            //int direcao = GeradorNumero.Proximo();
            int direcao = Random.Range(0, 5);

            if (direcao == 1 && CelulaDisponivel(linhaAtual - 1, colunaAtual))
            {
                EliminaParede(celulas[linhaAtual, colunaAtual].paredeCima);
                EliminaParede(celulas[linhaAtual - 1, colunaAtual].paredeBaixo);
                linhaAtual--;
            }
            else if (direcao == 2 && CelulaDisponivel(linhaAtual + 1, colunaAtual))
            {
                EliminaParede(celulas[linhaAtual, colunaAtual].paredeBaixo);
                EliminaParede(celulas[linhaAtual + 1, colunaAtual].paredeCima);
                linhaAtual++;
            }
            else if (direcao == 3 && CelulaDisponivel(linhaAtual, colunaAtual - 1))
            {
                EliminaParede(celulas[linhaAtual, colunaAtual].paredeEsquerda);
                EliminaParede(celulas[linhaAtual, colunaAtual - 1].paredeDireita);
                colunaAtual--;
            }
            else if (direcao == 4 && CelulaDisponivel(linhaAtual, colunaAtual + 1))
            {
                EliminaParede(celulas[linhaAtual, colunaAtual].paredeDireita);
                EliminaParede(celulas[linhaAtual, colunaAtual + 1].paredeEsquerda);
                colunaAtual++;
            }

            celulas[linhaAtual, colunaAtual].esteveaqui = true;
        }
    }

    private void Procurar()
    {
        correutudo = true;

        for (int l = 0; l < linha; l++)
        {
            for (int c = 0; c < coluna; c++)
            {
                if (!celulas[l, c].esteveaqui && CelulaAdjacente(l, c))
                {
                    correutudo = false;
                    linhaAtual = l;
                    colunaAtual = c;
                    EliminaAdjacente(linhaAtual, colunaAtual);
                    celulas[linhaAtual, colunaAtual].esteveaqui = true;
                    return;
                }
            }
        }
    }

    private bool RotaDisponivel(int linh, int col)
    {
        int rotasDisponiveis = 0;

        if (linh > 0 && !celulas[linh - 1, col].esteveaqui)
        {
            rotasDisponiveis++;
        }

        if (linh < linha - 1 && !celulas[linh + 1, col].esteveaqui)
        {
            rotasDisponiveis++;
        }

        if (col > 0 && !celulas[linh, col - 1].esteveaqui)
        {
            rotasDisponiveis++;
        }

        if (col < coluna - 1 && !celulas[linh, col + 1].esteveaqui)
        {
            rotasDisponiveis++;
        }

        return rotasDisponiveis > 0;
    }

    private bool CelulaDisponivel(int linh, int col)
    {
        if (linh >= 0 && linh < linha && col >= 0 && col < coluna && !celulas[linh, col].esteveaqui)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void EliminaParede(GameObject parede)
    {
        if (parede != null)
        {
            GameObject.Destroy(parede);
        }
    }

     private bool CelulaAdjacente(int linh, int col)
    {
        int passeiCelula = 0;

        if(linh>0 && celulas[linh -1, col].esteveaqui)//Cima
        {
            passeiCelula++;
        }
        if(linh<(linha-2) && celulas[linh+1, col].esteveaqui)//Baixo
        {
            passeiCelula++;
        }
        if(col>0 && celulas[linh, col -1].esteveaqui)//Esquerda
        {
            passeiCelula++;
        }
        if(col<(coluna-2) && celulas[linh, col + 1].esteveaqui)//Direita
        {
            passeiCelula++;
        }
        return passeiCelula > 0;
    }

     private void EliminaAdjacente(int linh, int col)
    {
        bool paredeEliminada = false;

        while (!paredeEliminada)
        {
            int direcao = GeradorNumero.Proximo();

            if(direcao == 1 && linh > 0 && celulas[linh-1, col].esteveaqui)
            {
                EliminaParede(celulas[linh, col].paredeCima);
                EliminaParede(celulas[linh - 1, col].paredeBaixo);
                paredeEliminada = true;
            }
            if (direcao == 2 && linh < (linha - 2) && celulas[linh+1, col].esteveaqui)
            {
                EliminaParede(celulas[linh, col].paredeBaixo);
                EliminaParede(celulas[linh + 1, col].paredeCima);
                paredeEliminada = true;
            }
            if (direcao == 4 && col > 0 && celulas[linh, col - 1].esteveaqui)
            {
                EliminaParede(celulas[linh, col].paredeEsquerda);
                EliminaParede(celulas[linh, col - 1].paredeDireita);
                paredeEliminada = true;
            }
            if (direcao == 3 && col < (coluna - 2) && celulas[linh, col+1].esteveaqui)
            {
                EliminaParede(celulas[linh, col].paredeDireita);
                EliminaParede(celulas[linh, col+1].paredeEsquerda);
                paredeEliminada = true;
            }
        }
    }
}












