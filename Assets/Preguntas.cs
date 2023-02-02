using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

public class Preguntas : MonoBehaviour{
    public List <PreguntaObj> preguntasList = new List<PreguntaObj>();
    public TMP_Text textoBoton1;
    public TMP_Text textoBoton2;
    public TMP_Text textoBoton3;
    public TMP_Text textoBoton4;
    public TMP_Text pregunta;
    public Ronda ronda;
    public Jugador jugador;
    public GameObject enemigo;
    public PanelInicio panelInicio;
    public GameObject panelWating;
    public Transform parent;
    int index = 0;
    void Start() {
        preguntasList.Add(new PreguntaObj("¿Que videojuego fue hecho inicialmente en Java?","Minecraft,Fifa 2022,Zelda BOW,Horizon 5","Minecraft"));
        preguntasList.Add(new PreguntaObj("¿En que año se entrenó GTA V?","2007,2011,2013,2009","2013"));
        preguntasList.Add(new PreguntaObj("¿Cual de estos videojuegos es el mas vendido?","PUBG,GTA V,Minecraft,Terraria","Minecraft"));
        preguntasList.Add(new PreguntaObj("¿Cual fue la primera consola de la historia?","Megnavox,Atari,Cassete Vision,Famicom","Megnavox"));
        preguntasList.Add(new PreguntaObj("¿Cuantos fantasmas hay originalmente en PAC-MAN?","3,4,6,5","4"));
        preguntasList.Add(new PreguntaObj("¿Qúe compañía desarrollo el videojuego Mario Bros?","EA sports,POPCAP,Nintendo,Epic Games","Nintendo"));
        preguntasList.Add(new PreguntaObj("¿A que empresa pertenece sonic?","Nintendo,Konami,PopCap,Sega","Sega"));
        preguntasList.Add(new PreguntaObj("¿En que año se pubicó tetris?","1979,1984,1982,1986","1984"));
        
        for (int i = 0; i < preguntasList.Count; i++) {
             PreguntaObj temp = preguntasList[i];
             int randomIndex = Random.Range(i, preguntasList.Count);
             preguntasList[i] = preguntasList[randomIndex];
             preguntasList[randomIndex] = temp;
        }
        iniarEnemigos();
        
    }
    public void iniarEnemigos(){// esta bien tener un objeto que no se vea en pantalla?
        var enemigoClone = Instantiate(enemigo, parent);// esta bien instanciarlo asi? 
        Enemigo enemigoScript = enemigoClone.GetComponent<Enemigo>();
        enemigoScript.iniciarMovimientos();
        enemigoScript.tag =  "Enemigo";
        if(GameObject.FindGameObjectsWithTag("Enemigo").Length>=1){
            jugador.iniciarlizarEnemigo();
        }
    }
    void OnRenderObject(){
        if(index>=preguntasList.Count ){
            if(GameObject.FindGameObjectsWithTag("Enemigo").Length<=0){
                panelInicio.juegoGanado();
            }  else{
                panelInicio.finalizarJuego();

            } 
        }else{
            pregunta.text = preguntasList[index].pregunta;
            textoBoton1.text = preguntasList[index].respeustas[0];
            textoBoton2.text = preguntasList[index].respeustas[1];
            textoBoton3.text = preguntasList[index].respeustas[2];
            textoBoton4.text = preguntasList[index].respeustas[3];
        }
    }
    public  void  esCorrecto(Button  button){
        if(preguntasList[index].indexRespuestaCorrecta==button.GetComponent<Button>().GetComponentInChildren<TMP_Text>().text){
            button.GetComponent<Image>().color = Color.green;
            panelWating.gameObject.SetActive (true);
            StartCoroutine(passiveMe(1,true));
            jugador.setDisparar();
        }else{  
            pintarBotonCorrecto();
            iniarEnemigos();
            button.GetComponent<Image>().color =  Color.red;
            panelWating.gameObject.SetActive (true);
            StartCoroutine(passiveMe(1,false));
        }
    }
    public IEnumerator passiveMe(int secs, bool esCorrectoBool){
        yield return new WaitForSeconds(secs);
        siguientPregunta();
        if(esCorrectoBool){
            ronda.puntuacionPerfecta();
        }
    }
    public void siguientPregunta(){
        despintarTodosBotnes();
        index = index + 1 ;
        ronda.aumentarRonda();
        // ronda.reiniciarTiempo();
        panelWating.gameObject.SetActive (false);
    }
    public void pintarBotonCorrecto(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("BotonesPreguntas");
        foreach (var item in objs){
            if(preguntasList[index].indexRespuestaCorrecta==item.GetComponent<Button>().GetComponentInChildren<TMP_Text>().text){
                item.GetComponent<Image>().color = Color.green;
            }
        }
    }
    public void despintarTodosBotnes(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("BotonesPreguntas");
        foreach (var item in objs){
            item.GetComponent<Image>().color = new Color(255,255,255);
        }
    }
    
    
}

public class PreguntaObj{
    public string pregunta;
    public string[] respeustas;
    public string indexRespuestaCorrecta;
    public PreguntaObj(string newPregunta, string newRespuestas, string newIndexRespuestaCorrecta){
        pregunta = newPregunta;
        respeustas = newRespuestas.Split(',');
        indexRespuestaCorrecta = newIndexRespuestaCorrecta;
    }
}