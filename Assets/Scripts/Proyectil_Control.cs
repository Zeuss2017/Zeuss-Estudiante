using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Proyectil_Control : MonoBehaviour {

    private int pregunta;// desde donde se dispara el proyectil
  

    void OnCollisionEnter2D(Collision2D col)
    {
        //EditorUtility.DisplayDialog("asdasd", pregunta.ToString(), "OK");
        col.gameObject.SendMessage("validarPregunta", pregunta);
       	Destroy(this.gameObject);
        
    }
    void asignarPregunta(int pre)
    {
        this.pregunta = pre;
    }
    void destruirCanon(int destruir)
    {

    }
}
