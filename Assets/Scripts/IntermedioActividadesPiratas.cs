using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntermedioActividadesPiratas : MonoBehaviour {

	public Image actividad1;
    public Image actividad2;
    public Image actividad3;
    public Image alerta;
    public GameObject uiAlerta;
    public Sprite actividad2Bloqueada;
    public Sprite actividad3Bloqueada;
    public Sprite actividad1Normal;
    public Sprite actividad2Normal;
    public Sprite actividad3Normal;
    public Sprite alertaDesbloqueo;
    public Sprite alertaNuevaActividad;
    public static bool recienDesbloqueado;
    private bool actividad2B;
    private bool actividad3B;
	public AudioSource audioSource;
	public AudioClip sonidoDesbloquear;

    void Start () {
       


        uiAlerta.SetActive(false);
        actividad1.sprite = actividad1Normal;
        actividad2.sprite = actividad2Bloqueada;
        actividad3.sprite = actividad3Bloqueada;
        foreach (ActividadEstudiante e  in Persistencia.sistema.actual.actividadesEstudiante.ToArray())
        {
            if (e.idActividad == 1)
            {
                if (e.completado == 1)
                {
                    actividad2B = true;
                    actividad2.sprite = actividad2Normal;
                }
            }
            if (e.idActividad == 2)
            {
                if (e.completado == 1)
                {
                    actividad3B = true;
                    actividad3.sprite = actividad3Normal;
                }
            }
        }

	}
	
	
	void Update () {
        if (recienDesbloqueado)
        {
			audioSource.clip = sonidoDesbloquear;
			audioSource.volume = 1f;
			audioSource.Play();
			StartCoroutine (subirResultados());
            StartCoroutine(mostrarAlertas(2));
            recienDesbloqueado = false;
        }
    }

	public void click1(){
		Application.LoadLevel("GlobosPiratas");
	}

	public void click2(){
        if (actividad2B)
        {
            Application.LoadLevel("ActividadSaltoPiratas");
        }else {
            StartCoroutine(mostrarAlertas(1));
        }
		
	}

	public void click3(){
        if (actividad3B)
        {
            Application.LoadLevel("ShooterPiratas");
        }else
        {

            StartCoroutine(mostrarAlertas(1));
        }
		
	}
	public void clickTienda(){
		Application.LoadLevel("Tienda");
	}
	public void MenuActividades(){
		Application.LoadLevel("MenuActividades");
	}

    public static void desbloqueado()
    {
        recienDesbloqueado = true;
    }
    IEnumerator mostrarAlertas(int num)
    {
        switch (num)
        {
            case 1:
                alerta.sprite = alertaDesbloqueo;
                break;
            case 2:
                alerta.sprite = alertaNuevaActividad;
                break;
            
        }
        uiAlerta.SetActive(true);
        yield return new WaitForSeconds(4f);
        uiAlerta.SetActive(false);

    }



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
			yield return new WaitForSeconds (1f);

		} else {
		}
	}
}
