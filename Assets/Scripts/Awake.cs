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
		/*Respuesta r1 = new Respuesta (1 , "cocina" , 0);
		Respuesta r2 = new Respuesta (2 , "preparó" , 0);
		Respuesta r3 = new Respuesta (3 , "cocinaron" , 1);
		Ejercicio ej = new Ejercicio (1 , "Mi mamá y mi papá _______  una deliciosa torta de chocolotate para mi cumpleaños" , "" , "" , 1 , true, "COMIDA" );
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
		Ejercicio ej2 = new Ejercicio (2 , "Los piratas tienen muchos _______  escondidos en sus barcos" , "" , "" , 1 , true, "COMIDA" );
		ej2.respuestas.Add (r4);
		ej2.respuestas.Add (r5);
		ej2.respuestas.Add (r6);
		ej2.respuestas.Add (r10);
		ac2.ejercicios.Add (ej2);


		//Ejercicio para actividad3
		Respuesta r7 = new Respuesta (1 , "grande que hay \n en el barrio" , 1);
		Respuesta r8 = new Respuesta (2 , "ricos que me había \n comido en mi vida" , 2);
		Respuesta r9 = new Respuesta (3 , "hermosa, llevaba un traje \n azul que brillaba" , 3);
		Ejercicio ej3 = new Ejercicio (3 , "Mi casa es la más" , "Un día, mi papá y yo preparamos \n cupcakes. Mezclamos los \n ingredientes y los pusimos en \n el horno. Cuando estuvieron listos \n nos los comimos. Eran los más" , "Los piratas secuestraron \n a una princesa muy" , 1 , true, "COMIDA" );
		ej3.respuestas.Add (r7);
		ej3.respuestas.Add (r8);
		ej3.respuestas.Add (r9);
		ac3.ejercicios.Add (ej3);

		Persistencia.sistema.actividades.Add(ac1);
		Persistencia.sistema.actividades.Add(ac2);
		Persistencia.sistema.actividades.Add(ac3); */

		cargarEjercicios ();

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


	public void cargarEjercicios(){
		Actividad ac1 = new Actividad (2 , "Esta es la actividad 1" , "Actividad Plataforma" , "Trabajar el objetivo 1");
		Actividad ac2 = new Actividad (1 , "Esta es la actividad 2" , "Actividad Globos" , "Trabajar el objetivo 2");
		Actividad ac3 = new Actividad (3 , "Esta es la actividad 3" , "Actividad Shooter" , "Trabajar el objetivo 3");

		Respuesta r1, r2, r3,r4;
		Ejercicio ej1 = new Ejercicio (1 , "Las _____ comen arroz" , "" , "" , 1 , true , "COMIDA" );
		r1 = new Respuesta (1 , "palomas" , 1);
		r2 = new Respuesta (2 , "paloma" , 0);
		r3 = new Respuesta (3 , "palomos" , 0);
		ej1.respuestas.Add (r1);
		ej1.respuestas.Add (r2);
		ej1.respuestas.Add (r3);
		ac1.ejercicios.Add (ej1);


		Ejercicio ej2 = new Ejercicio (2 , "La niña derramó la _____ " , "" , "" , 1 , true , "COMIDA" );
		r1 = new Respuesta (1 , "sopa" , 1);
		r2 = new Respuesta (2 , "sopas" , 0);
		r3 = new Respuesta (3 , "arroz" , 0);
		ej2.respuestas.Add (r1);
		ej2.respuestas.Add (r2);
		ej2.respuestas.Add (r3);
		ac1.ejercicios.Add (ej2);


		Ejercicio ej3 = new Ejercicio (3 , "Las _____ comen insectos" , "" , "" , 2 , true , "COMIDA" );
		r1 = new Respuesta (1 , "aves" , 1);
		r2 = new Respuesta (2 , "loros" , 0);
		r3 = new Respuesta (3 , "sapos" , 0);
		ej3.respuestas.Add (r1);
		ej3.respuestas.Add (r2);
		ej3.respuestas.Add (r3);
		ac1.ejercicios.Add (ej3);


		Ejercicio ej4 = new Ejercicio (4 , "Los _____ no deben comer muchos dulces" , "" , "" , 2 , true , "COMIDA" );
		r1 = new Respuesta (1 , "niños" , 1);
		r2 = new Respuesta (2 , "niñas" , 0);
		r3 = new Respuesta (3 , "hombre" , 0);
		ej4.respuestas.Add (r1);
		ej4.respuestas.Add (r2);
		ej4.respuestas.Add (r3);
		ac1.ejercicios.Add (ej4);


		Ejercicio ej5 = new Ejercicio (5 , "Los _____ son nutritivos para el cuerpo" , "" , "" , 3 , true , "COMIDA" );
		r1 = new Respuesta (1 , "frijoles" , 1);
		r2 = new Respuesta (2 , "legumbre" , 0);
		r3 = new Respuesta (3 , "lentejas" , 0);
		ej5.respuestas.Add (r1);
		ej5.respuestas.Add (r2);
		ej5.respuestas.Add (r3);
		ac1.ejercicios.Add (ej5);


		Ejercicio ej6 = new Ejercicio (6 , "Las _____ son alimentos sanos" , "" , "" , 3 , true , "COMIDA" );
		r1 = new Respuesta (1 , "verduras" , 1);
		r2 = new Respuesta (2 , "tomates" , 0);
		r3 = new Respuesta (3 , "banano" , 0);
		ej6.respuestas.Add (r1);
		ej6.respuestas.Add (r2);
		ej6.respuestas.Add (r3);
		ac1.ejercicios.Add (ej6);


		Ejercicio ej7 = new Ejercicio (7 , "El _____ es un alimento muy sano" , "" , "" , 4 , true , "COMIDA" );
		r1 = new Respuesta (1 , "pan" , 1);
		r2 = new Respuesta (2 , "lechuga" , 0);
		r3 = new Respuesta (3 , "chocolates" , 0);
		ej7.respuestas.Add (r1);
		ej7.respuestas.Add (r2);
		ej7.respuestas.Add (r3);
		ac1.ejercicios.Add (ej7);


		Ejercicio ej8 = new Ejercicio (8 , "La _____ es un alimento muy necesario" , "" , "" , 4 , true , "COMIDA" );
		r1 = new Respuesta (1 , "leche" , 1);
		r2 = new Respuesta (2 , "queso" , 0);
		r3 = new Respuesta (3 , "kumis" , 0);
		ej8.respuestas.Add (r1);
		ej8.respuestas.Add (r2);
		ej8.respuestas.Add (r3);
		ac1.ejercicios.Add (ej8);


		Ejercicio ej9 = new Ejercicio (9 , "Las _____ deben lavarse antes de comer" , "" , "" , 5 , true , "COMIDA" );
		r1 = new Respuesta (1 , "manos" , 1);
		r2 = new Respuesta (2 , "boca" , 0);
		r3 = new Respuesta (3 , "dientes" , 0);
		ej9.respuestas.Add (r1);
		ej9.respuestas.Add (r2);
		ej9.respuestas.Add (r3);
		ac1.ejercicios.Add (ej9);


		Ejercicio ej10 = new Ejercicio (10 , "Las _____ son golosinas a base de azúcar" , "" , "" , 4 , true , "COMIDA" );
		r1 = new Respuesta (1 , "gomitas" , 1);
		r2 = new Respuesta (2 , "galleta" , 0);
		r3 = new Respuesta (3 , "chocolates" , 0);
		ej10.respuestas.Add (r1);
		ej10.respuestas.Add (r2);
		ej10.respuestas.Add (r3);
		ac1.ejercicios.Add (ej10);


		Ejercicio ej11 = new Ejercicio (11 , " _____ agua pura debe tomarse a diario" , "" , "" , 6 , true , "COMIDA" );
		r1 = new Respuesta (1 , "El" , 1);
		r2 = new Respuesta (2 , "Las" , 0);
		r3 = new Respuesta (3 , "La" , 0);
		ej11.respuestas.Add (r1);
		ej11.respuestas.Add (r2);
		ej11.respuestas.Add (r3);
		ac1.ejercicios.Add (ej11);


		Ejercicio ej12 = new Ejercicio (12 , "El objetivo de blanquear es precocer o ablandar los _____ " , "" , "" , 6 , true , "COMIDA" );
		r1 = new Respuesta (1 , "ingredientes" , 1);
		r2 = new Respuesta (2 , "azúcar" , 0);
		r3 = new Respuesta (3 , "masas" , 0);
		ej12.respuestas.Add (r1);
		ej12.respuestas.Add (r2);
		ej12.respuestas.Add (r3);
		ac1.ejercicios.Add (ej12);


		Ejercicio ej13 = new Ejercicio (13 , "La mantequilla se obtiene al batir, amasar y madurar la _____ " , "" , "" , 7 , true , "COMIDA" );
		r1 = new Respuesta (1 , "leche" , 1);
		r2 = new Respuesta (2 , "yogurt" , 0);
		r3 = new Respuesta (3 , "leches" , 0);
		ej13.respuestas.Add (r1);
		ej13.respuestas.Add (r2);
		ej13.respuestas.Add (r3);
		ac1.ejercicios.Add (ej13);


		Ejercicio ej14 = new Ejercicio (14 , "El alfajor es un _____ a base de pasta" , "" , "" , 7 , true , "COMIDA" );
		r1 = new Respuesta (1 , "dulce" , 1);
		r2 = new Respuesta (2 , "postres" , 0);
		r3 = new Respuesta (3 , "galleta" , 0);
		ej14.respuestas.Add (r1);
		ej14.respuestas.Add (r2);
		ej14.respuestas.Add (r3);
		ac1.ejercicios.Add (ej14);


		Ejercicio ej15 = new Ejercicio (15 , "La _____ sirve para la conservación de alimentos" , "" , "" , 8 , true , "COMIDA" );
		r1 = new Respuesta (1 , "sal" , 1);
		r2 = new Respuesta (2 , "azúcar" , 0);
		r3 = new Respuesta (3 , "neveras" , 0);
		ej15.respuestas.Add (r1);
		ej15.respuestas.Add (r2);
		ej15.respuestas.Add (r3);
		ac1.ejercicios.Add (ej15);


		Ejercicio ej16 = new Ejercicio (16 , "Las galletas están listas cuando los _____ empiezan a dorarse" , "" , "" , 8 , true , "COMIDA" );
		r1 = new Respuesta (1 , "bordes" , 1);
		r2 = new Respuesta (2 , "chocolate" , 0);
		r3 = new Respuesta (3 , "masas" , 0);
		ej16.respuestas.Add (r1);
		ej16.respuestas.Add (r2);
		ej16.respuestas.Add (r3);
		ac1.ejercicios.Add (ej16);


		Ejercicio ej17 = new Ejercicio (17 , "En repostería debemos respetar las _____ exactas indicadas en la receta" , "" , "" , 9 , true , "COMIDA" );
		r1 = new Respuesta (1 , "cantidades" , 1);
		r2 = new Respuesta (2 , "tamaño" , 0);
		r3 = new Respuesta (3 , "cantidad" , 0);
		ej17.respuestas.Add (r1);
		ej17.respuestas.Add (r2);
		ej17.respuestas.Add (r3);
		ac1.ejercicios.Add (ej17);


		Ejercicio ej18 = new Ejercicio (18 , "Los orejones son melocotones secados al _____ " , "" , "" , 9 , true , "COMIDA" );
		r1 = new Respuesta (1 , "sol" , 1);
		r2 = new Respuesta (2 , "luna" , 0);
		r3 = new Respuesta (3 , "luz" , 0);
		ej18.respuestas.Add (r1);
		ej18.respuestas.Add (r2);
		ej18.respuestas.Add (r3);
		ac1.ejercicios.Add (ej18);


		Ejercicio ej19 = new Ejercicio (19 , "La miel se usa para endulzar una _____ " , "" , "" , 10 , true , "COMIDA" );
		r1 = new Respuesta (1 , "preparación" , 1);
		r2 = new Respuesta (2 , "masas" , 0);
		r3 = new Respuesta (3 , "ingrediente" , 0);
		ej19.respuestas.Add (r1);
		ej19.respuestas.Add (r2);
		ej19.respuestas.Add (r3);
		ac1.ejercicios.Add (ej19);


		Ejercicio ej20 = new Ejercicio (20 , "Hay tres tipos de leches: la leche fresca, la leche evaporada y la _____ de leche" , "" , "" , 10 , true , "COMIDA" );
		r1 = new Respuesta (1 , "crema" , 1);
		r2 = new Respuesta (2 , "dulce" , 0);
		r3 = new Respuesta (3 , "condensadas" , 0);
		ej20.respuestas.Add (r1);
		ej20.respuestas.Add (r2);
		ej20.respuestas.Add (r3);
		ac1.ejercicios.Add (ej20);


		//Actividad 2 Comida


		Ejercicio ej21 = new Ejercicio (21 , "David ____ enfriar las galletas antes de llevarlas al horno" , "" , "" , 1 , true , "COMIDA" );
		r1 = new Respuesta (1 , "deja" , 1);
		r2 = new Respuesta (2 , "pone" , 0);
		r3 = new Respuesta (3 , "hacen" , 0);
		r4 = new Respuesta (4 , "ponen" , 0);
		ej21.respuestas.Add (r1);
		ej21.respuestas.Add (r2);
		ej21.respuestas.Add (r3);
		ej21.respuestas.Add (r4);
		ac2.ejercicios.Add (ej21);


		Ejercicio ej22 = new Ejercicio (22 , "Camilo ____ las galletas con un grano de café sobre el centro de cada una" , "" , "" , 1 , true , "COMIDA" );
		r1 = new Respuesta (1 , "decora" , 1);
		r2 = new Respuesta (2 , "usan" , 0);
		r3 = new Respuesta (3 , "comen" , 0);
		r4 = new Respuesta (4 , "decoraron" , 0);
		ej22.respuestas.Add (r1);
		ej22.respuestas.Add (r2);
		ej22.respuestas.Add (r3);
		ej22.respuestas.Add (r4);
		ac2.ejercicios.Add (ej22);


		Ejercicio ej23 = new Ejercicio (23 , "Luis mezcla la mantequilla con el azúcar y ____ leche" , "" , "" , 2 , true , "COMIDA" );
		r1 = new Respuesta (1 , "agrega" , 1);
		r2 = new Respuesta (2 , "hechan" , 0);
		r3 = new Respuesta (3 , "ponen" , 0);
		r4 = new Respuesta (4 , "tienen" , 0);
		ej23.respuestas.Add (r1);
		ej23.respuestas.Add (r2);
		ej23.respuestas.Add (r3);
		ej23.respuestas.Add (r4);
		ac2.ejercicios.Add (ej23);


		Ejercicio ej24 = new Ejercicio (24 , "Sara ____ las galletas con un cacahuete en el centro, antes de llevarlas al horno" , "" , "" , 2 , true , "COMIDA" );
		r1 = new Respuesta (1 , "decora" , 1);
		r2 = new Respuesta (2 , "cocinan" , 0);
		r3 = new Respuesta (3 , "hornean" , 0);
		r4 = new Respuesta (4 , "hornearon" , 0);
		ej24.respuestas.Add (r1);
		ej24.respuestas.Add (r2);
		ej24.respuestas.Add (r3);
		ej24.respuestas.Add (r4);
		ac2.ejercicios.Add (ej24);


		Ejercicio ej25 = new Ejercicio (25 , "El baño María ____ un método de cocción" , "" , "" , 3 , true , "COMIDA" );
		r1 = new Respuesta (1 , "es" , 1);
		r2 = new Respuesta (2 , "son" , 0);
		r3 = new Respuesta (3 , "fueron" , 0);
		r4 = new Respuesta (4 , "se" , 0);
		ej25.respuestas.Add (r1);
		ej25.respuestas.Add (r2);
		ej25.respuestas.Add (r3);
		ej25.respuestas.Add (r4);
		ac2.ejercicios.Add (ej25);


		Ejercicio ej26 = new Ejercicio (26 , "Juana ____ el chocolate en baño María y después agrega las avellenas" , "" , "" , 3 , true , "COMIDA" );
		r1 = new Respuesta (1 , "derrite" , 1);
		r2 = new Respuesta (2 , "cortan" , 0);
		r3 = new Respuesta (3 , "derriten" , 0);
		r4 = new Respuesta (4 , "comen" , 0);
		ej26.respuestas.Add (r1);
		ej26.respuestas.Add (r2);
		ej26.respuestas.Add (r3);
		ej26.respuestas.Add (r4);
		ac2.ejercicios.Add (ej26);


		Ejercicio ej27 = new Ejercicio (27 , "Valeria  ____ las galletas del horno y las deja reposar durante unos minutos" , "" , "" , 4 , true , "COMIDA" );
		r1 = new Respuesta (1 , "retira" , 1);
		r2 = new Respuesta (2 , "sacan" , 0);
		r3 = new Respuesta (3 , "ponen" , 0);
		r4 = new Respuesta (4 , "tienen" , 0);
		ej27.respuestas.Add (r1);
		ej27.respuestas.Add (r2);
		ej27.respuestas.Add (r3);
		ej27.respuestas.Add (r4);
		ac2.ejercicios.Add (ej27);


		Ejercicio ej28 = new Ejercicio (28 , "Laura  ____ mantequilla para engrasar la placa" , "" , "" , 4 , true , "COMIDA" );
		r1 = new Respuesta (1 , "usa" , 1);
		r2 = new Respuesta (2 , "tienen" , 0);
		r3 = new Respuesta (3 , "usan" , 0);
		r4 = new Respuesta (4 , "ponen" , 0);
		ej28.respuestas.Add (r1);
		ej28.respuestas.Add (r2);
		ej28.respuestas.Add (r3);
		ej28.respuestas.Add (r4);
		ac2.ejercicios.Add (ej28);


		Ejercicio ej29 = new Ejercicio (29 , "La masa lista para hornear  ____ conservarse en el congelador hasta por seis meses" , "" , "" , 5 , true , "COMIDA" );
		r1 = new Respuesta (1 , "puede" , 1);
		r2 = new Respuesta (2 , "poner" , 0);
		r3 = new Respuesta (3 , "tienen" , 0);
		r4 = new Respuesta (4 , "pueden" , 0);
		ej29.respuestas.Add (r1);
		ej29.respuestas.Add (r2);
		ej29.respuestas.Add (r3);
		ej29.respuestas.Add (r4);
		ac2.ejercicios.Add (ej29);


		Ejercicio ej30 = new Ejercicio (30 , "Claudia ____ las galletas en una placa sin engrasar y las lleva al horno" , "" , "" , 5 , true , "COMIDA" );
		r1 = new Respuesta (1 , "coloca" , 1);
		r2 = new Respuesta (2 , "ponen" , 0);
		r3 = new Respuesta (3 , "cocinan" , 0);
		r4 = new Respuesta (4 , "colocaron" , 0);
		ej30.respuestas.Add (r1);
		ej30.respuestas.Add (r2);
		ej30.respuestas.Add (r3);
		ej30.respuestas.Add (r4);
		ac2.ejercicios.Add (ej30);


		Ejercicio ej31 = new Ejercicio (31 , "Felipe estira la masa sobre una superficie enharinada y la ____ con un cortador circular" , "" , "" , 6 , true , "COMIDA" );
		r1 = new Respuesta (1 , "corta" , 1);
		r2 = new Respuesta (2 , "parten" , 0);
		r3 = new Respuesta (3 , "estiró" , 0);
		r4 = new Respuesta (4 , "cortan" , 0);
		ej31.respuestas.Add (r1);
		ej31.respuestas.Add (r2);
		ej31.respuestas.Add (r3);
		ej31.respuestas.Add (r4);
		ac2.ejercicios.Add (ej31);


		Ejercicio ej32 = new Ejercicio (32 , "José ____ las galletas con huevo mezclado con café diluido" , "" , "" , 6 , true , "COMIDA" );
		r1 = new Respuesta (1 , "pincela" , 1);
		r2 = new Respuesta (2 , "comieron" , 0);
		r3 = new Respuesta (3 , "pincelan" , 0);
		r4 = new Respuesta (4 , "cortan" , 0);
		ej32.respuestas.Add (r1);
		ej32.respuestas.Add (r2);
		ej32.respuestas.Add (r3);
		ej32.respuestas.Add (r4);
		ac2.ejercicios.Add (ej32);


		Ejercicio ej33 = new Ejercicio (33 , "La harina preparada ____ a que una masa leve mientras de hornea" , "" , "" , 7 , true , "COMIDA" );
		r1 = new Respuesta (1 , "ayuda" , 1);
		r2 = new Respuesta (2 , "hacen" , 0);
		r3 = new Respuesta (3 , "ayudan" , 0);
		r4 = new Respuesta (4 , "hizo" , 0);
		ej33.respuestas.Add (r1);
		ej33.respuestas.Add (r2);
		ej33.respuestas.Add (r3);
		ej33.respuestas.Add (r4);
		ac2.ejercicios.Add (ej33);


		Ejercicio ej34 = new Ejercicio (34 , "Ángela ____ la masa durante 1 hora" , "" , "" , 7 , true , "COMIDA" );
		r1 = new Respuesta (1 , "refrigera" , 1);
		r2 = new Respuesta (2 , "comerán" , 0);
		r3 = new Respuesta (3 , "calientan" , 0);
		r4 = new Respuesta (4 , "hacen" , 0);
		ej34.respuestas.Add (r1);
		ej34.respuestas.Add (r2);
		ej34.respuestas.Add (r3);
		ej34.respuestas.Add (r4);
		ac2.ejercicios.Add (ej34);


		Ejercicio ej35 = new Ejercicio (35 , "María y José ____ el horno 10 minutos antes de introducir las galletas" , "" , "" , 8 , true , "COMIDA" );
		r1 = new Respuesta (1 , "encienden" , 1);
		r2 = new Respuesta (2 , "enciende" , 0);
		r3 = new Respuesta (3 , "prende" , 0);
		r4 = new Respuesta (4 , "utiliza" , 0);
		ej35.respuestas.Add (r1);
		ej35.respuestas.Add (r2);
		ej35.respuestas.Add (r3);
		ej35.respuestas.Add (r4);
		ac2.ejercicios.Add (ej35);


		Ejercicio ej36 = new Ejercicio (36 , "El azúcar morena ____ las preparaciones" , "" , "" , 8 , true , "COMIDA" );
		r1 = new Respuesta (1 , "tiñe" , 1);
		r2 = new Respuesta (2 , "usa" , 0);
		r3 = new Respuesta (3 , "pintan" , 0);
		r4 = new Respuesta (4 , "decoloran" , 0);
		ej36.respuestas.Add (r1);
		ej36.respuestas.Add (r2);
		ej36.respuestas.Add (r3);
		ej36.respuestas.Add (r4);
		ac2.ejercicios.Add (ej36);


		Ejercicio ej37 = new Ejercicio (37 , "Camilo y Andrés ____ las pasas en agua hirviendo hasta que se hayan hinchado" , "" , "" , 9 , true , "COMIDA" );
		r1 = new Respuesta (1 , "colocan" , 1);
		r2 = new Respuesta (2 , "pone" , 0);
		r3 = new Respuesta (3 , "comen" , 0);
		r4 = new Respuesta (4 , "colocó" , 0);
		ej37.respuestas.Add (r1);
		ej37.respuestas.Add (r2);
		ej37.respuestas.Add (r3);
		ej37.respuestas.Add (r4);
		ac2.ejercicios.Add (ej37);


		Ejercicio ej38 = new Ejercicio (38 , "Los cortadores de galletas ____ untarse con harina para que la masa no se pegue" , "" , "" , 9 , true , "COMIDA" );
		r1 = new Respuesta (1 , "deben" , 1);
		r2 = new Respuesta (2 , "tiene" , 0);
		r3 = new Respuesta (3 , "tienen" , 0);
		r4 = new Respuesta (4 , "se" , 0);
		ej38.respuestas.Add (r1);
		ej38.respuestas.Add (r2);
		ej38.respuestas.Add (r3);
		ej38.respuestas.Add (r4);
		ac2.ejercicios.Add (ej38);


		Ejercicio ej39 = new Ejercicio (39 , "Antes de llevarlas al horno, Andrés ____ canela en polvo sobre las galletas" , "" , "" , 10 , true , "COMIDA" );
		r1 = new Respuesta (1 , "espolvorea" , 1);
		r2 = new Respuesta (2 , "hechan" , 0);
		r3 = new Respuesta (3 , "hace" , 0);
		r4 = new Respuesta (4 , "ponen" , 0);
		ej39.respuestas.Add (r1);
		ej39.respuestas.Add (r2);
		ej39.respuestas.Add (r3);
		ej39.respuestas.Add (r4);
		ac2.ejercicios.Add (ej39);


		Ejercicio ej40 = new Ejercicio (40 , "David lleva el agua a hervor y luego la ____ dentro de un bol" , "" , "" , 10 , true , "COMIDA" );
		r1 = new Respuesta (1 , "vierte" , 1);
		r2 = new Respuesta (2 , "colocan" , 0);
		r3 = new Respuesta (3 , "derraman" , 0);
		r4 = new Respuesta (4 , "toma" , 0);
		ej40.respuestas.Add (r1);
		ej40.respuestas.Add (r2);
		ej40.respuestas.Add (r3);
		ej40.respuestas.Add (r4);
		ac2.ejercicios.Add (ej40);


		//Actividad 3 Comida


		Ejercicio ej41 = new Ejercicio (41 , "La carne de pollo es" , "Los jugos de fruta son" , "Es limón es pequeño," , 1 , true , "COMIDA" );
		r1 = new Respuesta (1 , "deliciosa cuando la \n prepara mi mamá" , 1);
		r2 = new Respuesta (2 , "saludables porque \n tienen vitaminas" , 2);
		r3 = new Respuesta (3 , "verde y de zumo ácido" , 3);
		ej41.respuestas.Add (r1);
		ej41.respuestas.Add (r2);
		ej41.respuestas.Add (r3);
		ac3.ejercicios.Add (ej41);


		Ejercicio ej42 = new Ejercicio (42 , "El huevo es uno de \n los alimentos más" , "El Biscotti es una galleta" , "Decora las galletas \n con ajonjolí " , 1 , true , "COMIDA" );
		r1 = new Respuesta (1 , "nutritivos y asequibles \n del mundo entero" , 1);
		r2 = new Respuesta (2 , "delgada sin levadura" , 2);
		r3 = new Respuesta (3 , "blanco y negro" , 3);
		ej42.respuestas.Add (r1);
		ej42.respuestas.Add (r2);
		ej42.respuestas.Add (r3);
		ac3.ejercicios.Add (ej42);


		Ejercicio ej43 = new Ejercicio (43 , "Los Shortbreads están \n hechos a base de azúcar, \n harina y una cantidad" , "Las obleas circulares y " , "Las semillas de amapola \n se pueden reemplazar \n por ajonjolí" , 2 , true , "COMIDA" );
		r1 = new Respuesta (1 , "generosa de mantequilla" , 1);
		r2 = new Respuesta (2 , "delgadas" , 2);
		r3 = new Respuesta (3 , "negro" , 3);
		ej43.respuestas.Add (r1);
		ej43.respuestas.Add (r2);
		ej43.respuestas.Add (r3);
		ac3.ejercicios.Add (ej43);


		Ejercicio ej44 = new Ejercicio (44 , "Las Wafers son \n galletas muy " , "Cambia el color de las \n gomitas según las festividades. \n Utiliza rojo y" , "Los polvorones se \n preparan con cuatro" , 2 , true , "COMIDA" );
		r1 = new Respuesta (1 , "delgadas y quebradizas" , 1);
		r2 = new Respuesta (2 , "verde para navidad" , 2);
		r3 = new Respuesta (3 , "ingredientes básicos: \n harina, manteca, azúcar \n y canela" , 3);
		ej44.respuestas.Add (r1);
		ej44.respuestas.Add (r2);
		ej44.respuestas.Add (r3);
		ac3.ejercicios.Add (ej44);


		Ejercicio ej45 = new Ejercicio (45 , "Los macarrones son \n sabrosos si se preparan \n con almendras" , "La vainilla es uno  \nde los ingredientes" , "El agua debe llevarse \n a hervir, a fuego" , 3 , true , "COMIDA" );
		r1 = new Respuesta (1 , "frescas" , 1);
		r2 = new Respuesta (2 , "favoritos de la humanidad" , 2);
		r3 = new Respuesta (3 , "bajo" , 3);
		ej45.respuestas.Add (r1);
		ej45.respuestas.Add (r2);
		ej45.respuestas.Add (r3);
		ac3.ejercicios.Add (ej45);


		Ejercicio ej46 = new Ejercicio (46 , "Las cerezas son \n pequeñas, muy" , "Para que la bizcotela \n quede más" , "La técnica de blanquear \n consiste en pasar por agua" , 3 , true , "COMIDA" );
		r1 = new Respuesta (1 , "jugosas, de sabor dulce \n y color rojo oscuro" , 1);
		r2 = new Respuesta (2 , "crocante, espolvoreala \n con azúcar" , 2);
		r3 = new Respuesta (3 , "hirviendo ciertos ingredientes" , 3);
		ej46.respuestas.Add (r1);
		ej46.respuestas.Add (r2);
		ej46.respuestas.Add (r3);
		ac3.ejercicios.Add (ej46);


		Ejercicio ej47 = new Ejercicio (47 , "Los Shortbreads \n son galletas" , "La masa debe refrigerarse \n durante varias" , "Para las galletas se \n recomienda usar plátano" , 4 , true , "COMIDA" );
		r1 = new Respuesta (1 , "escocesas, de un \n ligero tono dorado" , 1);
		r2 = new Respuesta (2 , "horas antes de poder \n ser horneada" , 2);
		r3 = new Respuesta (3 , "blanco" , 3);
		ej47.respuestas.Add (r1);
		ej47.respuestas.Add (r2);
		ej47.respuestas.Add (r3);
		ac3.ejercicios.Add (ej47);


		Ejercicio ej48 = new Ejercicio (48 , "Mocha: tipo de café" , "Glasear: técnica que \n consiste en cubrir los \n alimentos con una capa" , "Los cacahuetes \n son semillas" , 4 , true , "COMIDA" );
		r1 = new Respuesta (1 , "árabe de gran calidad" , 1);
		r2 = new Respuesta (2 , "líquida que permite \n dorarlos e impregnarlos \n de sabor" , 2);
		r3 = new Respuesta (3 , "tostadas con las que \n se produce mantequilla" , 3);
		ej48.respuestas.Add (r1);
		ej48.respuestas.Add (r2);
		ej48.respuestas.Add (r3);
		ac3.ejercicios.Add (ej48);


		Ejercicio ej49 = new Ejercicio (49 , "Para obtener un \n sabor diferente, reemplaza \n los frutos" , "Las grageas son bolitas" , "La mermelada es \n de consistencia" , 5 , true , "COMIDA" );
		r1 = new Respuesta (1 , "secos por cacahuetes \n picados" , 1);
		r2 = new Respuesta (2 , "diminutas a base de \n azúcar o caramelo" , 2);
		r3 = new Respuesta (3 , "espesa, a base de \n frutas hervisas con \n azúcar o miel" , 3);
		ej49.respuestas.Add (r1);
		ej49.respuestas.Add (r2);
		ej49.respuestas.Add (r3);
		ac3.ejercicios.Add (ej49);


		Ejercicio ej50 = new Ejercicio (50 , "Los macarrones son \n crocantes por fuera y" , "Usa grageas plateadas o" , "El dulce de leche es \n a base de leche consensada sometida \n a una cocción muy" , 5 , true , "COMIDA" );
		r1 = new Respuesta (1 , "suaves por dentro" , 1);
		r2 = new Respuesta (2 , "doradas para una \n presentación más elegante" , 2);
		r3 = new Respuesta (3 , "lenta" , 3);
		ej50.respuestas.Add (r1);
		ej50.respuestas.Add (r2);
		ej50.respuestas.Add (r3);
		ac3.ejercicios.Add (ej50);


		Ejercicio ej51 = new Ejercicio (51 , "Las chispas de chocolate \n son pequeñas " , "La maicena es harina" , "Procura decorar las galletas \n con rapidez, pues el chocolate \n se seca en poco" , 6 , true , "COMIDA" );
		r1 = new Respuesta (1 , "lágrimas de chocolate \n que se emplean en \n repostería" , 1);
		r2 = new Respuesta (2 , "fina de maíz" , 2);
		r3 = new Respuesta (3 , "tiempo" , 3);
		ej51.respuestas.Add (r1);
		ej51.respuestas.Add (r2);
		ej51.respuestas.Add (r3);
		ac3.ejercicios.Add (ej51);


		Ejercicio ej52 = new Ejercicio (52 , "Los huevos se usan \n para platillos" , "La cocoa son \n semillas de cacao" , "La leche es un elemento" , 6 , true , "COMIDA" );
		r1 = new Respuesta (1 , "dulces y salados" , 1);
		r2 = new Respuesta (2 , "molidas o en polvo" , 2);
		r3 = new Respuesta (3 , "fundamental en la \n alimentación del ser humano" , 3);
		ej52.respuestas.Add (r1);
		ej52.respuestas.Add (r2);
		ej52.respuestas.Add (r3);
		ac3.ejercicios.Add (ej52);


		Ejercicio ej53 = new Ejercicio (53 , "Estas galletas son tan " , "Las pasas se deben \n colocar en agua" , "Estas galletas pueden \n conservarse en la nevera, \n dentro de un envase" , 7 , true , "COMIDA" );
		r1 = new Respuesta (1 , "ligeras que se \n derretirán en tu boca" , 1);
		r2 = new Respuesta (2 , "hirviendo hasta que \n se hayan hinchado" , 2);
		r3 = new Respuesta (3 , "hérmetico" , 3);
		ej53.respuestas.Add (r1);
		ej53.respuestas.Add (r2);
		ej53.respuestas.Add (r3);
		ac3.ejercicios.Add (ej53);


		Ejercicio ej54 = new Ejercicio (54 , "Las variedades de \n plátano son muy" , "El baño María permite \n calentar o cocer" , "Los Springerle se \n elaboran con una masa" , 7 , true , "COMIDA" );
		r1 = new Respuesta (1 , "diversas y varían \n según regiones" , 1);
		r2 = new Respuesta (2 , "suavemente ciertos \n ingredientes" , 2);
		r3 = new Respuesta (3 , "simple de huevos, \n harina y azúcar" , 3);
		ej54.respuestas.Add (r1);
		ej54.respuestas.Add (r2);
		ej54.respuestas.Add (r3);
		ac3.ejercicios.Add (ej54);



		//Actividad 2



		Ejercicio ej55 = new Ejercicio (55 , "El _____ repara las partes de madera de la embarcación" , "" , "" , 1 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "carpintero" , 1);
		r2 = new Respuesta (2 , "tripulación" , 0);
		r3 = new Respuesta (3 , "piratas" , 0);
		ej55.respuestas.Add (r1);
		ej55.respuestas.Add (r2);
		ej55.respuestas.Add (r3);
		ac1.ejercicios.Add (ej55);


		Ejercicio ej56 = new Ejercicio (56 , "Cuando se acababa el agua potable, los _____ los llenaban con agua fresca de los yacimientos" , "" , "" , 1 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "piratas" , 1);
		r2 = new Respuesta (2 , "barco" , 0);
		r3 = new Respuesta (3 , "banderas" , 0);
		ej56.respuestas.Add (r1);
		ej56.respuestas.Add (r2);
		ej56.respuestas.Add (r3);
		ac1.ejercicios.Add (ej56);


		Ejercicio ej57 = new Ejercicio (57 , "Los piratas tenían la costumbre de amarrar a sus _____ espalda contra espalda y arrojarlos al mar" , "" , "" , 2 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "prisioneros" , 1);
		r2 = new Respuesta (2 , "prisionero" , 0);
		r3 = new Respuesta (3 , "esposas" , 0);
		ej57.respuestas.Add (r1);
		ej57.respuestas.Add (r2);
		ej57.respuestas.Add (r3);
		ac1.ejercicios.Add (ej57);


		Ejercicio ej58 = new Ejercicio (58 , "La _____ pirata no puede apostar dinero jugando a las cartas estando abordo" , "" , "" , 2 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "tripulación" , 1);
		r2 = new Respuesta (2 , "piratas" , 0);
		r3 = new Respuesta (3 , "tripulaciones" , 0);
		ej58.respuestas.Add (r1);
		ej58.respuestas.Add (r2);
		ej58.respuestas.Add (r3);
		ac1.ejercicios.Add (ej58);


		Ejercicio ej59 = new Ejercicio (59 , "Se le llama \"Jolly Roger\" a la _____ izada por el barco pirata" , "" , "" , 3 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "bandera" , 1);
		r2 = new Respuesta (2 , "banderas" , 0);
		r3 = new Respuesta (3 , "tripulación" , 0);
		ej59.respuestas.Add (r1);
		ej59.respuestas.Add (r2);
		ej59.respuestas.Add (r3);
		ac1.ejercicios.Add (ej59);


		Ejercicio ej60 = new Ejercicio (60 , "Se dice que prefería el té al ron pero su _____ siempre estaba ebria" , "" , "" , 3 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "tripulación" , 1);
		r2 = new Respuesta (2 , "loro" , 0);
		r3 = new Respuesta (3 , "velas" , 0);
		ej60.respuestas.Add (r1);
		ej60.respuestas.Add (r2);
		ej60.respuestas.Add (r3);
		ac1.ejercicios.Add (ej60);


		Ejercicio ej61 = new Ejercicio (61 , "Barba Negra amarraba mechas encendidas bajo su _____ para atemorizar a sus víctimas" , "" , "" , 4 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "sombrero" , 1);
		r2 = new Respuesta (2 , "mangas" , 0);
		r3 = new Respuesta (3 , "barbas" , 0);
		ej61.respuestas.Add (r1);
		ej61.respuestas.Add (r2);
		ej61.respuestas.Add (r3);
		ac1.ejercicios.Add (ej61);


		Ejercicio ej62 = new Ejercicio (62 , "Los piratas de Dayak eran fieros cazadores de _____ " , "" , "" , 4 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "cabezas" , 1);
		r2 = new Respuesta (2 , "pez" , 0);
		r3 = new Respuesta (3 , "tesoro" , 0);
		ej62.respuestas.Add (r1);
		ej62.respuestas.Add (r2);
		ej62.respuestas.Add (r3);
		ac1.ejercicios.Add (ej62);


		Ejercicio ej63 = new Ejercicio (63 , "Cuando no se usaban las _____ se guardaban en un lugar seco, lejos del rocío del agua" , "" , "" , 5 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "velas" , 1);
		r2 = new Respuesta (2 , "timón" , 0);
		r3 = new Respuesta (3 , "cuerda" , 0);
		ej63.respuestas.Add (r1);
		ej63.respuestas.Add (r2);
		ej63.respuestas.Add (r3);
		ac1.ejercicios.Add (ej63);


		Ejercicio ej64 = new Ejercicio (64 , "El cuarto de la _____ era vital para un barco pirata, la chispa más insignificante podría hacerlo explotar" , "" , "" , 5 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "pólvora" , 1);
		r2 = new Respuesta (2 , "cápitan" , 0);
		r3 = new Respuesta (3 , "cocinas" , 0);
		ej64.respuestas.Add (r1);
		ej64.respuestas.Add (r2);
		ej64.respuestas.Add (r3);
		ac1.ejercicios.Add (ej64);


		Ejercicio ej65 = new Ejercicio (65 , "Los _____ vienen cargados de oro y riquezas saqueadas a los pobladores del Nuevo Mundo" , "" , "" , 6 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "barcos" , 1);
		r2 = new Respuesta (2 , "piratas" , 0);
		r3 = new Respuesta (3 , "tesoro" , 0);
		ej65.respuestas.Add (r1);
		ej65.respuestas.Add (r2);
		ej65.respuestas.Add (r3);
		ac1.ejercicios.Add (ej65);


		Ejercicio ej66 = new Ejercicio (66 , "El tesoro robado se dividirá entre los _____ . El capitán y el cabo obtendrán partes iguales" , "" , "" , 6 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "piratas" , 1);
		r2 = new Respuesta (2 , "capitán" , 0);
		r3 = new Respuesta (3 , "prisionero" , 0);
		ej66.respuestas.Add (r1);
		ej66.respuestas.Add (r2);
		ej66.respuestas.Add (r3);
		ac1.ejercicios.Add (ej66);


		Ejercicio ej67 = new Ejercicio (67 , "El cabo del mar es el segundo en comandar la _____ " , "" , "" , 7 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "embarcación" , 1);
		r2 = new Respuesta (2 , "barco" , 0);
		r3 = new Respuesta (3 , "tripulaciones" , 0);
		ej67.respuestas.Add (r1);
		ej67.respuestas.Add (r2);
		ej67.respuestas.Add (r3);
		ac1.ejercicios.Add (ej67);


		Ejercicio ej68 = new Ejercicio (68 , "Las discusiones serán resueltas con un _____ en tierra firme" , "" , "" , 7 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "duelo" , 1);
		r2 = new Respuesta (2 , "pelea" , 0);
		r3 = new Respuesta (3 , "juegos" , 0);
		ej68.respuestas.Add (r1);
		ej68.respuestas.Add (r2);
		ej68.respuestas.Add (r3);
		ac1.ejercicios.Add (ej68);


		Ejercicio ej69 = new Ejercicio (69 , "El _____ es un fugitivo que siempre obtiene lo que se propone" , "" , "" , 8 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "capitán" , 1);
		r2 = new Respuesta (2 , "barco" , 0);
		r3 = new Respuesta (3 , "piratas" , 0);
		ej69.respuestas.Add (r1);
		ej69.respuestas.Add (r2);
		ej69.respuestas.Add (r3);
		ac1.ejercicios.Add (ej69);


		Ejercicio ej70 = new Ejercicio (70 , "Las  _____ piratas eran izadas como señal que nadie sería respetado" , "" , "" , 8 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "banderas" , 1);
		r2 = new Respuesta (2 , "anclas" , 0);
		r3 = new Respuesta (3 , "vela" , 0);
		ej70.respuestas.Add (r1);
		ej70.respuestas.Add (r2);
		ej70.respuestas.Add (r3);
		ac1.ejercicios.Add (ej70);


		Ejercicio ej71 = new Ejercicio (71 , "Los piratas debían mantener su armamento listo para la acción todo el _____ " , "" , "" , 9 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "tiempo" , 1);
		r2 = new Respuesta (2 , "días" , 0);
		r3 = new Respuesta (3 , "años" , 0);
		ej71.respuestas.Add (r1);
		ej71.respuestas.Add (r2);
		ej71.respuestas.Add (r3);
		ac1.ejercicios.Add (ej71);


		Ejercicio ej72 = new Ejercicio (72 , "Los piratas escalaban a contra viento para reparar las _____ después de las batallas" , "" , "" , 9 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "velas" , 1);
		r2 = new Respuesta (2 , "mástiles" , 0);
		r3 = new Respuesta (3 , "víctimas" , 0);
		ej72.respuestas.Add (r1);
		ej72.respuestas.Add (r2);
		ej72.respuestas.Add (r3);
		ac1.ejercicios.Add (ej72);


		Ejercicio ej73 = new Ejercicio (73 , "Velocidad y sorpresa eran siempre las _____ del éxito pirata" , "" , "" , 10 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "claves" , 1);
		r2 = new Respuesta (2 , "armas" , 0);
		r3 = new Respuesta (3 , "clave" , 0);
		ej73.respuestas.Add (r1);
		ej73.respuestas.Add (r2);
		ej73.respuestas.Add (r3);
		ac1.ejercicios.Add (ej73);


		Ejercicio ej74 = new Ejercicio (74 , "A los piratas les gusta esperar a los barcos que, transportando el _____ español, pasan por allí" , "" , "" , 10 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "tesoro" , 1);
		r2 = new Respuesta (2 , "madera" , 0);
		r3 = new Respuesta (3 , "tesoros" , 0);
		ej74.respuestas.Add (r1);
		ej74.respuestas.Add (r2);
		ej74.respuestas.Add (r3);
		ac1.ejercicios.Add (ej74);


		//Ejercicios piratas actividad 2


		Ejercicio ej75 = new Ejercicio (75 , "Las primeras banderas piratas  ____ color rojo sangre" , "" , "" , 1 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "eran" , 1);
		r2 = new Respuesta (2 , "tenía" , 0);
		r3 = new Respuesta (3 , "vestían" , 0);
		r4 = new Respuesta (4 , "ondeaban" , 0);
		ej75.respuestas.Add (r1);
		ej75.respuestas.Add (r2);
		ej75.respuestas.Add (r3);
		ej75.respuestas.Add (r4);
		ac2.ejercicios.Add (ej75);


		Ejercicio ej76 = new Ejercicio (76 , "Los piratas ____ pocas frutas y verduras y a veces sufrían de escorbuto" , "" , "" , 1 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "comían" , 1);
		r2 = new Respuesta (2 , "comía" , 0);
		r3 = new Respuesta (3 , "tenía" , 0);
		r4 = new Respuesta (4 , "cortaba" , 0);
		ej76.respuestas.Add (r1);
		ej76.respuestas.Add (r2);
		ej76.respuestas.Add (r3);
		ej76.respuestas.Add (r4);
		ac2.ejercicios.Add (ej76);


		Ejercicio ej77 = new Ejercicio (77 , "Los piratas ____ sus propias bomas y granadas a mano" , "" , "" , 2 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "hacían" , 1);
		r2 = new Respuesta (2 , "fabricaba" , 0);
		r3 = new Respuesta (3 , "tenía" , 0);
		r4 = new Respuesta (4 , "robaban" , 0);
		ej77.respuestas.Add (r1);
		ej77.respuestas.Add (r2);
		ej77.respuestas.Add (r3);
		ej77.respuestas.Add (r4);
		ac2.ejercicios.Add (ej77);


		Ejercicio ej78 = new Ejercicio (78 , "Los piratas ____ en barcos con elevadas plataformas de combate" , "" , "" , 2 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "peleaban" , 1);
		r2 = new Respuesta (2 , "juega" , 0);
		r3 = new Respuesta (3 , "buscan" , 0);
		r4 = new Respuesta (4 , "pelea" , 0);
		ej78.respuestas.Add (r1);
		ej78.respuestas.Add (r2);
		ej78.respuestas.Add (r3);
		ej78.respuestas.Add (r4);
		ac2.ejercicios.Add (ej78);


		Ejercicio ej79 = new Ejercicio (79 , "Los piratas  ____ todas las provisiones de tu embarcación" , "" , "" , 3 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "tomaron" , 1);
		r2 = new Respuesta (2 , "cogió" , 0);
		r3 = new Respuesta (3 , "hurto" , 0);
		r4 = new Respuesta (4 , "comió" , 0);
		ej79.respuestas.Add (r1);
		ej79.respuestas.Add (r2);
		ej79.respuestas.Add (r3);
		ej79.respuestas.Add (r4);
		ac2.ejercicios.Add (ej79);


		Ejercicio ej80 = new Ejercicio (80 , "Las banderas piratas ____ usadas pera infundir temor al enemigo" , "" , "" , 3 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "fueron" , 1);
		r2 = new Respuesta (2 , "se" , 0);
		r3 = new Respuesta (3 , "era" , 0);
		r4 = new Respuesta (4 , "pintada" , 0);
		ej80.respuestas.Add (r1);
		ej80.respuestas.Add (r2);
		ej80.respuestas.Add (r3);
		ej80.respuestas.Add (r4);
		ac2.ejercicios.Add (ej80);


		Ejercicio ej81 = new Ejercicio (81 , "El capitán no ____ luchar a bordo" , "" , "" , 4 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "permite" , 1);
		r2 = new Respuesta (2 , "quieren" , 0);
		r3 = new Respuesta (3 , "realiza" , 0);
		r4 = new Respuesta (4 , "piensan" , 0);
		ej81.respuestas.Add (r1);
		ej81.respuestas.Add (r2);
		ej81.respuestas.Add (r3);
		ej81.respuestas.Add (r4);
		ac2.ejercicios.Add (ej81);


		Ejercicio ej82 = new Ejercicio (82 , "El teniende Robert M. mató a Barba Negra, le cortó la nariz y la ____ del mástil de su barco" , "" , "" , 4 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "colgó" , 1);
		r2 = new Respuesta (2 , "pintó" , 0);
		r3 = new Respuesta (3 , "cargó" , 0);
		r4 = new Respuesta (4 , "tiraron" , 0);
		ej82.respuestas.Add (r1);
		ej82.respuestas.Add (r2);
		ej82.respuestas.Add (r3);
		ej82.respuestas.Add (r4);
		ac2.ejercicios.Add (ej82);


		Ejercicio ej83 = new Ejercicio (83 , "Los que fueron forzados a ejercer la piratería y no ____ armas son perdonados" , "" , "" , 5 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "usaron" , 1);
		r2 = new Respuesta (2 , "utiiza" , 0);
		r3 = new Respuesta (3 , "fabrica" , 0);
		r4 = new Respuesta (4 , "tiene" , 0);
		ej83.respuestas.Add (r1);
		ej83.respuestas.Add (r2);
		ej83.respuestas.Add (r3);
		ej83.respuestas.Add (r4);
		ac2.ejercicios.Add (ej83);


		Ejercicio ej84 = new Ejercicio (84 , "Los isoltes,las islas remotas y las cuevas ____ territorio ideal para forajidos y piratas" , "" , "" , 5 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "eran" , 1);
		r2 = new Respuesta (2 , "tenían" , 0);
		r3 = new Respuesta (3 , "oscuras" , 0);
		r4 = new Respuesta (4 , "tenía" , 0);
		ej84.respuestas.Add (r1);
		ej84.respuestas.Add (r2);
		ej84.respuestas.Add (r3);
		ej84.respuestas.Add (r4);
		ac2.ejercicios.Add (ej84);


		Ejercicio ej85 = new Ejercicio (85 , "El barrilero  ____ y repara los barriles donde se guarda la comida y la bebida" , "" , "" , 6 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "fabrica" , 1);
		r2 = new Respuesta (2 , "hacen" , 0);
		r3 = new Respuesta (3 , "fabrican" , 0);
		r4 = new Respuesta (4 , "construyen" , 0);
		ej85.respuestas.Add (r1);
		ej85.respuestas.Add (r2);
		ej85.respuestas.Add (r3);
		ej85.respuestas.Add (r4);
		ac2.ejercicios.Add (ej85);


		Ejercicio ej86 = new Ejercicio (86 , "Al Cabo del Mar le encanta ____ el látigo de nueve ramales" , "" , "" , 6 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "utilizar" , 1);
		r2 = new Respuesta (2 , "golpear" , 0);
		r3 = new Respuesta (3 , "usan" , 0);
		r4 = new Respuesta (4 , "utilizan" , 0);
		ej86.respuestas.Add (r1);
		ej86.respuestas.Add (r2);
		ej86.respuestas.Add (r3);
		ej86.respuestas.Add (r4);
		ac2.ejercicios.Add (ej86);


		Ejercicio ej87 = new Ejercicio (87 , "El fabricante de velas fabrica y ____ las velas del barco y otro elementos de lona" , "" , "" , 7 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "repara" , 1);
		r2 = new Respuesta (2 , "arreglan" , 0);
		r3 = new Respuesta (3 , "cosen" , 0);
		r4 = new Respuesta (4 , "hacen" , 0);
		ej87.respuestas.Add (r1);
		ej87.respuestas.Add (r2);
		ej87.respuestas.Add (r3);
		ej87.respuestas.Add (r4);
		ac2.ejercicios.Add (ej87);


		Ejercicio ej88 = new Ejercicio (88 , "Mientas el Capítan dormía en un gran camarote, su tripulación ____ bajo la cubierta del barco" , "" , "" , 7 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "descansaba" , 1);
		r2 = new Respuesta (2 , "dormían" , 0);
		r3 = new Respuesta (3 , "comía" , 0);
		r4 = new Respuesta (4 , "soñaban" , 0);
		ej88.respuestas.Add (r1);
		ej88.respuestas.Add (r2);
		ej88.respuestas.Add (r3);
		ej88.respuestas.Add (r4);
		ac2.ejercicios.Add (ej88);


		Ejercicio ej89 = new Ejercicio (89 , "Los piratas ____ con oro y plata" , "" , "" , 8 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "soñaban" , 1);
		r2 = new Respuesta (2 , "pensaba" , 0);
		r3 = new Respuesta (3 , "hurtan" , 0);
		r4 = new Respuesta (4 , "sueña" , 0);
		ej89.respuestas.Add (r1);
		ej89.respuestas.Add (r2);
		ej89.respuestas.Add (r3);
		ej89.respuestas.Add (r4);
		ac2.ejercicios.Add (ej89);


		Ejercicio ej90 = new Ejercicio (90 , "Los marineros comunes  ____ la embarcación en buen estado" , "" , "" , 8 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "mantienen" , 1);
		r2 = new Respuesta (2 , "tiene" , 0);
		r3 = new Respuesta (3 , "utiliza" , 0);
		r4 = new Respuesta (4 , "cuidan" , 0);
		ej90.respuestas.Add (r1);
		ej90.respuestas.Add (r2);
		ej90.respuestas.Add (r3);
		ej90.respuestas.Add (r4);
		ac2.ejercicios.Add (ej90);


		Ejercicio ej91 = new Ejercicio (91 , "Como un demonio que sale de los infiernos, Barba Negra no ____ piedad" , "" , "" , 9 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "mostraba" , 1);
		r2 = new Respuesta (2 , "tenían" , 0);
		r3 = new Respuesta (3 , "cargaba" , 0);
		r4 = new Respuesta (4 , "olía" , 0);
		ej91.respuestas.Add (r1);
		ej91.respuestas.Add (r2);
		ej91.respuestas.Add (r3);
		ej91.respuestas.Add (r4);
		ac2.ejercicios.Add (ej91);


		Ejercicio ej92 = new Ejercicio (92 , "El capitán no se contenta con hurtar el botín, tambien ____ el tesoro de la flota completa" , "" , "" , 9 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "desea" , 1);
		r2 = new Respuesta (2 , "quieren" , 0);
		r3 = new Respuesta (3 , "roban" , 0);
		r4 = new Respuesta (4 , "sueñan" , 0);
		ej92.respuestas.Add (r1);
		ej92.respuestas.Add (r2);
		ej92.respuestas.Add (r3);
		ej92.respuestas.Add (r4);
		ac2.ejercicios.Add (ej92);


		Ejercicio ej93 = new Ejercicio (93 , "Los piratas  ____ desde Norteamerica hasta África y subían \n por el mar Rojo, ruta conocida como la Ronda Pirata" , "" , "" , 10 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "navegaban" , 1);
		r2 = new Respuesta (2 , "jugaba" , 0);
		r3 = new Respuesta (3 , "comía" , 0);
		r4 = new Respuesta (4 , "iba" , 0);
		ej93.respuestas.Add (r1);
		ej93.respuestas.Add (r2);
		ej93.respuestas.Add (r3);
		ej93.respuestas.Add (r4);
		ac2.ejercicios.Add (ej93);


		Ejercicio ej94 = new Ejercicio (94 , "Cuando los piratas  ____ a sus víctimas, lanzaban arpeos a las embarcaciones enemigas" , "" , "" , 10 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "abordaban" , 1);
		r2 = new Respuesta (2 , "subía" , 0);
		r3 = new Respuesta (3 , "secuestra" , 0);
		r4 = new Respuesta (4 , "jugaba" , 0);
		ej94.respuestas.Add (r1);
		ej94.respuestas.Add (r2);
		ej94.respuestas.Add (r3);
		ej94.respuestas.Add (r4);
		ac2.ejercicios.Add (ej94);


		//Escenario Piratas Actividad Piratas


		Ejercicio ej95 = new Ejercicio (95 , "El capitán de barba" , "Cliperon, el capitán \n del Mar del Sur, tenía" , "El viaje había sido muy" , 1 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "rubia y fríos ojos \n azules, dirigía desde \n la plaza de Armas este \n nuevo saqueo" , 1);
		r2 = new Respuesta (2 , "grandes ojos azules \n  y una larga nariz" , 2);
		r3 = new Respuesta (3 , "difícil, pues las \n embarcaciones llevaban el \n peso de un enome cargamento \n de esclavos negros" , 3);
		ej95.respuestas.Add (r1);
		ej95.respuestas.Add (r2);
		ej95.respuestas.Add (r3);
		ac3.ejercicios.Add (ej95);

		Ejercicio ej96 = new Ejercicio (96 , "Una ruidosa" , "Segundos después, \n una pesada" , "Se produció un gran" , 1 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "carcajada se oyó \n en la nave capitana" , 1);
		r2 = new Respuesta (2 , "bala de hierro caía \n cerca del palo mayor \n de la embarcación" , 2);
		r3 = new Respuesta (3 , "incendio que se \n propagó rápidamente" , 3);
		ej96.respuestas.Add (r1);
		ej96.respuestas.Add (r2);
		ej96.respuestas.Add (r3);
		ac3.ejercicios.Add (ej96);


		Ejercicio ej97 = new Ejercicio (97 , "Atardecía y hacía mucho" , "Los piratas secuestraron \n a una princesa muy" , "Dibujamos un mapa" , 2 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "calor cuando avistamos tierra" , 1);
		r2 = new Respuesta (2 , "hermosa, llevaba un \n traje azul que brillaba" , 2);
		r3 = new Respuesta (3 , "grande para poder encontrar\n el tesoso cuando volviéramos \npor él" , 3);
		ej97.respuestas.Add (r1);
		ej97.respuestas.Add (r2);
		ej97.respuestas.Add (r3);
		ac3.ejercicios.Add (ej97);


		Ejercicio ej98 = new Ejercicio (98 , "Barba Negra era \n el pirata más" , "Los barcos de velas" , "El barco de los piratas es" , 2 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "temido de Estados Unidos" , 1);
		r2 = new Respuesta (2 , "cuadradas permitían alcanzar \n grandes velocidades" , 2);
		r3 = new Respuesta (3 , "liviano y veloz, perfecto \n para ataques sorpresivos" , 3);
		ej98.respuestas.Add (r1);
		ej98.respuestas.Add (r2);
		ej98.respuestas.Add (r3);
		ac3.ejercicios.Add (ej98);


		Ejercicio ej99 = new Ejercicio (99 , "Su capitán era el " , "Un barco largo lleva \n hasta 50 hombres, tiene \n remos" , "Algunos Cabos de Mar son" , 3 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "terror de los barcos \n mercantes del norte" , 1);
		r2 = new Respuesta (2 , "largos y una sola vela" , 2);
		r3 = new Respuesta (3 , "famosos por atar anzuelos \n de pescar al extremo del \n látigo" , 3);
		ej99.respuestas.Add (r1);
		ej99.respuestas.Add (r2);
		ej99.respuestas.Add (r3);
		ac3.ejercicios.Add (ej99);


		Ejercicio ej100 = new Ejercicio (100 , "Los piratas se deshacen \n de sus pisioneros en islas" , "Los piratas " , "Cuando paso la fuerte" , 3 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "desiertas" , 1);
		r2 = new Respuesta (2 , "capturados serán colgados \n hasta que mueran" , 2);
		r3 = new Respuesta (3 , "tormenta, remamos hasta \n la playa y fuimos a  \n enterrar el cofre" , 3);
		ej100.respuestas.Add (r1);
		ej100.respuestas.Add (r2);
		ej100.respuestas.Add (r3);
		ac3.ejercicios.Add (ej100);


		Ejercicio ej101 = new Ejercicio (101 , "Barba Negra era un hombre" , "El barco era guiado por una gran" , "Para una tripulación \n pirata, las armas" , 4 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "cruel que llevaba el \n cabello y la barba en largos y \n espesos bucles" , 1);
		r2 = new Respuesta (2 , "rueda de madera  \n conectada con el \n tímon" , 2);
		r3 = new Respuesta (3 , "robadas eran tan valiosas \n como cualquier otro tesoro" , 3);
		ej101.respuestas.Add (r1);
		ej101.respuestas.Add (r2);
		ej101.respuestas.Add (r3);
		ac3.ejercicios.Add (ej101);


		Ejercicio ej102 = new Ejercicio (102 , "La embarcación \n pirata tiene gran" , "A los piratas les \n apasiona cantar" , "El pirata Pecasnegras \n es el hombre más" , 4 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "cantidad de pólvora abordo" , 1);
		r2 = new Respuesta (2 , "fuerte, por lo que \n no sería raro que un \n día graben un disco" , 2);
		r3 = new Respuesta (3 , "despistado del mundo" , 3);
		ej102.respuestas.Add (r1);
		ej102.respuestas.Add (r2);
		ej102.respuestas.Add (r3);
		ac3.ejercicios.Add (ej102);


		Ejercicio ej103 = new Ejercicio (103 , "Los piratas \n cilicos eran " , "Todos corrían" , "El cirujano es muy" , 5 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "temidos en el Mediterráneo \n por su cruealdad" , 1);
		r2 = new Respuesta (2 , "rapidamente arriando velas \n y sujetando cañones" , 2);
		r3 = new Respuesta (3 , "rápido con la sierra, \n si te lastimas una pierna, \n te pondrá una de palo" , 3);
		ej103.respuestas.Add (r1);
		ej103.respuestas.Add (r2);
		ej103.respuestas.Add (r3);
		ac3.ejercicios.Add (ej103);


		Ejercicio ej104 = new Ejercicio (104 , "El navegante \n describe una ruta " , "Black Bart fue uno \n de los piratas más" , "Cayó un rayo" , 5 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "segura para la embarcación" , 1);
		r2 = new Respuesta (2 , "exitosos de todos los tiempos. \n Capturó más de 400 barcos" , 2);
		r3 = new Respuesta (3 , "fluorescente sobre el palo mayor \n y lo partió por la mitad" , 3);
		ej104.respuestas.Add (r1);
		ej104.respuestas.Add (r2);
		ej104.respuestas.Add (r3);
		ac3.ejercicios.Add (ej104);


		Ejercicio ej105 = new Ejercicio (105 , "Cuando llegaban a \n tierra los piratas eran" , "Las velas eran de \n lienzo o lona" , "La piratería era " , 6 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "vulnerables, no tenían \n manera de escapar" , 1);
		r2 = new Respuesta (2 , "resistente, tejidas con \n cañamo o algodón" , 2);
		r3 = new Respuesta (3 , "criminal y violenta, se firmaban \n contratos entre capitanes \n y benefactores" , 3);
		ej105.respuestas.Add (r1);
		ej105.respuestas.Add (r2);
		ej105.respuestas.Add (r3);
		ac3.ejercicios.Add (ej105);


		Ejercicio ej106 = new Ejercicio (106 , "Los piratas ingleses atacan" , "En vez de llamarse Pepe \n o Manuel como la mayoría de\n gente, los piratas tenían \n apodos" , "Después de enterrar \nel tesoro" , 6 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "sorpresivamente a los\n barcos mientras están \nanclados en el puerto" , 1);
		r2 = new Respuesta (2 , "raros como Barbarroja\n o Patapalo" , 2);
		r3 = new Respuesta (3 , "preciado, los piratas\n repararon el barco y se\n prepararon para volver al mar" , 3);
		ej106.respuestas.Add (r1);
		ej106.respuestas.Add (r2);
		ej106.respuestas.Add (r3);
		ac3.ejercicios.Add (ej106);


		Ejercicio ej107 = new Ejercicio (107 , "La carne era salada \ny se pudría, así que la \n hambrienta" , "La ropa de los piratas\n puede ser vieja y" , "Los piratas usan\n pequeños botes y se \narman con" , 7 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "tripulación pescaba e\n iba a la playa a cazar" , 1);
		r2 = new Respuesta (2 , "andrajosa, pero están\n provistos de armas temibles" , 2);
		r3 = new Respuesta (3 , "poderosos rifles" , 3);
		ej107.respuestas.Add (r1);
		ej107.respuestas.Add (r2);
		ej107.respuestas.Add (r3);
		ac3.ejercicios.Add (ej107);


		Ejercicio ej108 = new Ejercicio (108 , "Los piratas anclaban\n en la noche " , "Un pirata que rompía las\n reglas podía ser" , "El botín es el tesoro y \n los objetos " , 7 , true , "PIRATAS" );
		r1 = new Respuesta (1 , "fría para esconder sus \n tesoros en islas remotas" , 1);
		r2 = new Respuesta (2 , "abandonado en una \n isla remota" , 2);
		r3 = new Respuesta (3 , "valiosos tomados \n por los piratas" , 3);
		ej108.respuestas.Add (r1);
		ej108.respuestas.Add (r2);
		ej108.respuestas.Add (r3);
		ac3.ejercicios.Add (ej108);



		Persistencia.sistema.actividades.Add(ac1);
		Persistencia.sistema.actividades.Add(ac2);
		Persistencia.sistema.actividades.Add(ac3);
	}


}
