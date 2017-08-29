using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EjercicioEstudiante  {

    public int aciertos;
    public int errores;
    public float tiempo;
	public int idEjercicio;
	public int consecutivo;
	public bool enviado;

	public EjercicioEstudiante(int aciertos, int errores, float tiempo, int idEjercicio, int consecutivo, bool enviado)
    {
        this.aciertos = aciertos;
        this.errores = errores;
        this.tiempo = tiempo;
		this.idEjercicio = idEjercicio;
		this.consecutivo = consecutivo;
		this.enviado = enviado;
    }
}
