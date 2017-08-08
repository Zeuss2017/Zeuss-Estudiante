using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pregunta_Control3 : MonoBehaviour {

    public GameObject cañon;
    private int id;
    private int respuesta;
	void activarDisparo()
    {
        cañon.SendMessage("activarDisparo",id);
    }

    void desactivarDisparo()
    {
        cañon.SendMessage("desactivarDisparo");
    }

    void asignarId(int id)
    {
        this.id = id;
    }

    public int getId()
    {
        return this.id;
    }

		

    
}
