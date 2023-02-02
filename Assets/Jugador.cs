using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    //como obtener elementos no visibles
    public GameObject[] imagesPlayer;
    public GameObject[] imagesPlayerMuerto;
    public GameObject[] imagesPlayerDisparar;
    private GameObject enemigoActual;//esta bien?
    private Enemigo enemigo;
    int index = 0;
    bool auxMostrarPlayer = true;
    bool auxMostrarPlayerDisparar = true;
    public Preguntas preguntas;
    public PanelInicio panelInicio;
    bool aux = false;
    bool disparar = false;

    void Start(){
        InvokeRepeating("mostrarPlayer", .2f, .2f);
        enemigoActual = GameObject.FindGameObjectsWithTag("Enemigo")[0] ;
        enemigo = enemigoActual.GetComponent<Enemigo>();
    }

    // Update is called once per frame
    void mostrarPlayer(){
        if(enemigo.getEsAtacar()){
            if(auxMostrarPlayer){
                imagesPlayer[index-1].gameObject.SetActive (false);
                auxMostrarPlayer = false;
                index= 0;
            }
            if(index>=imagesPlayerMuerto.Length){
                preguntas.pintarBotonCorrecto();
                CancelInvoke ("mostrarPlayer");
                StartCoroutine(passiveMe(2,false));
            }
            if(index!=0 && index!=imagesPlayerMuerto.Length){
                imagesPlayerMuerto[index-1].gameObject.SetActive (false);
            }
            if(index!=imagesPlayerMuerto.Length){
                imagesPlayerMuerto[index].gameObject.SetActive (true);
                index++;
            }
        }else if(disparar){
            if(auxMostrarPlayerDisparar){
                imagesPlayer[index-1].gameObject.SetActive (false);
                auxMostrarPlayerDisparar = false;
                index= 0;
            }
            if(index!=0 && index!=imagesPlayerDisparar.Length){
                imagesPlayerDisparar[index-1].gameObject.SetActive (false);
            }
            if(index!=imagesPlayerDisparar.Length){
                imagesPlayerDisparar[index].gameObject.SetActive (true);
                index++;
            }
            if(index>=imagesPlayerDisparar.Length){
                imagesPlayerDisparar[index-1].gameObject.SetActive (false);
                imagesPlayer[0].gameObject.SetActive (true);
                disparar = false;
                auxMostrarPlayerDisparar = true;
                index= 0;
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
    public IEnumerator passiveMe(int secs, bool esCorrectoBool){
        yield return new WaitForSeconds(secs);
        panelInicio.finalizarJuego();
    }
    public void iniciarlizarEnemigo(){
        enemigoActual = GameObject.FindGameObjectsWithTag("Enemigo")[0] ;
        enemigo = enemigoActual.GetComponent<Enemigo>();
    }
    public void setDisparar(){
        disparar = true;
        enemigo.matarEnemigo(enemigoActual);
        if(GameObject.FindGameObjectsWithTag("Enemigo").Length>=1){
            iniciarlizarEnemigo();
        }
    }
   
}
