using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Actividad{

    public int idActividad;
    public string descripcion;
    public string nombre;
    public string objetivo;
    public List<Ejercicio> ejercicios;
    public Actividad(int idActividad, string descripcion, string nombre, string objetivo)
    {
        this.idActividad = idActividad;
        this.descripcion = descripcion;
        this.nombre = nombre;
        this.objetivo = objetivo;
        this.ejercicios = new List<Ejercicio>();
    }

}
