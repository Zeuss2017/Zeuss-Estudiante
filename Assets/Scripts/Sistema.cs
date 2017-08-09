﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Sistema {

    public int idActividadActual;
    public int idEjercicioActual;
	public int aciertosActual;
	public int erroresActual;
	public float tiempoActual;
    public List<Actividad> actividades;
    public List<Estudiante> estudiantes;
    public Estudiante actual;

    public Sistema() {
        this.idActividadActual = -1;
        this.idEjercicioActual = -1;
        this.actividades = new List<Actividad>();
        this.estudiantes = new List<Estudiante>();
    }

    public void CargarPartida(string usu)
    {
        foreach(Estudiante e in this.estudiantes){
            if (e.usuario.Equals(usu))
            {
                this.actual = e;
            }
        }
    }

	public Ejercicio obtenerEjercicio1(){
		
		int nivel = actual.actividadesEstudiante.ElementAt(0).nivel;
		Debug.Log ("nivel: " + nivel);
		//Se recorren las actividades y se encuentra la primera
		foreach (Actividad a in actividades) {
			if (a.idActividad == 1) {
				//Se recorren los ejercicios de la actividad y se ponen en una lista los ejercicios con el nivel en el que va el estudiante
				List<Ejercicio> ejer = new List<Ejercicio> ();
				foreach (Ejercicio e in a.ejercicios) {
					if (e.nivel == nivel) {
						ejer.Add (e);
					}
				}
				//Se halla un indice aleatorio de ejercicio con ese nivel
				bool bandera = false;
				while (bandera == false) {
					int indice = Random.Range (0, ejer.Count);
					int idEj = ejer.ElementAt(indice).idEjercicio;
					Debug.Log ("Encuentra ejercicio con id " + idEj);
					if (actual.ejerciciosDisponibles.Contains(idEj) ) {
						return ejer.ElementAt (indice);
					}
				}
			}
		}

		return null;
	}

	public Ejercicio obtenerEjercicio3(){
		int nivel = actual.actividadesEstudiante.ElementAt(2).nivel;
		Debug.Log ("nivel: " + nivel);
		//Se recorren las actividades y se encuentra la primera
		foreach (Actividad a in actividades) {
			if (a.idActividad == 3) {
				//Se recorren los ejercicios de la actividad y se ponen en una lista los ejercicios con el nivel en el que va el estudiante
				List<Ejercicio> ejer = new List<Ejercicio> ();
				foreach (Ejercicio e in a.ejercicios) {
					if (e.nivel == nivel) {
						ejer.Add (e);
					}
				}
				//Se halla un indice aleatorio de ejercicio con ese nivel
				bool bandera = false;
				while (bandera == false) {
					int indice = Random.Range (0, ejer.Count);
					int idEj = ejer.ElementAt(indice).idEjercicio;
					Debug.Log ("Encuentra ejercicio con id " + idEj);
					if (actual.ejerciciosDisponibles.Contains(idEj) ) {
						return ejer.ElementAt (indice);
					}
				}
			}
		}

		return null;
	}

	public void guardarEjercicio(){
		EjercicioEstudiante ej = new EjercicioEstudiante (this.aciertosActual, this.erroresActual, this.tiempoActual, this.idEjercicioActual,0);
		foreach (ActividadEstudiante a in  this.actual.actividadesEstudiante) {
			if (a.idActividad == this.idActividadActual) {
				ej.consecutivo = a.cantidadEjercicios + 1;
				a.cantidadEjercicios++;
				a.ejerciciosEstudiante.Add (ej);
				a.aciertos += this.aciertosActual;
				a.errores += this.erroresActual;
				a.tiempo += this.tiempoActual;
				//Se tiene que realizar la lógica de subir o bajar nivel!!!
				//Modificar nivel máximo si es necesario
				//Modificar completado si es necesario
				Debug.Log("Se guarda: actividad " + a.idActividad + " ejercicio "+ ej.idEjercicio + " tiempo: " + ej.tiempo+"  consecutivo: " + ej.consecutivo);
				Debug.Log("Totales actividad:  aciertos" + a.aciertos + " errores "+ a.errores + " tiempo: " + a.tiempo);
			}
		}
		//Suma las monedas ganadas
		this.actual.monedas += 3;
		Persistencia.Save ();
	}
}
