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
			//EditorUtility.DisplayDialog("asdasd", this.pregunta.ToString() + "vs" + pre.ToString(), "OK");
			Destroy (this.gameObject);      
		} else {
			EditorUtility.DisplayDialog ("Actividad", "Inténtalo de nuevo", "Ok");
		}
      
    }

    


}
