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
			EditorUtility.DisplayDialog ("Actividad", "Ganaste!", "Ok");
		} else {
			EditorUtility.DisplayDialog ("Actividad", "Esa no es la opcion correcta", "Ok");
		}
	}

}
