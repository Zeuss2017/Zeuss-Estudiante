using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class Actividad3_Logica : MonoBehaviour {

    public GameObject Pregunta1;
    public GameObject Pregunta2;
    public GameObject Pregunta3;
    public GameObject respuesta1;
    public GameObject respuesta2;
    public GameObject respuesta3;
    List<GameObject> listaPreguntas= new List<GameObject>();
    List<GameObject> listaRespuestas = new List<GameObject>();
    private int contador = 0;
    private int cantidadRespuestas;
	bool ganador = false;

    void Start () {
        listaPreguntas.Add(Pregunta1);
        listaPreguntas.Add(Pregunta2);
        listaPreguntas.Add(Pregunta3);

		Ejercicio ej = Persistencia.sistema.obtenerEjercicio3 ();
		
        foreach(GameObject p in listaPreguntas)
        {
            if (contador > 2)
            {
                contador = 0;
            }
			if (contador == 0) {
				p.transform.Find("Enunciado").GetComponent<TextMesh> ().text =  ej.enunciado1;
			}
			if (contador == 1) {
				p.transform.Find("Enunciado").GetComponent<TextMesh> ().text =  ej.enunciado2;
			}
			if (contador == 2) {
				p.transform.Find("Enunciado").GetComponent<TextMesh> ().text =  ej.enunciado3;
			}
			p.SendMessage("asignarId", ej.respuestas.ElementAt (contador).correcto);
            contador++;
            //p.SendMessage("asignarRespuesta", Random.Range(1, 3));

        }
        contador = 0;
        listaRespuestas.Add(respuesta1);
        listaRespuestas.Add(respuesta2);
        listaRespuestas.Add(respuesta3);
        foreach (GameObject p in listaRespuestas)
        {           
			p.SendMessage("asignarPregunta", ej.respuestas.ElementAt (contador).correcto);
			p.transform.Find("Enunciado").GetComponent<TextMesh> ().text =  ej.respuestas.ElementAt (contador).enunciado;
            contador++;
        }

		int n1 = Random.Range (1, 7);
		if (n1 == 2) {
			listaRespuestas.ElementAt(1).SendMessage("asignarPregunta", ej.respuestas.ElementAt (2).correcto);
			listaRespuestas.ElementAt(1).transform.Find("Enunciado").GetComponent<TextMesh> ().text = ej.respuestas.ElementAt (2).enunciado;
			listaRespuestas.ElementAt(2).SendMessage("asignarPregunta", ej.respuestas.ElementAt (1).correcto);
			listaRespuestas.ElementAt(2).transform.Find("Enunciado").GetComponent<TextMesh> ().text = ej.respuestas.ElementAt (1).enunciado;
		}
		if (n1 == 3) {
			listaRespuestas.ElementAt(0).SendMessage("asignarPregunta", ej.respuestas.ElementAt (2).correcto);
			listaRespuestas.ElementAt(0).transform.Find("Enunciado").GetComponent<TextMesh> ().text = ej.respuestas.ElementAt (2).enunciado;
			listaRespuestas.ElementAt(2).SendMessage("asignarPregunta", ej.respuestas.ElementAt (0).correcto);
			listaRespuestas.ElementAt(2).transform.Find("Enunciado").GetComponent<TextMesh> ().text = ej.respuestas.ElementAt (0).enunciado;
		}
		if (n1 == 4) {
			listaRespuestas.ElementAt(0).SendMessage("asignarPregunta", ej.respuestas.ElementAt (1).correcto);
			listaRespuestas.ElementAt(0).transform.Find("Enunciado").GetComponent<TextMesh> ().text = ej.respuestas.ElementAt (1).enunciado;
			listaRespuestas.ElementAt(1).SendMessage("asignarPregunta", ej.respuestas.ElementAt (0).correcto);
			listaRespuestas.ElementAt(1).transform.Find("Enunciado").GetComponent<TextMesh> ().text = ej.respuestas.ElementAt (0).enunciado;
		}
		if (n1 == 5) {
			listaRespuestas.ElementAt(0).SendMessage("asignarPregunta", ej.respuestas.ElementAt (1).correcto);
			listaRespuestas.ElementAt(0).transform.Find("Enunciado").GetComponent<TextMesh> ().text = ej.respuestas.ElementAt (1).enunciado;
			listaRespuestas.ElementAt(1).SendMessage("asignarPregunta", ej.respuestas.ElementAt (2).correcto);
			listaRespuestas.ElementAt(1).transform.Find("Enunciado").GetComponent<TextMesh> ().text = ej.respuestas.ElementAt (2).enunciado;
			listaRespuestas.ElementAt(2).SendMessage("asignarPregunta", ej.respuestas.ElementAt (0).correcto);
			listaRespuestas.ElementAt(2).transform.Find("Enunciado").GetComponent<TextMesh> ().text = ej.respuestas.ElementAt (0).enunciado;
		}
		if (n1 == 6) {
			listaRespuestas.ElementAt(0).SendMessage("asignarPregunta", ej.respuestas.ElementAt (2).correcto);
			listaRespuestas.ElementAt(0).transform.Find("Enunciado").GetComponent<TextMesh> ().text = ej.respuestas.ElementAt (2).enunciado;
			listaRespuestas.ElementAt(1).SendMessage("asignarPregunta", ej.respuestas.ElementAt (0).correcto);
			listaRespuestas.ElementAt(1).transform.Find("Enunciado").GetComponent<TextMesh> ().text = ej.respuestas.ElementAt (0).enunciado;
			listaRespuestas.ElementAt(2).SendMessage("asignarPregunta", ej.respuestas.ElementAt (1).correcto);
			listaRespuestas.ElementAt(2).transform.Find("Enunciado").GetComponent<TextMesh> ().text = ej.respuestas.ElementAt (1).enunciado;
		}

        this.cantidadRespuestas = contador;
        Pregunta1.SendMessage("activarDisparo");

    }
	
	
	void Update () {

		if (respuesta1 == null || respuesta2 == null || respuesta3 == null) {
			if (Pregunta1 != null) {
				Destroy (Pregunta1);
				Pregunta2.SendMessage ("activarDisparo");
			} else {
				if ((respuesta1 == null && respuesta2 == null) || (respuesta1 == null && respuesta3 == null) || (respuesta2 == null && respuesta3 == null)) {
					if (Pregunta2 != null) {
						Destroy (Pregunta2);
						Pregunta3.SendMessage ("activarDisparo");
					} else {
						if (respuesta1 == null && respuesta2 == null && respuesta3 == null) {
							if (Pregunta3 != null) {
								Destroy (Pregunta3);
							}
						}
					}

				}
			}

            
		} 
		if(Pregunta1 == null && Pregunta2 == null && Pregunta3 == null && ganador == false) {
			//Mostrar pantalla de ganador
			EditorUtility.DisplayDialog ("Actividad", "Ganaste!", "Ok");
			ganador = true;
		}    
       

    }

	public void regresar(){
		Application.LoadLevel("Intermedia");
	}

    
}
