using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using UnityEngine.UI;

public class Actividad3_Logica : MonoBehaviour {

    public GameObject pregunta1;
    public GameObject pregunta2;
    public GameObject pregunta3;
    public GameObject respuesta1;
    public GameObject respuesta2;
    public GameObject respuesta3;
	public GameObject canon1;
	public GameObject canon2;
	public GameObject canon3;
    public GameObject uiInicio;
    public GameObject uiPausa;
    public GameObject uiGanar;
    public GameObject uiNuevoIntento;
    public GameObject uiSubirNivel;
    public GameObject uiAyudaContenido;
    public GameObject uiSinPistas;

    private static bool reanudarActividad = false;
    public enum GameState { Inicio, Ejecucion, Pausa };
    public static GameState gameState ;
    List<GameObject> listaPreguntas= new List<GameObject>();
    List<GameObject> listaRespuestas = new List<GameObject>();
    private int contador = 0;
    private int cantidadRespuestas;
	bool ganador = false;
    private static int idDisparo=0;
    private int llevaDisparo=0; //pregunta que lleva el disparo
	public Text uiDinero;

    void Start () {
        pregunta1.SetActive(false);
        pregunta2.SetActive(false);
        pregunta3.SetActive(false);
        respuesta1.SetActive(false);
        respuesta2.SetActive(false);
        respuesta3.SetActive(false);
        uiSinPistas.SetActive(false);
        canon1.SetActive(false);
        canon2.SetActive(false);
        canon3.SetActive(false);
        uiGanar.SetActive(false);
        uiNuevoIntento.SetActive(false);
        uiPausa.SetActive(false);
        uiSubirNivel.SetActive(false);
        uiAyudaContenido.SetActive(false);
        gameState = GameState.Inicio;
        Time.timeScale = 1;
		uiDinero.text =  Persistencia.sistema.actual.monedas.ToString();
        ControladorAyudaContenido.actividadReanudar(3);
    }
	
