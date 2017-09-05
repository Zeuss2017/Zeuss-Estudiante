using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escenario : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void piratas(){
		Debug.Log ("Entra piratas");
		Persistencia.sistema.actual.escenario= "PIRATAS";
		Persistencia.Save ();
		Application.LoadLevel("MenuActividades");
	}

	public void comida(){
		Debug.Log ("Entra comida");
		Persistencia.sistema.actual.escenario= "COMIDA";
		Persistencia.Save ();
		Application.LoadLevel("MenuActividades");
	}
}
