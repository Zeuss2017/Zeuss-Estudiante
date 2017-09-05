using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActividadControlador : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ComenzarAventura()
    {
        //Application.LoadLevel("CargarPartida");
		if (Persistencia.sistema.actual.escenario.Equals ("COMIDA")) {
			Application.LoadLevel ("IntermediaComida");
		} else {
			Application.LoadLevel ("IntermediaPiratas");
		}
    }

    public void Tienda()
    {
		Application.LoadLevel("Tienda");
    }

    public void DescargarEjercicios()
    {
		StartCoroutine (descargarEjercicios());
    }
    public void EnviarResultados()
    {
		StartCoroutine (subirResultados());
    }
    public void ConectarColegio()
    {
		if (Persistencia.sistema.actual.idEstudiante != -1) {
			Debug.Log ("Ya estás conectado a tu colegio");
		} else {
			Application.LoadLevel("ConexionColegio");
		}

    }
    public void Creditos()
    {

    }







	IEnumerator descargarEjercicios(){
		if (Persistencia.sistema.actual.idEstudiante != -1) {
			WWW w = new WWW ("http://174.138.36.65:8080/Zeuss/webresources/estudiante/ejercicios/" + Persistencia.sistema.actual.idEstudiante /*+ playerIPAddress*/);
			yield return w;

			yield return new WaitForSeconds (1f);

			descargar(w.text);
		} else {
			Debug.Log ("Conectate primero con tu colegio");
		}
	}

	void descargar(string jsonResponse){
		JSONObject jo = new JSONObject(jsonResponse);
		int id=-1;
		foreach(JSONObject j in jo.list){
			Debug.Log(j);
			Ejercicio ej = new Ejercicio ();
			//recorre lista de llaves
			for(int i = 0; i < j.list.Count; i++){
				string key = (string)j.keys[i];
				if (key.Equals ("enunciado1")) {
					ej.enunciado1 = j.list [i].str;
				}
				if (key.Equals ("enunciado2")) {
					ej.enunciado2 = j.list [i].str;
				}
				if (key.Equals ("enunciado3")) {
					ej.enunciado3 = j.list [i].str;
				}
				if (key.Equals ("escenario")) {
					ej.escenario = j.list [i].str;
				}
				if (key.Equals ("id")) {
					ej.idEjercicio = (int)j.list [i].i;
				}
				if (key.Equals ("nivel")) {
					ej.nivel = (int)j.list [i].i;
				}
				if (key.Equals ("actividadId")) {
					JSONObject inside = j.list [i];
					for (int k = 0; k < inside.list.Count; k++) {
						string key2 = (string)inside.keys [k];
						if (key2.Equals ("id")) {
							id = (int)inside.list [k].i;
						}
					}
					Debug.Log ("Id de la actividad: " + id);
				}

			}
			ej.basico = false;
			StartCoroutine (descargarRespuestas (ej , id));
		}
	}

	IEnumerator descargarRespuestas(Ejercicio ej, int id){
		if (Persistencia.sistema.actual.idEstudiante != -1) {
			WWW w = new WWW ("http://174.138.36.65:8080/Zeuss/webresources/ejercicio/respuestas/" + ej.idEjercicio /*+ playerIPAddress*/);
			yield return w;

			yield return new WaitForSeconds (1f);

			descargarRespuestas(w.text , ej, id);
		} else {
			Debug.Log ("Conectate primero con tu colegio");
		}
	}

	void descargarRespuestas(string jsonResponse , Ejercicio ej, int id){
		JSONObject jo = new JSONObject(jsonResponse);
		List<Respuesta> respuestas = new List<Respuesta>();
		foreach(JSONObject j in jo.list){
			Debug.Log(j);
			Respuesta r = new Respuesta ();
			//recorre lista de llaves
			for(int i = 0; i < j.list.Count; i++){
				string key = (string)j.keys[i];
				if (key.Equals ("correcta")) {
					r.correcto = (int)j.list [i].i;

				}
				if (key.Equals ("enunciado")) {
					r.enunciado = j.list [i].str;
				}
				if (key.Equals ("id")) {
					r.idRespuesta = (int)j.list [i].i;
				}

			}

			respuestas.Add (r);
		}

		ej.respuestas = respuestas;
		if (!Persistencia.sistema.actual.ejerciciosDisponibles.Contains (ej.idEjercicio)) {
			Persistencia.sistema.actual.ejerciciosDisponibles.Add (ej.idEjercicio);
		} 
		Persistencia.sistema.agregarEjercicio (ej, id);

		Debug.Log ("Descarga ejercicio: " + ej.enunciado1);

	}






	//Subir resultados
	IEnumerator subirResultados(){
		if (Persistencia.sistema.actual.idEstudiante != -1) {
			foreach (ActividadEstudiante a in Persistencia.sistema.actual.actividadesEstudiante) {
				int tiempo = (int)a.tiempo;
				WWW w = new WWW ("http://174.138.36.65:8080/Zeuss/webresources/actividadestudiante/subirAct/" + a.idActividad + "/" + Persistencia.sistema.actual.idEstudiante
					+ "/" + a.aciertos + "/" + a.errores + "/" + tiempo + "/" + a.completado + "/" + a.nivelMaximo);
				yield return w;
				foreach (EjercicioEstudiante e in a.ejerciciosEstudiante) {
					if (e.enviado == false) {
						int nivel = -1;
						int tiempo2 = (int)e.tiempo;
						foreach (Actividad ac in Persistencia.sistema.actividades) {
							if (ac.idActividad == a.idActividad) {
								foreach (Ejercicio ej in ac.ejercicios) {
									if (ej.idEjercicio == e.idEjercicio) {
										nivel = ej.nivel;
									}
								}
							}
						}
						WWW w2 = new WWW ("http://174.138.36.65:8080/Zeuss/webresources/ejercicioestudiante/subirEj/" + a.idActividad + "/" + Persistencia.sistema.actual.idEstudiante
							+ "/" + e.aciertos + "/" + e.errores + "/" + tiempo2 + "/" + e.consecutivo + "/" + nivel);
						e.enviado = true;
						yield return w2;
					}
				}
			}

			Debug.Log ("Éxito enviando los resultados!!");
			yield return new WaitForSeconds (1f);

		} else {
			Debug.Log ("Conectate primero con tu colegio");
		}
	}




}
