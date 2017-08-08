using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
			Destroy (this.gameObject);
			Persistencia.sistema.aciertosActual++;
			Persistencia.sistema.tiempoActual = Time.time - Persistencia.sistema.tiempoActual;
			Persistencia.sistema.guardarEjercicio ();
            //Debug.Log(Persistencia.sistema.tiempoActual + "  " +  Persistencia.sistema.aciertosActual );
            CargarActividad1.victoria(true);
		} else {
			Persistencia.sistema.erroresActual++;
            CargarActividad1.victoria(false);
		}
	}

}
