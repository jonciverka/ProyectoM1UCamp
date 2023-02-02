using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 using System.Collections;
public class Ronda : MonoBehaviour
{
    //como puedo indentificar que script, Este tipo de scripts van bien aqui?
    //Variables globals
    // Esta bien poner paneles completos para instrucciones?
    int ronda = 0;//cual es la manera mas facituble de hacerlo
    public TMP_Text textoRonda;
    public TMP_Text textoPuntuacion;
    public GameObject Jugador;
    int puntuacion = 0;
    void Start(){
        Jugador.gameObject.SetActive (true);
    }
   
    void OnRenderObject(){
        textoRonda.text = "Ronda " + ronda;// esta bien estar imprimiendo a cada rato?
        textoPuntuacion.text = "Puntos " + puntuacion;// esta bien estar imprimiendo a cada rato?
    }
    public void aumentarRonda(){
        ronda += 1;
    }
    public void puntuacionPerfecta(){
        puntuacion += 100;
    }
     public void puntuacionMedia(){
        puntuacion += 50;
    }
    public int obtenerPuntuaje(){
        return puntuacion; 
    }
    
}
