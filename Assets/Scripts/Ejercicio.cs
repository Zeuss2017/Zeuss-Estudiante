using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ejercicio{

    public int idEjercicio;
    public string enunciado1;
    public string enunciado2;
    public string enunciado3;
    public int nivel;
    public bool basico;
    public List<Respuesta> respuestas;
	public string escenario;


	public Ejercicio (int idEjercicio, string enunciado1, string enunciado2, string enunciado3, int nivel, bool basico, string escenario)
    {
        this.idEjercicio = idEjercicio;
        this.enunciado1 = enunciado1;
        this.enunciado2 = enunciado2;
        this.enunciado3 = enunciado3;
        this.nivel = nivel;
        this.basico = basico;
        this.respuestas = new List<Respuesta>();
		this.escenario = escenario;
    }

	public Ejercicio(){
		this.respuestas = new List<Respuesta> ();
	}

}
