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
		Actividad ac2 = new Actividad (2 , "Esta es la actividad 2" , "Actividad Globos" , "Trabajar el objetivo 2");
		Actividad ac3 = new Actividad (3 , "Esta es la actividad 3" , "Actividad Shooter" , "Trabajar el objetivo 3");
		/*
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
		ac3.ejercicios.Add (ej3);*/

		//Prueba de Interacción
		//Ejercicio para actividad1
		Respuesta r1 = new Respuesta (1 , "cocina" , 0);
		Respuesta r2 = new Respuesta (2 , "preparó" , 0);
		Respuesta r3 = new Respuesta (3 , "cocinaron" , 1);
		Ejercicio ej = new Ejercicio (1 , "Mi mamá y mi papá _______  una deliciosa torta de chocolotate para mi cumpleaños" , "" , "" , 1 , true, "PIRATAS" );
		ej.respuestas.Add (r1);
		ej.respuestas.Add (r2);
		ej.respuestas.Add (r3);
		ac1.ejercicios.Add (ej);
		//Persistencia.sistema.actividades.Add(ac1);

		//Ejercicio para actividad 2
		Respuesta r4 = new Respuesta (1 , "tesoros" , 1);
		Respuesta r5 = new Respuesta (2 , "monedas" , 0);
		Respuesta r6 = new Respuesta (3 , "tesoro" , 0);
		Respuesta r10 = new Respuesta (3 , "madera" , 0);
		Ejercicio ej2 = new Ejercicio (2 , "Los piratas tienen muchos _______  escondidos en sus barcos" , "" , "" , 1 , true, "PIRATAS" );
		ej2.respuestas.Add (r4);
		ej2.respuestas.Add (r5);
		ej2.respuestas.Add (r6);
		ej2.respuestas.Add (r10);
		ac2.ejercicios.Add (ej2);


		//Ejercicio para actividad3
		Respuesta r7 = new Respuesta (1 , "grande que hay \n en el barrio" , 1);
		Respuesta r8 = new Respuesta (2 , "ricos que me había \n comido en mi vida" , 2);
		Respuesta r9 = new Respuesta (3 , "hermosa, llevaba un traje \n azul que brillaba" , 3);
		Ejercicio ej3 = new Ejercicio (3 , "Mi casa es la más" , "Un día, mi papá y yo preparamos \n cupcakes. Mezclamos los \n ingredientes y los pusimos en \n el horno. Cuando estuvieron listos \n nos los comimos. Eran los más" , "Los piratas secuestraron \n a una princesa muy" , 1 , true, "PIRATAS" );
		ej3.respuestas.Add (r7);
		ej3.respuestas.Add (r8);
		ej3.respuestas.Add (r9);
		ac3.ejercicios.Add (ej3);

		Persistencia.sistema.actividades.Add(ac1);
		Persistencia.sistema.actividades.Add(ac2);
		Persistencia.sistema.actividades.Add(ac3);

		//Estudiantes
        Estudiante e = new Estudiante();
        e.nombre = "David";
        e.usuario = "Davi";
		e.escenario = "PIRATAS";
		e.idEstudiante = 2;
        Persistencia.sistema.actual = e;
        Persistencia.Save();
        Estudiante d = new Estudiante();
        d.nombre = "Pedro";
        d.usuario = "Pebbel";
		d.escenario = "PIRATAS";
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
