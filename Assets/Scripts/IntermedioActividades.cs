using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermedioActividades : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void click1(){
		Application.LoadLevel("GlobosPiratas");
	}

	public void click2(){
		Application.LoadLevel("ActividadSaltoComida");
	}

	public void click3(){
		Application.LoadLevel("ShooterComida");
	}
	public void clickTienda(){
		Application.LoadLevel("Tienda");
	}

}
