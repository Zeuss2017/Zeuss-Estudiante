using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Respuesta{

    public int idRespuesta;
    public string enunciado;
    public int correcto;
    public Respuesta(int idRespuesta, string enunciado, int correcto)
    {
        this.idRespuesta = idRespuesta;
        this.enunciado = enunciado;
        this.correcto = correcto;
    }

	public Respuesta(){

	}
}