	void Update () {
        if(gameState==GameState.Inicio && Input.GetMouseButtonDown(0))
        {

            gameState = GameState.Ejecucion;
            uiInicio.SetActive(false);
            pregunta1.SetActive(true);
            pregunta2.SetActive(true);
            pregunta3.SetActive(true);
            respuesta1.SetActive(true);
            respuesta2.SetActive(true);
            respuesta3.SetActive(true);
            canon1.SetActive(true);
            canon2.SetActive(true);
            canon3.SetActive(true);
            listaPreguntas.Add(pregunta1);
            listaPreguntas.Add(pregunta2);
            listaPreguntas.Add(pregunta3);

            Ejercicio ej = Persistencia.sistema.obtenerEjercicio3();

            foreach (GameObject p in listaPreguntas)
            {
                if (contador > 2)
                {
                    contador = 0;
                }
                if (contador == 0)
                {
                    p.transform.Find("Enunciado").GetComponent<TextMesh>().text = ej.enunciado1;
                }
                if (contador == 1)
                {
                    p.transform.Find("Enunciado").GetComponent<TextMesh>().text = ej.enunciado2;
                }
                if (contador == 2)
                {
                    p.transform.Find("Enunciado").GetComponent<TextMesh>().text = ej.enunciado3;
                }
                p.SendMessage("asignarId", ej.respuestas.ElementAt(contador).correcto);
                contador++;
            }
            contador = 0;
            listaRespuestas.Add(respuesta1);
            listaRespuestas.Add(respuesta2);
            listaRespuestas.Add(respuesta3);
            foreach (GameObject p in listaRespuestas)
            {
                p.SendMessage("asignarPregunta", ej.respuestas.ElementAt(contador).correcto);
                p.transform.Find("Enunciado").GetComponent<TextMesh>().text = ej.respuestas.ElementAt(contador).enunciado;
                contador++;
            }

            int n1 = Random.Range(1, 7);
            if (n1 == 2)
            {
                listaRespuestas.ElementAt(1).SendMessage("asignarPregunta", ej.respuestas.ElementAt(2).correcto);
                listaRespuestas.ElementAt(1).transform.Find("Enunciado").GetComponent<TextMesh>().text = ej.respuestas.ElementAt(2).enunciado;
                listaRespuestas.ElementAt(2).SendMessage("asignarPregunta", ej.respuestas.ElementAt(1).correcto);
                listaRespuestas.ElementAt(2).transform.Find("Enunciado").GetComponent<TextMesh>().text = ej.respuestas.ElementAt(1).enunciado;
            }
            if (n1 == 3)
            {
                listaRespuestas.ElementAt(0).SendMessage("asignarPregunta", ej.respuestas.ElementAt(2).correcto);
                listaRespuestas.ElementAt(0).transform.Find("Enunciado").GetComponent<TextMesh>().text = ej.respuestas.ElementAt(2).enunciado;
                listaRespuestas.ElementAt(2).SendMessage("asignarPregunta", ej.respuestas.ElementAt(0).correcto);
                listaRespuestas.ElementAt(2).transform.Find("Enunciado").GetComponent<TextMesh>().text = ej.respuestas.ElementAt(0).enunciado;
            }
            if (n1 == 4)
            {
                listaRespuestas.ElementAt(0).SendMessage("asignarPregunta", ej.respuestas.ElementAt(1).correcto);
                listaRespuestas.ElementAt(0).transform.Find("Enunciado").GetComponent<TextMesh>().text = ej.respuestas.ElementAt(1).enunciado;
                listaRespuestas.ElementAt(1).SendMessage("asignarPregunta", ej.respuestas.ElementAt(0).correcto);
                listaRespuestas.ElementAt(1).transform.Find("Enunciado").GetComponent<TextMesh>().text = ej.respuestas.ElementAt(0).enunciado;
            }
            if (n1 == 5)
            {
                listaRespuestas.ElementAt(0).SendMessage("asignarPregunta", ej.respuestas.ElementAt(1).correcto);
                listaRespuestas.ElementAt(0).transform.Find("Enunciado").GetComponent<TextMesh>().text = ej.respuestas.ElementAt(1).enunciado;
                listaRespuestas.ElementAt(1).SendMessage("asignarPregunta", ej.respuestas.ElementAt(2).correcto);
                listaRespuestas.ElementAt(1).transform.Find("Enunciado").GetComponent<TextMesh>().text = ej.respuestas.ElementAt(2).enunciado;
                listaRespuestas.ElementAt(2).SendMessage("asignarPregunta", ej.respuestas.ElementAt(0).correcto);
                listaRespuestas.ElementAt(2).transform.Find("Enunciado").GetComponent<TextMesh>().text = ej.respuestas.ElementAt(0).enunciado;
            }
            if (n1 == 6)
            {
                listaRespuestas.ElementAt(0).SendMessage("asignarPregunta", ej.respuestas.ElementAt(2).correcto);
                listaRespuestas.ElementAt(0).transform.Find("Enunciado").GetComponent<TextMesh>().text = ej.respuestas.ElementAt(2).enunciado;
                listaRespuestas.ElementAt(1).SendMessage("asignarPregunta", ej.respuestas.ElementAt(0).correcto);
                listaRespuestas.ElementAt(1).transform.Find("Enunciado").GetComponent<TextMesh>().text = ej.respuestas.ElementAt(0).enunciado;
                listaRespuestas.ElementAt(2).SendMessage("asignarPregunta", ej.respuestas.ElementAt(1).correcto);
                listaRespuestas.ElementAt(2).transform.Find("Enunciado").GetComponent<TextMesh>().text = ej.respuestas.ElementAt(1).enunciado;
            }

            this.cantidadRespuestas = contador;

            pregunta1.SendMessage("activarDisparo");
            llevaDisparo = 1;
            Persistencia.sistema.idActividadActual = 3;
            Persistencia.sistema.idEjercicioActual = ej.idEjercicio;
            Persistencia.sistema.aciertosActual = 0;
            Persistencia.sistema.erroresActual = 0;
            Persistencia.sistema.tiempoActual = Time.time;
			StartCoroutine(ayudaConcepto());
        }

        if (gameState == GameState.Ejecucion)
        {
            if (idDisparo != 0)
            {
                switch (idDisparo)
                {
                    case 1:
                        Destroy(pregunta1);
                        Destroy(canon1);
                        pregunta2.SendMessage("activarDisparo");
                        idDisparo = 0;
                        llevaDisparo = 2;
                        break;
                    case 2:
                        Destroy(pregunta2);
                        Destroy(canon2);
                        pregunta3.SendMessage("activarDisparo");
                        idDisparo = 0;
                        llevaDisparo = 3;
                        break;
                    case 3:
                        Destroy(pregunta3);
                        Destroy(canon3);
                        idDisparo = 5;
                        break;
                    case 4:
                        StartCoroutine(mostrarNuevoIntento());
                        idDisparo = 0;
                        break;
                    case 5:
                        Persistencia.sistema.tiempoActual = Time.time - Persistencia.sistema.tiempoActual;
                        idDisparo = 0;
                        int diferencia = Persistencia.sistema.guardarEjercicio();
                        if (diferencia > 0)
                        {
                            uiSubirNivel.SetActive(true);
                            Time.timeScale = 0;
                        }
                        else
                        {
                            uiGanar.SetActive(true);
                            Time.timeScale = 0;
                        }
                        break;
                }
             }
            if (Input.GetKeyDown("p"))
            {
                gameState = GameState.Pausa;
                uiPausa.SetActive(true);
                cambiarEstadoDisparo(false);
                Time.timeScale = 0;
            }
            
        }
        else
        // si el estado es Pausa, y oprime la tecla p se cambia al estado en Ejecución.
        if (gameState == GameState.Pausa && Input.GetKeyDown("p"))
        {
            gameState = GameState.Ejecucion;
            uiPausa.SetActive(false);
            cambiarEstadoDisparo(true);
            Time.timeScale = 1;
        }
        if (reanudarActividad)
        {
            Debug.Log("cambio");
            uiAyudaContenido.SetActive(false);
            Time.timeScale = 1;
            cambiarEstadoDisparo(true);
            reanudarActividad = false;
        }


    }

