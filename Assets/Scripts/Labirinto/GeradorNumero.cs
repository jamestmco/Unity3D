using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GeradorNumero
{
    public static int PosicaoAtual = 0;
    public const string chave1 = "1234314231244132";
    public const string chave2 = "131324313124123421334";
    public const string chave3 = "213444314132412343212344132";
    //multiplicar dias por mes por ano por PI

    public static int Proximo()
    {
        int numero = 0;
        if (SceneManager.GetActiveScene().buildIndex == 1) 
        { 
            string numeroAtual = chave1.Substring(PosicaoAtual++ % chave1.Length, 1);
            numero = int.Parse(numeroAtual);
        }
        else if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            string numeroAtual = chave2.Substring(PosicaoAtual++ % chave2.Length, 1);
            numero = int.Parse(numeroAtual);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            string numeroAtual = chave3.Substring(PosicaoAtual++ % chave3.Length, 1);
            numero = int.Parse(numeroAtual);
        }
        return numero;
    }
}
