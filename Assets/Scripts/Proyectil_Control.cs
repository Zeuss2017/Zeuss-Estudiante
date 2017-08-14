using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil_Control : MonoBehaviour {

    private int pregunta;// desde donde se dispara el proyectil
  
    void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.SendMessage("validarPregunta", pregunta);
       	Destroy(this.gameObject);
        
    }
    void asignarPregunta(int pre)
    {
        this.pregunta = pre;
    }
   
}
