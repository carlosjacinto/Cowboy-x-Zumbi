﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorChefe : MonoBehaviour {

    private float tempoParaProximaGeracao = 0;
    private float tempoEntreGeracoes = 40;
    public GameObject ChefePrefab;

    void Start() {
        tempoParaProximaGeracao = tempoEntreGeracoes;
    }

    private void Update() {
        if(Time.timeSinceLevelLoad > tempoParaProximaGeracao) {
            Instantiate(ChefePrefab, transform.position, Quaternion.identity);
            tempoParaProximaGeracao = Time.timeSinceLevelLoad + tempoEntreGeracoes;
        }
    }
}
