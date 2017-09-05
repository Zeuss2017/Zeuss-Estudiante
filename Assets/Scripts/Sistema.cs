using System.Collections;
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
					if (e.nivel == nivel && actual.escenario.Equals(e.escenario)) {
						ejer.Add (e);
					}
				}
				//Se halla un indice aleatorio de ejercicio con ese nivel
				bool bandera = false;
				Debug.Log ("Se elige un ejercicio entre " + ejer.Count);
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

	public Ejercicio obtenerEjercicio2(){

		int nivel = actual.actividadesEstudiante.ElementAt(1).nivel;
		Debug.Log ("nivel: " + nivel);
		//Se recorren las actividades y se encuentra la primera
		foreach (Actividad a in actividades) {
			if (a.idActividad == 2) {
				//Se recorren los ejercicios de la actividad y se ponen en una lista los ejercicios con el nivel en el que va el estudiante
				List<Ejercicio> ejer = new List<Ejercicio> ();
				foreach (Ejercicio e in a.ejercicios) {
					if (e.nivel == nivel && actual.escenario.Equals(e.escenario)) {
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
					if (e.nivel == nivel && actual.escenario.Equals(e.escenario)) {
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

	public int guardarEjercicio(){
		EjercicioEstudiante ej = new EjercicioEstudiante (this.aciertosActual, this.erroresActual, this.tiempoActual, this.idEjercicioActual,0, false);
		int dif = -1;
		foreach (ActividadEstudiante a in  this.actual.actividadesEstudiante) {
			if (a.idActividad == this.idActividadActual) {
				ej.consecutivo = a.cantidadEjercicios + 1;
				a.cantidadEjercicios++;
				a.ejerciciosEstudiante.Add (ej);
				a.aciertos += this.aciertosActual;
				a.errores += this.erroresActual;
				a.tiempo += this.tiempoActual;
				if (this.erroresActual == 1) {
					a.nivel = a.nivel - 1;
				}
				if (this.erroresActual >= 2) {
					a.nivel = a.nivel - 2;
				}
				if (this.erroresActual == 0) {
					if (a.idActividad == 1) {
						if (this.tiempoActual < 9.37f) {
							a.nivel = a.nivel + 2;
							dif = 2;
						}
						if (this.tiempoActual >= 9.37f && this.tiempoActual < 13.32f) {
							a.nivel = a.nivel + 1;
							dif = 1;
						}
						if (this.tiempoActual >= 13.32f && this.tiempoActual < 21.6f) {
							a.nivel = a.nivel - 1;
							dif = -1;
						}
						if(this.tiempoActual >= 21.6f) {
							a.nivel = a.nivel - 2;
							dif = -2;
						}
					} else if (a.idActividad == 2) {
						if (this.tiempoActual < 32.8f) {
							a.nivel = a.nivel + 2;
							dif = 2;
						}
						if (this.tiempoActual >= 32.8f && this.tiempoActual < 51.255f) {
							a.nivel = a.nivel + 1;
							dif = 1;
						}
						if (this.tiempoActual >= 51.255f && this.tiempoActual < 86.23f) {
							a.nivel = a.nivel - 1;
							dif = -1;
						}
						if(this.tiempoActual >= 86.23f) {
							a.nivel = a.nivel - 2;
							dif = -2;
						}

					} else if (a.idActividad == 3) {
						if (this.tiempoActual < 32.46f) {
							a.nivel = a.nivel + 2;
							dif = 2;
						}
						if (this.tiempoActual >= 35.46f && this.tiempoActual < 51.035f) {
							a.nivel = a.nivel + 1;
							dif = 1;
						}
						if (this.tiempoActual >= 51.035f && this.tiempoActual < 61.7f) {
							a.nivel = a.nivel - 1;
							dif = -1;
						}
						if(this.tiempoActual >= 61.7f) {
							a.nivel = a.nivel - 2;
							dif = -2;
						}
					}
				}

				if (a.nivel < 1) {
					a.nivel = 1; 
				}
				if (a.nivel > a.nivelMaximo) {
					a.nivelMaximo = a.nivel;
				}
				if (a.nivel > 10) {
					a.completado = 1;
					a.nivel = 1;
				}
				//Se tiene que realizar la lógica de subir o bajar nivel!!!
				//Modificar nivel máximo si es necesario
				//Modificar completado si es necesario
				Debug.Log("Se guarda: actividad " + a.idActividad + " ejercicio "+ ej.idEjercicio + " tiempo: " + ej.tiempo+"  Errores: " + ej.errores);
				Debug.Log ("Nuevo nivel del estudiante: " + a.nivel);
				//Debug.Log("Totales actividad:  aciertos" + a.aciertos + " errores "+ a.errores + " tiempo: " + a.tiempo);
			}
		}
		//Suma las monedas ganadas
		this.actual.monedas += 3;
		Persistencia.Save ();
		return dif;
	}

	public void agregarEjercicio(Ejercicio ej , int id){
		bool bandera = false;
		foreach (Ejercicio e in actividades.ElementAt(id-1).ejercicios) {
			if (e.idEjercicio == ej.idEjercicio) {
				e.enunciado1 = ej.enunciado1;
				e.enunciado2 = ej.enunciado2;
				e.enunciado3 = ej.enunciado3;
				e.escenario = ej.escenario;
				e.nivel = ej.nivel;
				bandera = true;
			}
		}
		if (bandera == false) {
			actividades.ElementAt (id - 1).ejercicios.Add (ej);
		}
		Persistencia.Save ();
	}


}
