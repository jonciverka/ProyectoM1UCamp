using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject[] imagesPlayer;
    public GameObject[] imagesPlayerAtaque;
    public GameObject[] imagesPlayerMuerto;
    public GameObject panel;
    private GameObject there;
    private Vector3 position;
    int index = 0;
    bool aux = false;
    bool auxMostrarPlayer = true;
    bool auxMostrarPlayerMuerto = true;
    bool esAtacar = false;
    bool esMatar = false;
    void Start(){
        position = new Vector3(960.50f, 385.45f, 0.00f);
    }
    public void iniciarMovimientos(){
        InvokeRepeating("mostrarPlayer", .2f, .2f);//Esta bien hacerlo con el invoke?
        InvokeRepeating("moverEnemigo", .2f, .2f);
        position = new Vector3(960.50f, 385.45f, 0.00f);
    }
    // Update is called once per frame
    void mostrarPlayer(){
        if(esAtacar){
            if(auxMostrarPlayer){
                imagesPlayer[index-1].gameObject.SetActive (false);
                auxMostrarPlayer = false;
            }
            if(index>=imagesPlayerAtaque.Length){
                imagesPlayerAtaque[index-1].gameObject.SetActive (false);
                index = 0;
                CancelInvoke ("mostrarPlayer");
                CancelInvoke ("moverEnemigo");
            }
            if(index!=0){
                imagesPlayerAtaque[index-1].gameObject.SetActive (false);
            }

            imagesPlayerAtaque[index].gameObject.SetActive (true);
            index++;
        }else if(esMatar){
             if(auxMostrarPlayerMuerto){
                imagesPlayer[index-1].gameObject.SetActive (false);
                auxMostrarPlayerMuerto = false;
                index= 0;
            }
            if(index>=imagesPlayerMuerto.Length){
                CancelInvoke ("mostrarPlayer");
                Destroy (there);                

            }
            if(index!=0 && index!=imagesPlayerMuerto.Length){
                imagesPlayerMuerto[index-1].gameObject.SetActive (false);
            }

            if(index!=imagesPlayerMuerto.Length){
                imagesPlayerMuerto[index].gameObject.SetActive (true);
                index++;
            }
        }else{
            if(index>=imagesPlayer.Length){
                imagesPlayer[index-1].gameObject.SetActive (false);
                index = 0;
            }
            if(index!=0){
                imagesPlayer[index-1].gameObject.SetActive (false);
            }
            imagesPlayer[index].gameObject.SetActive (true);
            index++;
        }
    }
     void moverEnemigo(){
        if(position.x<=-359.5009){
            esAtacar = true;
            position.x -= 0f;
        }else{
            position.x -= 13f;
        }
        panel.transform.position = position;
    }

    public bool getEsAtacar(){
        return esAtacar;
    }
    public void matarEnemigo(GameObject enemigo){
        CancelInvoke ("moverEnemigo");
        enemigo.tag = "Untagged";
        esMatar = true;
        there= enemigo;
        // Destroy (enemigo);
    }
   
   

}
