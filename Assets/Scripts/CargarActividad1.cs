using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CargarActividad1 : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Ejercicio ej = Persistencia.sistema.obtenerEjercicio1 ();

		GameObject.Find ("Opcion1").GetComponent<TextMesh> ().text = ej.respuestas.ElementAt (0).enunciado;
		GameObject.Find ("Opcion1").GetComponent<Actividad1_Logica> ().correcta = ej.respuestas.ElementAt (0).correcto;

		GameObject.Find ("Opcion2").GetComponent<TextMesh> ().text = ej.respuestas.ElementAt (1).enunciado;
		GameObject.Find ("Opcion2").GetComponent<Actividad1_Logica> ().correcta = ej.respuestas.ElementAt (1).correcto;

		GameObject.Find ("Opcion3").GetComponent<TextMesh> ().text = ej.respuestas.ElementAt (2).enunciado;
		GameObject.Find ("Opcion3").GetComponent<Actividad1_Logica> ().correcta = ej.respuestas.ElementAt (2).correcto;

		GameObject.Find ("Enunciado").GetComponent<TextMesh> ().text = ej.enunciado1;

		Persistencia.sistema.idEjercicioActual = ej.idEjercicio;
		Persistencia.sistema.idActividadActual = 1;
		Persistencia.sistema.aciertosActual = 0;
		Persistencia.sistema.erroresActual = 0;
		Persistencia.sistema.tiempoActual = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void regresar(){
		Application.LoadLevel("Intermedia");
	}
}
