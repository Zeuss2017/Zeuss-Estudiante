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
        yield return new WaitForSeconds(1.5f);
        uiAlerta.SetActive(false);

    }
}
