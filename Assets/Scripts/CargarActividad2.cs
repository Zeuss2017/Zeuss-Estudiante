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
    public GameObject uiSubirNivel;
    public GameObject uiNuevoIntento;
    public GameObject uiAyudaContenido;
    public GameObject uiSinPistas;
    public enum GameState { Inicio, Ejecucion , Pausa};
    public static GameState gameState = GameState.Inicio;
    public int cantidadGlobos;
    public List<GameObject> listaGlobos=new List<GameObject>();
    public List<GameObject> copialistaGlobos = new List<GameObject>();
    public GameObject globo;
    private static bool gano = false;
    private static bool noGano = false;
    private static bool subioNivel = false;
    private static bool reanudarActividad = false;
    public Text uiDinero;
    private static bool finalizo=false; 
	public AudioClip sonido;
	public AudioSource audioSource;   
	public AudioClip sonidoExplo;
	public static bool explota=false;
	public static bool sonar1 = false;
	public static bool sonar2 = false;
	public AudioClip sonidoAyuda1;
	public AudioClip sonidoAyuda2;
	public bool ponerSonido = false;
  
    void Start () {
        
		audioSource.loop = true;
		audioSource.clip = sonido;
		audioSource.volume = 0.51f;
		audioSource.Play();

        uiPausa.SetActive(false);
        uiGanar.SetActive(false);
        uiSinPistas.SetActive(false);
        uiNuevoIntento.SetActive(false);
        uiSubirNivel.SetActive(false);
        uiAyudaContenido.SetActive(false);
        Persistencia.sistema.idActividadActual = 1;
		Persistencia.sistema.aciertosActual = 0;
		Persistencia.sistema.erroresActual = 0;
		gameState = GameState.Inicio;
        gano = false;
        noGano = false;
        Time.timeScale = 1;
		uiDinero.text =  Persistencia.sistema.actual.monedas.ToString();
        ControladorAyudaContenido.actividadReanudar(2);
        if (!finalizo)
        {
            foreach (ActividadEstudiante e in Persistencia.sistema.actual.actividadesEstudiante.ToArray())
            {
                if (e.idActividad == 1)
                {
                    if (e.completado == 1)
                    {
                        if (Persistencia.sistema.actual.escenario.Equals("COMIDA"))
                        {
							finalizo = true;
                            Application.LoadLevel("IntermediaComida");
                            IntermedioActividades.desbloqueado();           
                        }
                        else
                        {
                            finalizo = true;
                            Application.LoadLevel("IntermediaPiratas");
                            IntermedioActividadesPiratas.desbloqueado();
                        }
                    }
                }

            }
        }
        
    }

	void Update () {
		if (explota) {
			audioSource.PlayOneShot (sonidoExplo, 1f);
			explota = false;
		}
		if (ponerSonido) {
			if (sonar1) {
				audioSource.Stop ();
				audioSource.clip = sonidoAyuda1;
				audioSource.volume = 1f;
				audioSource.Play ();
				sonar1 = false;
			}
			if (sonar2) {
				audioSource.Stop ();
				audioSource.clip = sonidoAyuda2;
				audioSource.volume = 1f;
				audioSource.Play ();
				sonar2 = false;
			}
		}
        //Inicio de la Actividad
        //Si el estado es Inicio, y da click se cambia de estado, se cargan los globos.
        if(gameState== GameState.Inicio && Input.GetMouseButtonDown(0))
        {
            Persistencia.sistema.tiempoActual = Time.time;
            gameState = GameState.Ejecucion;
            uiInstrucciones.SetActive(false);
			Ejercicio ej = Persistencia.sistema.obtenerEjercicio1();
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
			StartCoroutine(ayudaConcepto());
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
            if (subioNivel)
            {
                uiSubirNivel.SetActive(true);
                cambiarEstadoGlobos(true);
            }
            else
            {
                uiGanar.SetActive(true);
                cambiarEstadoGlobos(true);
            }
            

            
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
            cambiarEstadoGlobos(false);
            reanudarActividad = false;
            ponerSonido = false;
            audioSource.Stop();
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
    /*Nombre del Metodo: victoria
      Entradas: victoria
      Salidas: Void
      Descripcion: Metodo ejecutado por un globo para indicar si se reventó el globo indicado.
         
    */
    public static void victoria(bool victoria)
    {
		explota = true;
        if (victoria)
        {
            gano = true;
        }
        else
        {
            noGano = true;
        }
        
    }
    /*Nombre del Metodo: subirNivel
      Entradas: subirNivel
      Salidas: Void
      Descripcion: Metodo ejecutado por un globo para indicar si el usuario ha subido de nivel.
         
    */
    public static void subirNivel(bool subirNivel)
    {
        if (subirNivel)
        {
            subioNivel = true;
        }
        else
        {
            subioNivel = false;
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
			foreach (GameObject gm in listaGlobos) {
				if (gm != null) {
					if (gm.GetComponent<ControladorGlobo> ().correcta != 1) {
						disponible = true;
						Destroy (gm);
						break;
					}
				}
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
        reanudarActividad=true;

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
			if (tiempo > 19.11f && !gano){
                uiAyudaContenido.SetActive(true);
                Time.timeScale = 0;
                cambiarEstadoGlobos(true);
                yield break;
			}
			yield return new WaitForSeconds(1f);
		}
	}


	public void siguiente(){
		if (Persistencia.sistema.actual.escenario.Equals ("COMIDA")) {
			Application.LoadLevel ("GlobosComida");
		} else {
			Application.LoadLevel ("GlobosPiratas");
		}

	}


	public static void sonarAyudaV1(){
		sonar1 = true;
	}

	public static void sonarAyudaV2(){
		sonar2 = true;
	}
	public void activarSonido(){
		ponerSonido = true;
	}
   
}
