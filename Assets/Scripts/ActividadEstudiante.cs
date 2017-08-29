using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActividadEstudiante{

    public int aciertos;
    public int errores;
    public float tiempo;
    public int nivel;
    public int completado;
    public int idActividad;
    public int nivelMaximo;
    public List<EjercicioEstudiante> ejerciciosEstudiante;
	public int cantidadEjercicios;

	public ActividadEstudiante(int aciertos, int errores, float tiempo, int nivel, int completado, int idActividad, int nivelMaximo)
    {
        this.aciertos = aciertos;
        this.errores = errores;
        this.tiempo = tiempo;
        this.nivel = nivel;
        this.completado = completado;
        this.idActividad = idActividad;
        this.nivelMaximo = nivelMaximo;
        this.ejerciciosEstudiante = new List<EjercicioEstudiante>();
		this.cantidadEjercicios = 0;
    }

}
