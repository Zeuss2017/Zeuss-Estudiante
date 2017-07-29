﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Estudiante{

    public int idEstudiante;
    public string nombre;
    public string usuario;
    public string fechaNacimiento;// no se que tipo de dato colocarle al DATE
    public string nombreCurso;
    public string nombreColegio;
    public string escenario;
    public int monedas;
    public string avatar; // Revisar tipo de dato del avatar
    public List<ActividadEstudiante> actividadesEstudiante;
	public List<int> ejerciciosDisponibles;

    public Estudiante(int idEstudiante, string nombre, string usuario, string fechaNacimiento, string nombreCurso, string nombreColegio, string escenario, int monedas, string avatar)
    {
        this.idEstudiante = idEstudiante;
        this.nombre = nombre;
        this.usuario = usuario;
        this.fechaNacimiento = fechaNacimiento;
        this.nombreCurso = nombreCurso;
        this.nombreColegio = nombreColegio;
        this.escenario = escenario;
        this.monedas = monedas;
        this.avatar = avatar;
        this.actividadesEstudiante = new List<ActividadEstudiante>();
    }

    public Estudiante()
    {
        this.actividadesEstudiante = new List<ActividadEstudiante>();
		//Se crean las actividades con 0 aciertos, errores, tiempo, 1 de nivel actual , sin completar, id de la actividad, 1 de nivel maximo y 2 ayudas
		ActividadEstudiante a1 = new ActividadEstudiante( 0  , 0 , 0 , 1 , false , 1 , 1 , 2);
		ActividadEstudiante a2 = new ActividadEstudiante( 0  , 0 , 0 , 1 , false , 2 , 1 , 2);
		ActividadEstudiante a3 = new ActividadEstudiante( 0  , 0 , 0 , 1 , false , 3  , 1 , 2);
		this.actividadesEstudiante.Add (a1);
		this.actividadesEstudiante.Add (a2);
		this.actividadesEstudiante.Add (a3);
		this.ejerciciosDisponibles = new List<int>();
        this.monedas = 0;
		//Se recorren todas las actividades y ejercicios y solo se añaden a la lista los que son básicos
		foreach (Actividad a in Persistencia.sistema.actividades) {
			foreach(Ejercicio e in a.ejercicios){
				if (e.basico == true) {
					this.ejerciciosDisponibles.Add (e.idEjercicio);
					Debug.Log ("Se añade el ejercicio con id " + e.idEjercicio);
				}
			}
		}

    }

}
