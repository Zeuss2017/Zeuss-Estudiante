using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEditor;

public class CargarActividad2 : MonoBehaviour {

    
    public GameObject uiIdle;


    public enum GameState { Idle, Playing };
    public GameState gameState = GameState.Idle;
    public int cantidadGlobos;
    public List<GameObject> listaGlobos=new List<GameObject>();
    public GameObject globo;
	public bool gano = false;
   
  
    void Start () {
        
	    
	}

	void Update () {

        //empieza el juego

        if(gameState== GameState.Idle && Input.GetMouseButtonDown(0))
        {
            
            gameState = GameState.Playing;
            uiIdle.SetActive(false);
			Ejercicio ej = Persistencia.sistema.obtenerEjercicio1 ();

            for (int i = 0; i < cantidadGlobos; i++)
            {
                var position = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
                GameObject pl = Instantiate(globo,position,Quaternion.identity) as GameObject;
				pl.transform.Find("Texto").GetComponent<TextMesh> ().text = ej.respuestas.ElementAt (i).enunciado;
				pl.GetComponent<PlayerController>().correcta = ej.respuestas.ElementAt (i).correcto;
                listaGlobos.Add(pl);
            }

			GameObject.Find ("Enunciado").GetComponent<TextMesh> ().text = ej.enunciado1;

        }
        /*if (listaGlobos.Count == 1) 
        {
            GameObject auxGlobo = listaGlobos[0];
            auxGlobo.SendMessage("UpdateState", "_GloboPosicionar");
        }*/
		int count = 0;

		foreach (GameObject go in listaGlobos) {
			if (go != null) {
				count++;
			}
		}
		if (count == 1 && gano == false) {
			gano = true;
			EditorUtility.DisplayDialog ("Actividad", "Ganaste!", "Ok");
		}

    }

    
	public void regresar(){
		Application.LoadLevel("Intermedia");
	}


}