    /*Nombre del Metodo: ReanudarActividad
      Entradas: Ninguna
      Salidas: Void
      Descripcion: Permite reanudar la actividad ludica luego de que está se ha pausado.
         
    */
    public void ReanudarActividad()
    {
        gameState = GameState.Ejecucion;
        uiPausa.SetActive(false);
        cambiarEstadoDisparo(true);
        Time.timeScale = 1;
    }
    /*Nombre del Metodo: MostrarSinPistas
      Entradas: Ninguna
      Salidas: IEnumerator
      Descripcion: Cuando el usuario no tiene pistas y desea usar una
                   se le muestra la excepcion que dura aproximadamente 1 segundo en pantalla.
         
    */
    IEnumerator mostrarSinPistas()
    {
        uiSinPistas.SetActive(true);
        Time.timeScale = 0.0000001f;
        yield return new WaitForSeconds(1 * Time.timeScale);
        Time.timeScale = 1;
        uiSinPistas.SetActive(false);

    }
    /*Nombre del Metodo: PausarActividad
      Entradas: Ninguna
      Salidas: Void
      Descripcion: Permite pausar la actividad lúdica.
         
    */
    public void PausarActividad()
    {
        gameState = GameState.Pausa;
        uiPausa.SetActive(true);
        cambiarEstadoDisparo(false);
        Time.timeScale = 0;
    }
    /*Nombre del Metodo: RegresarMenuPrincipal
      Entradas: Ninguna
      Salidas: Void
      Descripcion: Permite regresar al menú principal de la aplicación.
         
    */
    public void RegresarMenuPrincipal()
    {
		Application.LoadLevel("MenuActividades");
        Time.timeScale = 1;
    }
    /*Nombre del Metodo: Tienda
      Entradas: Ninguna
      Salidas: Void
      Descripcion: Permite ir a la tienda.
         
    */
    public void Tienda()
    {
		Application.LoadLevel("Tienda");
        Time.timeScale = 1;
    }

    public void regresar(){
		if (Persistencia.sistema.actual.escenario.Equals ("COMIDA")) {
			Application.LoadLevel ("IntermediaComida");
		} else {
			Application.LoadLevel ("IntermediaPiratas");
		}

	}
    

