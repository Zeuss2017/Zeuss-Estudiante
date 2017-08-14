using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargarPartida : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        Persistencia.sistema.CargarPartida(this.transform.Find("Apodo").GetComponent<Text>().text);
        Debug.Log(Persistencia.sistema.actual.nombre);
		Application.LoadLevel("MenuActividades");
    }
}
