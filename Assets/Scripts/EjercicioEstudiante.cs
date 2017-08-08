using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EjercicioEstudiante  {

    public int aciertos;
    public int errores;
    public float tiempo;
	public int idEjercicio;

	public EjercicioEstudiante(int aciertos, int errores, float tiempo, int idEjercicio)
    {
        this.aciertos = aciertos;
        this.errores = errores;
        this.tiempo = tiempo;
		this.idEjercicio = idEjercicio;
    }
}
