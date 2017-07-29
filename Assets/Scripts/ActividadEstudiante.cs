using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActividadEstudiante{

    public int aciertos;
    public int errores;
    public int tiempo;
    public int nivel;
    public bool completado;
    public int idActividad;
    public int nivelMaximo;
    public int cantidadAyudas;
    public List<EjercicioEstudiante> ejerciciosEstudiante;

    public ActividadEstudiante(int aciertos, int errores, int tiempo, int nivel, bool completado, int idActividad, int nivelMaximo, int cantidadAyudas)
    {
        this.aciertos = aciertos;
        this.errores = errores;
        this.tiempo = tiempo;
        this.nivel = nivel;
        this.completado = completado;
        this.idActividad = idActividad;
        this.nivelMaximo = nivelMaximo;
        this.cantidadAyudas = cantidadAyudas;
        this.ejerciciosEstudiante = new List<EjercicioEstudiante>();

    }

}
