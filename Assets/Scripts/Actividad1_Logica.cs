using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Actividad1_Logica : MonoBehaviour {

	public int correcta;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionEnter2D(Collision2D coll){
		if (correcta == 1) {
			//GANA ACTIVIDAD 1
			Destroy (this.gameObject);
			Persistencia.sistema.aciertosActual++;
			Persistencia.sistema.tiempoActual = Time.time - Persistencia.sistema.tiempoActual;
			//Persistencia.sistema.guardarEjercicio ();
            
            CargarActividad1.victoria(true);
		} else {
			//INTENTO FALLIDO
			Persistencia.sistema.erroresActual++;
            CargarActividad1.victoria(false);
		}
	}



}
