using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Algoritmo
{
    protected Celula[,] celulas;
    protected int linha, coluna;

    protected Algoritmo(Celula[,] celulas) : base()
    {
        this.celulas = celulas;
        linha = celulas.GetLength(0);
        coluna = celulas.GetLength(1);
    }

    public abstract void CriarLab();
}
