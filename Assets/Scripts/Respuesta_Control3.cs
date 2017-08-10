using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Respuesta_Control3 : MonoBehaviour {

    private int pregunta;

    public void asignarPregunta(int pre)
    {
        this.pregunta = pre;

    }
    public void validarPregunta(int pre)
    {
        
		if (this.pregunta == pre) {
			Destroy (this.gameObject);      
			Persistencia.sistema.aciertosActual++;
            Actividad3_Logica.DisparoExitoso(pre);
		} else {
			Persistencia.sistema.erroresActual++;
            Actividad3_Logica.DisparoExitoso(4);
            //EditorUtility.DisplayDialog ("Actividad", "Inténtalo de nuevo", "Ok");
		}
      
    }

	public int getPregunta(){
		return this.pregunta;
	}

    


}
