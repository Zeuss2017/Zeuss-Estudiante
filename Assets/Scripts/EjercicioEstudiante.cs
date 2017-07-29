using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EjercicioEstudiante  {

    public int aciertos;
    public int errores;
    public int tiempo;

    public EjercicioEstudiante(int aciertos, int errores, int tiempo)
    {
        this.aciertos = aciertos;
        this.errores = errores;
        this.tiempo = tiempo;
    }
}
