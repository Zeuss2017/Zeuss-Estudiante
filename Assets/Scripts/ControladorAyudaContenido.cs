using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorAyudaContenido : MonoBehaviour {

    public GameObject avatarDialogo;
    public GameObject concepto1;
    public GameObject concepto2;
    public GameObject concepto3;
    public GameObject botonAtras;
    public GameObject botonAdelante;
    public GameObject botonReanudar;
    public Image avatar;
    public Sprite avatarPrincipal;
    public Sprite avatarChef;
    public Sprite avatarIngeniero;
    public Sprite avatarMecanico;
    public Sprite avatarVeterinario;
    private int contador;
    private int numeroAvatar;
    private static int actividad;

	void Start () {
        numeroAvatar=int.Parse(Persistencia.sistema.actual.avatar.ToString());
        inicializarAvatar(numeroAvatar);
        avatarDialogo.SetActive(true);
        concepto1.SetActive(false);
        concepto2.SetActive(false);
        concepto3.SetActive(false);
        botonAtras.SetActive(false);
        botonAdelante.SetActive(true);
        botonReanudar.SetActive(false);
        contador = 0;
    }
	

    /*Nombre del Metodo: siguienteConcepto
    Entradas: ninguna
    Salidas: Void
    Descripcion: Cambia al siguiente concepto.

    */
    private void inicializarAvatar(int numeroAvatar)
    {
        switch (numeroAvatar)
        {
            case 0:
                avatar.sprite = avatarPrincipal;
                break;
            case 1:
                avatar.sprite = avatarChef;
                break;
            case 2:
                avatar.sprite = avatarIngeniero;
                break;
            case 3:
                avatar.sprite = avatarMecanico;
                break;
            case 4:
                avatar.sprite = avatarVeterinario;
                break;
        }
    }
    /*Nombre del Metodo: siguienteConcepto
      Entradas: ninguna
      Salidas: Void
      Descripcion: Cambia al siguiente concepto.

    */
    public void siguienteConcepto()
    {
        contador = contador + 1;
        switch (contador)
        {
            case 1:
                avatarDialogo.SetActive(false);
                concepto1.SetActive(true);
                concepto2.SetActive(false);
                concepto3.SetActive(false);
                botonAtras.SetActive(true);
                break;
            case 2:
                avatarDialogo.SetActive(false);
                concepto1.SetActive(false);
                concepto2.SetActive(true);
                concepto3.SetActive(false);
                break;
            case 3:
                avatarDialogo.SetActive(false);
                concepto1.SetActive(false);
                concepto2.SetActive(false);
                concepto3.SetActive(true);
                botonReanudar.SetActive(true);
                botonAdelante.SetActive(false);
                break;
            
        }
    }
    /*Nombre del Metodo: conceptoAnterior
      Entradas: ninguna
      Salidas: Void
      Descripcion: Cambia a un concepto anterior.
         
    */
    public void conceptoAnterior()
    {
        contador = contador - 1;
        switch (contador)
        {
            case 0:
                avatarDialogo.SetActive(true);
                concepto1.SetActive(false);
                concepto2.SetActive(false);
                concepto3.SetActive(false);
                botonAtras.SetActive(false);
                break;

            case 1:
                avatarDialogo.SetActive(false);
                concepto1.SetActive(true);
                concepto2.SetActive(false);
                concepto3.SetActive(false);
                botonAtras.SetActive(true);
                break;
            case 2:
                avatarDialogo.SetActive(false);
                concepto1.SetActive(false);
                concepto2.SetActive(true);
                concepto3.SetActive(false);
                botonAdelante.SetActive(true);
                botonReanudar.SetActive(false);
                break;
            
        }
    }
    /*Nombre del Metodo: reanudarActividad
    Entradas: ninguna
    Salidas: Void
    Descripcion: reanuda la actividad.

    */
    public void reanudarActividad()
    {
        switch (actividad)
        {
            case 1:
                CargarActividad1.reanudarActividadContenido();
                break;
            case 2:
                CargarActividad2.reanudarActividadContenido();
                break;
            case 3:
                Actividad3_Logica.reanudarActividadContenido();
                break;
        }
        
    }

    /*Nombre del Metodo: actividadReanudar
    Entradas: entero que indica que actividad se debe reanudar
    Salidas: Void
    Descripcion: recibe el entero con la actividad que se va areanudar.

    */
    public static void actividadReanudar(int act)
    {
        actividad = act;
    }
}
