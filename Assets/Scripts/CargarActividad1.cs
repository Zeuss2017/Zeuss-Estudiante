using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

public class CargarActividad1 : MonoBehaviour {

    public GameObject uiInstrucciones;
    public GameObject uiPausa;
    public GameObject uiGanar;
    public GameObject uiNuevoIntento;
    public enum GameState { Inicio, Ejecucion, Pausa };
    public static GameState gameState = GameState.Inicio;
    private static bool gano ;
    private static bool noGano ;
	public bool ayudado = false;
    // Use this for initialization
    void Start () {
        gano = false;
        noGano = false;
        uiPausa.SetActive(false);
        uiGanar.SetActive(false);
        uiNuevoIntento.SetActive(false);
        gameState = GameState.Inicio;
        Time.timeScale = 1;
        
	}

    // Update is called once per frame
    void Update()
    {
        if (gameState == GameState.Inicio && Input.GetMouseButtonDown(0))
        {
            uiInstrucciones.SetActive(false);
            gameState = GameState.Ejecucion;
            Ejercicio ej = Persistencia.sistema.obtenerEjercicio1();

            GameObject.Find("Opcion1").GetComponent<TextMesh>().text = ej.respuestas.ElementAt(0).enunciado;
            GameObject.Find("Opcion1").GetComponent<Actividad1_Logica>().correcta = ej.respuestas.ElementAt(0).correcto;

            GameObject.Find("Opcion2").GetComponent<TextMesh>().text = ej.respuestas.ElementAt(1).enunciado;
            GameObject.Find("Opcion2").GetComponent<Actividad1_Logica>().correcta = ej.respuestas.ElementAt(1).correcto;

            GameObject.Find("Opcion3").GetComponent<TextMesh>().text = ej.respuestas.ElementAt(2).enunciado;
            GameObject.Find("Opcion3").GetComponent<Actividad1_Logica>().correcta = ej.respuestas.ElementAt(2).correcto;

            GameObject.Find("Enunciado").GetComponent<TextMesh>().text = ej.enunciado1;

            Persistencia.sistema.idEjercicioActual = ej.idEjercicio;
            Persistencia.sistema.idActividadActual = 1;
            Persistencia.sistema.aciertosActual = 0;
            Persistencia.sistema.erroresActual = 0;
            Persistencia.sistema.tiempoActual = Time.time;
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

        if (gano)
        {
            uiGanar.SetActive(true);
            Time.timeScale = 0;
        }
        if (noGano)
        {
            StartCoroutine(mostrarNuevoIntento());
            noGano = false;
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
    public void regresar(){
		Application.LoadLevel("Intermedia");
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

    }
    /*Nombre del Metodo: Tienda
      Entradas: Ninguna
      Salidas: Void
      Descripcion: Permite ir a la tienda.
         
    */
    public void Tienda()
    {

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

	public void pista(){
		if (ayudado == true) {
			EditorUtility.DisplayDialog ("Advertencia", "Ya utilizaste tu pista!", "Ok");
		} else {
			if (Persistencia.sistema.actual.cantidadAyudas > 0) {
				if (GameObject.Find ("Opcion1").GetComponent<Actividad1_Logica> ().correcta == 1) {
					Destroy (GameObject.Find ("Opcion3"));
				} else if (GameObject.Find ("Opcion3").GetComponent<Actividad1_Logica> ().correcta == 1) {
					Destroy (GameObject.Find ("Opcion1"));
				} else {
					Destroy (GameObject.Find ("Opcion1"));
				}
				Persistencia.sistema.erroresActual++;
				ayudado = true;
			} else {
				EditorUtility.DisplayDialog ("Advertencia", "No tienes pistas disponibles!", "Ok");
			}
		}
	}
}
