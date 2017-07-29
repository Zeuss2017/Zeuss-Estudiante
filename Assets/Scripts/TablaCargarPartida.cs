using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TablaCargarPartida : MonoBehaviour {

    public GameObject playerScoreEntryPrefab;

	// Use this for initialization
	void Start () {   

        foreach (Estudiante e in Persistencia.sistema.estudiantes)
        {
            GameObject go = (GameObject)Instantiate(playerScoreEntryPrefab);
            go.transform.SetParent(this.transform);
            // go.transform.Find("Nombre").GetComponent<Text>().text = "d";
            go.transform.Find("Nombre").GetComponent<Text>().text = e.nombre;
            go.transform.Find("Apodo").GetComponent<Text>().text = e.usuario;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
