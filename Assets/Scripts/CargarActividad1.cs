using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEngine.UI;

public class CargarActividad1 : MonoBehaviour {

    public GameObject uiInstrucciones;
    public GameObject uiPausa;
    public GameObject uiGanar;
    public GameObject uiNuevoIntento;
	public GameObject enunciado;
    public GameObject uiSubirNivel;
    public GameObject uiAyudaContenido;
    public GameObject uiSinPistas;
    public enum GameState { Inicio, Ejecucion, Pausa };
    public static GameState gameState = GameState.Inicio;
    private static bool gano ;
    private static bool noGano ;
	public bool ayudado = false;
    private static bool subioNivel = false;
    private static bool reanudarActividad = false;
	private bool parar = false;
    public Text uiDinero;
    private static bool superado = false;
    // Use this for initialization
    void Start () {
        if (!superado)
        {
            foreach (ActividadEstudiante e in Persistencia.sistema.actual.actividadesEstudiante.ToArray())
            {
                if (e.idActividad == 2)
                {
                    if (e.completado == 1)
                    {
                        if (Persistencia.sistema.actual.escenario.Equals("COMIDA"))
                        {
                            Application.LoadLevel("IntermediaComida");
                            IntermedioActividades.desbloqueado();
                            superado = true;   
                        }
                        else
                        {
                            Application.LoadLevel("IntermediaPiratas");
                            IntermedioActividadesPiratas.desbloqueado();
                            superado = true;
                        }
                    }
                }

            }
        }
        
        gano = false;
        noGano = false;
        uiPausa.SetActive(false);
        uiGanar.SetActive(false);
        uiNuevoIntento.SetActive(false);
        uiSubirNivel.SetActive(false);
        uiAyudaContenido.SetActive(false);
        uiSinPistas.SetActive(false);
        gameState = GameState.Inicio;
        Time.timeScale = 1;
		uiDinero.text =  Persistencia.sistema.actual.monedas.ToString();
        ControladorAyudaContenido.actividadReanudar(1);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == GameState.Inicio && Input.GetMouseButtonDown(0))
        {
            uiInstrucciones.SetActive(false);
            gameState = GameState.Ejecucion;
            Ejercicio ej = Persistencia.sistema.obtenerEjercicio2();

			GameObject.Find("Opcion1").transform.Find("Enunciado").GetComponent<TextMesh>().text = ej.respuestas.ElementAt(0).enunciado;
			GameObject.Find("Opcion1").GetComponent<Actividad1_Logica>().correcta = ej.respuestas.ElementAt(0).correcto;

			GameObject.Find("Opcion2").transform.Find("Enunciado").GetComponent<TextMesh>().text = ej.respuestas.ElementAt(1).enunciado;
            GameObject.Find("Opcion2").GetComponent<Actividad1_Logica>().correcta = ej.respuestas.ElementAt(1).correcto;

			GameObject.Find("Opcion3").transform.Find("Enunciado").GetComponent<TextMesh>().text = ej.respuestas.ElementAt(2).enunciado;
            GameObject.Find("Opcion3").GetComponent<Actividad1_Logica>().correcta = ej.respuestas.ElementAt(2).correcto;

            enunciado.GetComponent<TextMesh>().text = ej.enunciado1;

            Persistencia.sistema.idEjercicioActual = ej.idEjercicio;
            Persistencia.sistema.idActividadActual = 2;
            Persistencia.sistema.aciertosActual = 0;
            Persistencia.sistema.erroresActual = 0;
            Persistencia.sistema.tiempoActual = Time.time;
			StartCoroutine(ayudaConcepto());
           
        }

        if (gameState == GameState.Ejecucion && Input.GetKeyDown("p"))
        {
            uiPausa.SetActive(true);
            gameState = GameState.Pausa;
            Time.timeScale = 0;
         }
        else
        // si el estado es Pausa, y oprime la tecla p se cambia al estado en Ejecución.
        if (gameState == GameState.Pausa && Input.GetKeyDown("p"))
        {
            gameState = GameState.Ejecucion;
            Time.timeScale = 1;
            uiPausa.SetActive(false);
         }

