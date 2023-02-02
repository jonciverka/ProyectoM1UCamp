using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelFinalizar : MonoBehaviour
{
    public TMP_Text puntuaje;
    public Ronda ronda;

    void Start() {
        
    }
    void OnRenderObject(){
        puntuaje.text = ""+ronda.obtenerPuntuaje();

    }



}
