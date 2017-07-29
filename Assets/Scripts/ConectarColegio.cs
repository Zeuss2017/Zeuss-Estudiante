using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConectarColegio : MonoBehaviour {

    public Dropdown ciudad;
    public Dropdown colegio;
    public Dropdown curso;

    // Use this for initialization
    void Start () {
        //llamar servicio web
        Debug.Log(Persistencia.sistema.actual.nombre);
        Debug.Log(Persistencia.sistema.actual.fechaNacimiento);
        ciudad.ClearOptions();
        ciudad.options.Add(new Dropdown.OptionData("Bogotá") );
        ciudad.options.Add(new Dropdown.OptionData("Medellín"));
        ciudad.options.Add(new Dropdown.OptionData("Cali"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
