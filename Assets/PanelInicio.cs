using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelInicio : MonoBehaviour
{
    //Est abien poner aqui ocultar todos los paneles? o es recomendable hacer un script para cada "Intrccion" 
    public GameObject panel;
    public GameObject InterFaceUser;
    public GameObject Intruccion;
    public GameObject finalizar;
    public GameObject ganado;
  
 
    public void iniciarJuego(){
        Intruccion.gameObject.SetActive (false);
        InterFaceUser.gameObject.SetActive (true);
    }
    public void mostrarInstrucciones(){
        panel.gameObject.SetActive (false);
        Intruccion.gameObject.SetActive (true);
    }
    public void juegoGanado(){
        InterFaceUser.gameObject.SetActive (false);
        ganado.gameObject.SetActive (true);
    }
    
    
    public void finalizarJuego(){
        InterFaceUser.gameObject.SetActive (false);
        finalizar.gameObject.SetActive (true);

    }
   
}