    /*Nombre del Metodo: MostrarNuevoIntento
      Entradas: Ninguna
      Salidas: IEnumerator
      Descripcion: Cuando el usuario se equivoca en seleccionar una respuesta,
                   lanza un mensaje que dura aproximandamente 1 segundo en pantalla.
         
    */
    IEnumerator mostrarNuevoIntento()
    {
        uiNuevoIntento.SetActive(true);
        Time.timeScale = 0.0000001f;
        cambiarEstadoDisparo(false);
        yield return new WaitForSeconds(1 * Time.timeScale);
        Time.timeScale = 1;
        uiNuevoIntento.SetActive(false);
        cambiarEstadoDisparo(true);
    }
    /*Nombre del Metodo: DisparoExitoso
      Entradas: entero id
      Salidas: void
      Descripcion: Mensaje enviado por un proyectil para informar que ha tenido exito.
         
    */
    public static void DisparoExitoso(int id)
    {
        idDisparo = id;
    }
    /*Nombre del Metodo: cambiarEstadoDisparo
      Entradas: boleano activar
      Salidas: Void
      Descripcion: Al pausar la actividad lúdica, se inhabilitan los cañones. De igual forma al reanudar la
                   actividad ludica se habilitan los cañones.
    */
    public void cambiarEstadoDisparo(bool activar)
    {
        switch(llevaDisparo){
            case 1:
                if (activar)
                {
                    pregunta1.SendMessage("activarDisparo");
                }
                else
                {
                    pregunta1.SendMessage("desactivarDisparo");
                }
                break;
            case 2:
                if (activar)
                {
                    pregunta2.SendMessage("activarDisparo");
                }
                else
                {
                    pregunta2.SendMessage("desactivarDisparo");
                }
                break;
            case 3:
                if (activar)
                {
                    pregunta3.SendMessage("activarDisparo");
                }
                else
                {
                    pregunta3.SendMessage("desactivarDisparo");
                }
                break;

        }
    }
    /*Nombre del Metodo: pista
      Entradas: ninguna
      Salidas: Void
      Descripcion: descuenta una pista de las que tiene el usuario para ayudarlo a resolver el ejercicio.
         
    */
    public void pista(){
		bool disponible = false;
		if (Persistencia.sistema.actual.cantidadAyudas > 0) {
			if (pregunta1 != null) {		
				int x = pregunta1.GetComponent<Pregunta_Control3> ().getId ();
				if (respuesta1 != null) {
					if (respuesta1.GetComponent<Respuesta_Control3> ().getPregunta () == x) {
						Destroy (pregunta1);
						Destroy (respuesta1);
					}
				}
				if (respuesta2 != null) {
					if (respuesta2.GetComponent<Respuesta_Control3> ().getPregunta () == x) {
						Destroy (pregunta1);
						Destroy (respuesta2);
					}
				}
				if (respuesta3 != null) {
					if (respuesta3.GetComponent<Respuesta_Control3> ().getPregunta () == x) {
						Destroy (pregunta1);
						Destroy (respuesta3);
					}
				}
				Destroy (canon1);
				pregunta2.SendMessage("activarDisparo");
			} else if (pregunta2 != null) {
				int x = pregunta2.GetComponent<Pregunta_Control3> ().getId ();
				if (respuesta1 != null) {
					if (respuesta1.GetComponent<Respuesta_Control3> ().getPregunta () == x) {
						Destroy (pregunta2);
						Destroy (respuesta1);
					}
				}
				if (respuesta2 != null) {
					if (respuesta2.GetComponent<Respuesta_Control3> ().getPregunta () == x) {
						Destroy (pregunta2);
						Destroy (respuesta2);
					}
				}
				if (respuesta3 != null) {
					if (respuesta3.GetComponent<Respuesta_Control3> ().getPregunta () == x) {
						Destroy (pregunta2);
						Destroy (respuesta3);
					}
				}
				Destroy (canon2);
				pregunta3.SendMessage("activarDisparo");
			}
			Persistencia.sistema.actual.cantidadAyudas--;
		} else {
            StartCoroutine(mostrarSinPistas());
        }

	}

    /*Nombre del Metodo: reanudarActividadContenido
      Entradas: ninguna
      Salidas: Void
      Descripcion: una vez se finaliza la ayuda de contenido, esta envia un mensaje a la actividad
                   para que se reanude.
         
    */
    public static void reanudarActividadContenido()
    {
        reanudarActividad = true;

    }
    /*Nombre del Metodo: ayudaConcepto
      Entradas: ninguna
      Salidas: IEnumerator
      Descripcion: este metodo se ejecuta automaticamente una vez se llegue al tiempo promedio para
                    resolver una actividad. si el usuario no ha resuleto la actividad; se le muestra 
                    una ayuda de contenido que lo oriente a encontrar la solucion al ejercicio.
         
    */
    IEnumerator ayudaConcepto(){
		while (true) {
			float tiempo = Time.time - Persistencia.sistema.tiempoActual;
			if (tiempo > 50.47f) {//50.47
                uiAyudaContenido.SetActive(true);
                Time.timeScale = 0;
                cambiarEstadoDisparo(false);
                yield break;
			}
			yield return new WaitForSeconds(1f);
		}
	}

	public void siguiente(){
		if (Persistencia.sistema.actual.escenario.Equals ("COMIDA")) {
			Application.LoadLevel ("ShooterComida");
		} else {
			Application.LoadLevel ("ShooterPiratas");
		}

	}
    
}
