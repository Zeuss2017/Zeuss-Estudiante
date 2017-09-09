using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEditor;

public class InterfazRegistro : MonoBehaviour {

    public Text nombre;
    public Text apodo;
    public Regex regNombre = new Regex(@"^[a-zA-Z_ \s]*$");
    public Regex regApodo = new Regex(@"^[a-zA-Z0-9 ]*$");
    public Dropdown dropdia;
    public Dropdown dropmes;
    public Dropdown dropano;
    List<string> listadia31 = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20",
                                                    "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
    List<string> listadia30 = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20",
                                                    "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" };
    List<string> listadia28 = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20",
                                                    "21", "22", "23", "24", "25", "26", "27", "28" };
    List<string> listames = new List<string> { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre",
                                                    "Noviembre", "Diciembre" };
    List<string> listaano = new List<string> { "2015", "2014", "2013", "2012", "2011", "2010", "2009", "2008", "2007", "2006", "2005", "2004", "2003", "2002"
                                                 , "2001", "2000", "1999", "1998", "1997", "1996", "1995", "1994", "1993", "1992", "1991", "1990" };


    // Use this for initialization
    void Start () {
        dropdia.ClearOptions();
        dropano.ClearOptions();
        dropmes.ClearOptions();


        dropdia.AddOptions(listadia31);
        dropmes.AddOptions(listames);
        dropano.AddOptions(listaano);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void actualizardia()
    {
        int valor = dropmes.value;
        string seleccionado = dropmes.options[valor].text;
        if (seleccionado.Equals("Abril") || seleccionado.Equals("Junio") || seleccionado.Equals("Septiembre") || seleccionado.Equals("Noviembre"))
        {
            int val = dropdia.value;
            if (val == 30)
            {
                val = 0;
            }
            dropdia.ClearOptions();
            dropdia.AddOptions(listadia30);
            dropdia.value = val;
        }
        if (seleccionado.Equals("Febrero") )
        {
            int val = dropdia.value;
            if (val > 27)
            {
                val = 0;
            }
            dropdia.ClearOptions();
            dropdia.AddOptions(listadia28);
            dropdia.value = val;
        }
        if (seleccionado.Equals("Enero") || seleccionado.Equals("Marzo") || seleccionado.Equals("Mayo") || seleccionado.Equals("Julio") || seleccionado.Equals("Agosto") || seleccionado.Equals("Octubre") || seleccionado.Equals("Diciembre"))
        {
            int val = dropdia.value;
            dropdia.ClearOptions();
            dropdia.AddOptions(listadia31);
            dropdia.value = val;
        }

    }

    public void Onclick()
    {
        int valor = dropdia.value;
        string seldia = dropdia.options[valor].text;
        valor = dropmes.value;
        string selmes = dropmes.options[valor].text;
        valor = dropano.value;
        string selano = dropano.options[valor].text;
		if (regNombre.IsMatch(nombre.text) && !nombre.text.Equals(""))
        {
			if (regApodo.IsMatch(apodo.text) && !apodo.text.Equals(""))
            {
                bool bandera = true;
                foreach(Estudiante e in Persistencia.sistema.estudiantes)
                {
                    if (e.usuario.Equals(apodo.text))
                    {
                        bandera = false;
                        break;
                    }
                }
                if(bandera == true)
                {
                    //Poner el estudiante en memoria mientras conecta colegio
                    Persistencia.sistema.actual = new Estudiante();
                    Persistencia.sistema.actual.nombre = nombre.text;
                    Persistencia.sistema.actual.usuario = apodo.text;
                    Persistencia.sistema.actual.idEstudiante = -1;
                    Persistencia.sistema.actual.nombreColegio = "";
                    Persistencia.sistema.actual.nombreCurso = "";
                    Persistencia.sistema.actual.fechaNacimiento = seldia + "-" + selmes + "-" + selano;                  
                    Application.LoadLevel("ConexionColegio");
                }
                else
                {
					//Quitar comentario
                    EditorUtility.DisplayDialog("Advertencia", "Este apodo ya existe en este dispositivo, escoge otro!", "Ok");
                }
                
            }
            else
            {
				//Quitar comentario
                EditorUtility.DisplayDialog("Advertencia", "Pon únicamente letras y números en tu apodo", "Ok");
            }
        }
        else
        {
			//Quitar comentario
            EditorUtility.DisplayDialog("Advertencia", "Pon únicamente letras en tu nombre", "Ok");
        }
    }

    public void Onclick2()
    {
        int valor = dropdia.value;
        string seldia = dropdia.options[valor].text;
        valor = dropmes.value;
        string selmes = dropmes.options[valor].text;
        valor = dropano.value;
        string selano = dropano.options[valor].text;
		if (regNombre.IsMatch(nombre.text) && !nombre.text.Equals(""))
        {
			if (regApodo.IsMatch(apodo.text) && !apodo.text.Equals(""))
            {
                bool bandera = true;
                foreach (Estudiante e in Persistencia.sistema.estudiantes)
                {
                    if (e.usuario.Equals(apodo.text))
                    {
                        bandera = false;
                        break;
                    }
                }
                if (bandera == true)
                {
                    //Poner el estudiante en memoria mientras conecta colegio
                    Persistencia.sistema.actual = new Estudiante();
                    Persistencia.sistema.actual.nombre = nombre.text;
                    Persistencia.sistema.actual.usuario = apodo.text;
                    Persistencia.sistema.actual.idEstudiante = -1;
                    Persistencia.sistema.actual.nombreColegio = "";
                    Persistencia.sistema.actual.nombreCurso = "";
                    Persistencia.sistema.actual.fechaNacimiento = seldia + "-" + selmes + "-" + selano;
                    Application.LoadLevel("Escenario");
                }
                else
                {
					//Quitar comentario
                    EditorUtility.DisplayDialog("Advertencia", "Este apodo ya existe en este dispositivo, escoge otro!", "Ok");
                }

            }
            else
            {
				//Quitar comentario
                EditorUtility.DisplayDialog("Advertencia", "Pon únicamente letras y números en tu apodo", "Ok");
            }
        }
        else
        {
			//Quitar comentario
            EditorUtility.DisplayDialog("Advertencia", "Pon únicamente letras en tu nombre", "Ok");
        }
    }
}
