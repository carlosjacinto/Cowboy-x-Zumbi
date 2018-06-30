﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour, IMatavel, ICuravel { 
    
    private Vector3 direcao;
    public LayerMask MascaraChao;
    public GameObject TextoGameOver;
    public ControlaInterface scriptControlaInterface;
    public AudioClip SomDeDano;
    private MovimentoJogador meuMovimentoJogador;
    private AnimacaoPersonagem animacaoJogador;
    public Status statusJogador;

    void Start() {
        meuMovimentoJogador = GetComponent<MovimentoJogador>();
        animacaoJogador = GetComponent<AnimacaoPersonagem>();
        statusJogador = GetComponent<Status>();
    }
    
    void Update() {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");
        direcao = new Vector3(eixoX, 0, eixoZ);

        animacaoJogador.Movimentar(direcao.magnitude);
    }

    void FixedUpdate() {
        meuMovimentoJogador.Movimentar(direcao, statusJogador.Velocidade);
        meuMovimentoJogador.RotacaoJogador(MascaraChao);
    }

    public void TomarDano(int dano) {
        statusJogador.Vida -= dano;
        scriptControlaInterface.AtualizaSliderVidaJogador();
        ControlaAudio.instancia.PlayOneShot(SomDeDano);

        if(statusJogador.Vida <= 0) {
            Morrer();
        }
    }

    public void Morrer() {   
        scriptControlaInterface.Gameover();
    }

    public void CurarVida(int quantidadeDeCura) {
        statusJogador.Vida += quantidadeDeCura;
        if(statusJogador.Vida > statusJogador.vidaInicial) {
            statusJogador.Vida = statusJogador.vidaInicial;
        }
        scriptControlaInterface.AtualizaSliderVidaJogador();
    }
}
