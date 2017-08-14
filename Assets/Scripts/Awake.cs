using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awake : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Persistencia.sistema = new Sistema ();
		Persistencia.sistema.actual = new Estudiante ();


		//Actividades
		Actividad ac1 = new Actividad (1 , "Esta es la actividad 1" , "Actividad Plataforma" , "Trabajar el objetivo 1");
		Actividad ac3 = new Actividad (3 , "Esta es la actividad 3" , "Actividad Shooter" , "Trabajar el objetivo 3");

		//Ejercicio para actividad1
		Respuesta r1 = new Respuesta (1 , "Es correcta" , 1);
		Respuesta r2 = new Respuesta (2 , "Es incorrecta" , 0);
		Respuesta r3 = new Respuesta (3 , "Es incorrecta" , 0);
		Ejercicio ej = new Ejercicio (1 , "Enunciado de la pregunta 1 _______  segunda parte" , "" , "" , 1 , true, "PIRATAS" );
		ej.respuestas.Add (r1);
		ej.respuestas.Add (r2);
		ej.respuestas.Add (r3);
		ac1.ejercicios.Add (ej);
		//Persistencia.sistema.actividades.Add(ac1);

		//Ejercicio para actividad1
		Respuesta r4 = new Respuesta (1 , "Es incorrecta" , 0);
		Respuesta r5 = new Respuesta (2 , "Es correcta 2" , 1);
		Respuesta r6 = new Respuesta (3 , "Es incorrecta" , 0);
		Ejercicio ej2 = new Ejercicio (2 , "Enunciado de la pregunta 2 _______  segunda parte" , "" , "" , 1 , true, "COMIDA" );
		ej2.respuestas.Add (r4);
		ej2.respuestas.Add (r5);
		ej2.respuestas.Add (r6);
		ac1.ejercicios.Add (ej2);


		//Ejercicio para actividad3
		Respuesta r7 = new Respuesta (1 , "Respuesta1" , 1);
		Respuesta r8 = new Respuesta (2 , "Respuesta2" , 2);
		Respuesta r9 = new Respuesta (3 , "Respuesta3" , 3);
		Ejercicio ej3 = new Ejercicio (3 , "Enunciado1 \n linea2" , "Enunciado2 \n linea2" , "Enunciado3 \n linea2" , 1 , true, "PIRATAS" );
		ej3.respuestas.Add (r7);
		ej3.respuestas.Add (r8);
		ej3.respuestas.Add (r9);
		ac3.ejercicios.Add (ej3);

		Persistencia.sistema.actividades.Add(ac1);
		Persistencia.sistema.actividades.Add(ac1);
		Persistencia.sistema.actividades.Add(ac3);

		//Estudiantes
        Estudiante e = new Estudiante();
        e.nombre = "David";
        e.usuario = "Davi";
		e.escenario = "COMIDA";
		e.idEstudiante = 2;
        Persistencia.sistema.actual = e;
        Persistencia.Save();
        Estudiante d = new Estudiante();
        d.nombre = "Pedro";
        d.usuario = "Pebbel";
		d.escenario = "COMIDA";
        Persistencia.sistema.actual = d;
        Persistencia.Save();



        Persistencia.Load();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Onclick()
    {
        Application.LoadLevel("CargarPartida");
    }

    public void Onclick2()
    {
        Application.LoadLevel("Registro");
    }
}