        if (gano && !parar)
        {
            Persistencia.sistema.aciertosActual++;
			Debug.Log ("Tiempo api: " + Time.time + " Tiempo inicio: "  + Persistencia.sistema.tiempoActual);
            Persistencia.sistema.tiempoActual = Time.time - Persistencia.sistema.tiempoActual;

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
			parar = true;
        }
        if (noGano)
        {
            StartCoroutine(mostrarNuevoIntento());
            noGano = false;
        }
        if (reanudarActividad)
        {
            uiAyudaContenido.SetActive(false);
            Time.timeScale = 1;
            reanudarActividad = false;
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
        yield return new WaitForSeconds(1 * Time.timeScale);
        Time.timeScale = 1;
        uiNuevoIntento.SetActive(false);
        
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
    public void regresar(){
		if (Persistencia.sistema.actual.escenario.Equals ("COMIDA")) {
			Application.LoadLevel ("IntermediaComida");
		} else {
			Application.LoadLevel ("IntermediaPiratas");
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
        Time.timeScale = 1;
        uiPausa.SetActive(false);
        
    }
    /*Nombre del Metodo: PausarActividad
      Entradas: Ninguna
      Salidas: Void
      Descripcion: Permite pausar la actividad lúdica.
         
    */
    public void PausarActividad()
    {
        gameState = GameState.Pausa;
        Time.timeScale = 0;
        uiPausa.SetActive(true);
        
    }
    /*Nombre del Metodo: RegresarMenuPrincipal
      Entradas: Ninguna
      Salidas: Void
      Descripcion: Permite regresar al menú principal de la aplicación.
         
    */
    public void RegresarMenuPrincipal()
    {
		Application.LoadLevel("MenuActividades");
    }
    /*Nombre del Metodo: Tienda
      Entradas: Ninguna
      Salidas: Void
      Descripcion: Permite ir a la tienda.
         
    */
    public void Tienda()
    {
		Application.LoadLevel("Tienda");
    }
    /*Nombre del Metodo: victoria
      Entradas: victoria
      Salidas: Void
      Descripcion: Metodo ejecutado por una caja de respuestas para indicar si se eligió la indicada.
         
    */
    public static void victoria(bool victoria)
    {
        if (victoria)
        {
            gano = true;
        }
        else
        {
            noGano = true;
        }

    }
    /*Nombre del Metodo: pista
      Entradas: ninguna
      Salidas: Void
      Descripcion: descuenta una pista de las que tiene el usuario para ayudarlo a resolver el ejercicio.
         
    */
    public void pista(){
		if (ayudado == true) {
			//Quitar comentario
			//EditorUtility.DisplayDialog ("Advertencia", "Ya utilizaste tu pista!", "Ok");
		} else {
			if (Persistencia.sistema.actual.cantidadAyudas > 0) {
				if (GameObject.Find ("Opcion1").GetComponent<Actividad1_Logica> ().correcta == 1) {
					Destroy (GameObject.Find ("Opcion3"));
				} else if (GameObject.Find ("Opcion3").GetComponent<Actividad1_Logica> ().correcta == 1) {
					Destroy (GameObject.Find ("Opcion1"));
				} else {
					Destroy (GameObject.Find ("Opcion1"));
				}
				Persistencia.sistema.actual.cantidadAyudas--;
				ayudado = true;
			} else {
                StartCoroutine(mostrarSinPistas());
            }
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
			if (tiempo > 67.5f) {
                uiAyudaContenido.SetActive(true);
                Time.timeScale = 0;
                yield break;
			}
			yield return new WaitForSeconds(1f);
		}
	}

	public void siguiente(){
		if (Persistencia.sistema.actual.escenario.Equals ("COMIDA")) {
			Application.LoadLevel ("ActividadSaltoComida");
		} else {
			Application.LoadLevel ("ActividadSaltoPiratas");
		}

	}
}
