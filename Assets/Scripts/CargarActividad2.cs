using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CargarActividad2 : MonoBehaviour {

    
    public GameObject uiInstrucciones;
    public GameObject uiPausa;
    public GameObject uiGanar;
    public GameObject uiNuevoIntento;
    public enum GameState { Inicio, Ejecucion , Pausa};
    public static GameState gameState = GameState.Inicio;
    public int cantidadGlobos;
    public List<GameObject> listaGlobos=new List<GameObject>();
    public List<GameObject> copialistaGlobos = new List<GameObject>();
    public GameObject globo;
    private static bool gano = false;
    private static bool noGano = false;
    
   
  
    void Start () {
        uiPausa.SetActive(false);
        uiGanar.SetActive(false);
        uiNuevoIntento.SetActive(false);
        Persistencia.sistema.idActividadActual = 2;
		Persistencia.sistema.aciertosActual = 0;
		Persistencia.sistema.erroresActual = 0;
		gameState = GameState.Inicio;
        gano = false;
        noGano = false;
        Time.timeScale = 1;

    }

	void Update () {

        //Inicio de la Actividad
        //Si el estado es Idle, y da click se cambia de estado, se cargan los globos.
        if(gameState== GameState.Inicio && Input.GetMouseButtonDown(0))
        {
            Persistencia.sistema.tiempoActual = Time.time;
            gameState = GameState.Ejecucion;
            uiInstrucciones.SetActive(false);
			Ejercicio ej = Persistencia.sistema.obtenerEjercicio2 ();
			Persistencia.sistema.idEjercicioActual = ej.idEjercicio;
			for (int i = 0; i < ej.respuestas.Count; i++)
            {
                var position = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
                GameObject pl = Instantiate(globo,position,Quaternion.identity) as GameObject;
				pl.transform.Find("Texto").GetComponent<TextMesh> ().text = ej.respuestas.ElementAt (i).enunciado;
				pl.GetComponent<ControladorGlobo>().correcta = ej.respuestas.ElementAt (i).correcto;
                listaGlobos.Add(pl);
            }
            copialistaGlobos = listaGlobos;

            GameObject.Find ("Enunciado").GetComponent<TextMesh> ().text = ej.enunciado1;
        }

        //Si el estado es en Ejecución, y oprime la tecla "p" se cambia de estado a Pausa.
        if (gameState == GameState.Ejecucion && Input.GetKeyDown("p"))
        {
            uiPausa.SetActive(true);
            gameState = GameState.Pausa;
            Time.timeScale = 0;
            cambiarEstadoGlobos(true);
        }
        else
        // si el estado es Pausa, y oprime la tecla p se cambia al estado en Ejecución.
        if (gameState == GameState.Pausa && Input.GetKeyDown("p"))
        {
            gameState = GameState.Ejecucion;
            Time.timeScale = 1;
            uiPausa.SetActive(false);
            cambiarEstadoGlobos(false);
        }

        if (gano)
        {
            uiGanar.SetActive(true);
            cambiarEstadoGlobos(true);

            
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
        cambiarEstadoGlobos(true);
        yield return new WaitForSeconds(1*Time.timeScale);
        Time.timeScale = 1;
        uiNuevoIntento.SetActive(false);
        cambiarEstadoGlobos(false);
    }
    /*Nombre del Metodo: cambiarEstadoGlobos
      Entradas: booleano pausado
      Salidas: Void
      Descripcion: Envia a los globos un mensaje para que se puedan o no explotar al hacer click.
        
    */
    public void cambiarEstadoGlobos(bool pausado)
    {
        foreach (GameObject globo in listaGlobos)
        {
            if (globo != null)
            {
                globo.SendMessage("EnPausa", pausado);
            }
        }
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
        foreach (GameObject globo in listaGlobos)
        {
            if (globo != null)
            {
                globo.SendMessage("EnPausa", false);
            }
        }
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
        foreach (GameObject globo in listaGlobos)
        {
            if (globo != null)
            {
                globo.SendMessage("EnPausa", true);
            }
        }
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
      Descripcion: Metodo ejecutado por un globo para indicar si se reventó el globo indicado.
         
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
		bool disponible = false;
		if (Persistencia.sistema.actual.cantidadAyudas > 0) {
			foreach (GameObject gm in listaGlobos) {
				if (gm != null) {
					if (gm.GetComponent<ControladorGlobo> ().correcta != 1) {
						disponible = true;
						Persistencia.sistema.erroresActual++;
						Destroy (gm);
						break;
					}
				}
			}

		} else {
			//Quitar comentario
			EditorUtility.DisplayDialog ("Advertencia", "No tienes pistas disponibles!", "Ok");
		}

	}
   
}
