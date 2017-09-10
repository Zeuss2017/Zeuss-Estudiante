using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConectarColegio : MonoBehaviour {

    public Dropdown ciudad;
    public Dropdown colegio;
    public Dropdown curso;
	private string col;
	private string cur;

    // Use this for initialization
    void Start () {
        //llamar servicio web
        Debug.Log(Persistencia.sistema.actual.nombre);
        Debug.Log(Persistencia.sistema.actual.fechaNacimiento);
        ciudad.ClearOptions();
		ciudad.options.Add(new Dropdown.OptionData( "Escoge la ciudad" ) );
		ciudad.itemText.text = "Escoge";
		ciudad.value = -1;
		colegio.ClearOptions();
		curso.ClearOptions ();

        //ciudad.options.Add(new Dropdown.OptionData("Bogotá") );
        //ciudad.options.Add(new Dropdown.OptionData("Medellín"));
        //ciudad.options.Add(new Dropdown.OptionData("Cali"));
		StartCoroutine(cargarCiudades());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator cargarCiudades(){
		WWW w = new WWW("http://174.138.36.65:8080/Zeuss/webresources/colegio/ciudades" /*+ playerIPAddress*/);
		yield return w;

		yield return new WaitForSeconds(1f);

		procesarCiudades(w.text);
	}

    
	void procesarCiudades(string jsonResponse){
		//Debug.Log(jsonResponse);
		JSONObject jo = new JSONObject(jsonResponse);
		foreach(JSONObject j in jo.list){
			Debug.Log(j.list[0]);
			ciudad.options.Add(new Dropdown.OptionData( j.list[0].str ) );
		}
	}

	public void cambioCiudad(){
		int sel = ciudad.value;
		string seleccionado = ciudad.options [sel].text;
		if (seleccionado.Equals ("Escoge la ciudad")) {
			colegio.ClearOptions ();
			colegio.options.Add(new Dropdown.OptionData( "Escoge tu colegio" ) );
			colegio.value = -1;
		} else {
			StartCoroutine (cargarColegios (seleccionado));
		}
	}

	IEnumerator cargarColegios(string sel){
		WWW w = new WWW("http://174.138.36.65:8080/Zeuss/webresources/colegio/ciudades/" + sel);
		yield return w;

		yield return new WaitForSeconds(1f);

		procesarColegio(w.text);
	}

	void procesarColegio(string jsonResponse){
		col = jsonResponse;
		colegio.ClearOptions ();
		colegio.options.Add(new Dropdown.OptionData( "Escoge tu colegio" ) );
		colegio.value = -1;
		JSONObject jo = new JSONObject(jsonResponse);
		//recorre lista de colegios
		foreach(JSONObject j in jo.list){
			Debug.Log(j);
			//recorre lista de llaves
			for(int i = 0; i < j.list.Count; i++){
				string key = (string)j.keys[i];
				if (key.Equals ("nombre")) {
					colegio.options.Add(new Dropdown.OptionData( j.list[i].str ) );
				}
			}
		}
	}



	public void cambioColegio(){
		int sel = colegio.value;
		string seleccionado = colegio.options [sel].text;
		if (seleccionado.Equals ("Escoge tu colegio")) {
			curso.ClearOptions ();
			curso.options.Add(new Dropdown.OptionData( "Escoge tu curso" ) );
			curso.value = -1;
		} else {
			JSONObject jo = new JSONObject(this.col);
			//recorre lista de colegios
			foreach(JSONObject j in jo.list){
				//recorre lista de llaves
				float cod = -1;
				bool bandera = false;
				for(int i = 0; i < j.list.Count; i++){
					string key = (string)j.keys[i];
					//se encuentra el colegio escogido en el dropdown
					if (key.Equals ("nombre")) {
						if (j.list [i].str.Equals (seleccionado)) {
							bandera = true;
						}
					}
					//se guarda el códgio
					if (key.Equals ("id")) {
						cod = j.list [i].n;
					}
				}
				//Se llama la corrutina si es
				if (bandera == true) {
					Debug.Log ("Id del colegio:" + cod);
					StartCoroutine (cargarCursos (cod));
					return;
				}
			}

		}
	}


	IEnumerator cargarCursos(float sel){
		WWW w = new WWW("http://174.138.36.65:8080/Zeuss/webresources/colegio/cursos/" + sel);
		yield return w;

		yield return new WaitForSeconds(1f);

		procesarCurso(w.text);
	}

	void procesarCurso(string jsonResponse){
		cur= jsonResponse;
		curso.ClearOptions ();
		curso.options.Add(new Dropdown.OptionData( "Escoge tu curso" ) );
		curso.value = -1;
		JSONObject jo = new JSONObject(jsonResponse);
		//recorre lista de colegios
		foreach(JSONObject j in jo.list){
			Debug.Log(j);
			//recorre lista de llaves
			for(int i = 0; i < j.list.Count; i++){
				string key = (string)j.keys[i];
				if (key.Equals ("nombre")) {
					curso.options.Add(new Dropdown.OptionData( j.list[i].str ) );
				}
			}
		}
	}


	public void conectar(){
		int sel = ciudad.value;
		string seleccionado = ciudad.options [sel].text;
		int sel2 = colegio.value;
		string seleccionado2 = colegio.options [sel2].text;
		int sel3 = curso.value;
		string seleccionado3 = curso.options [sel3].text;
		if (!seleccionado.Equals ("Escoge la ciudad") && !seleccionado2.Equals ("Escoge tu colegio") && !seleccionado3.Equals ("Escoge tu curso")) {
			JSONObject jo = new JSONObject (this.cur);
			//recorre lista de colegios
			foreach (JSONObject j in jo.list) {
				//recorre lista de llaves
				float cod = -1;
				bool bandera = false;
				for (int i = 0; i < j.list.Count; i++) {
					string key = (string)j.keys [i];
					//se encuentra el colegio escogido en el dropdown
					if (key.Equals ("nombre")) {
						if (j.list [i].str.Equals (seleccionado3)) {
							bandera = true;
						}
					}
					//se guarda el códgio
					if (key.Equals ("id")) {
						cod = j.list [i].n;
					}
				}
				//Se llama la corrutina si es
				if (bandera == true) {
					Debug.Log ("Id del colegio:" + cod);
					StartCoroutine (registrarEstudiante (cod));
					return;
				}
			}
		} else {
			Debug.Log ("Faltan campos por llenar");
		}

	}

	IEnumerator registrarEstudiante(float sel){
		string[] lista = Persistencia.sistema.actual.nombre.Split (' ');
		int sele = (int) sel;
		string nombre = "";
		foreach (string s in lista) {
			nombre = nombre + s + "%20";
		}
		string[] lista2 = Persistencia.sistema.actual.usuario.Split (' ');
		string user = "";
		foreach (string s in lista2) {
			user = user + s + "%20";
		}
		string cad = "http://174.138.36.65:8080/Zeuss/webresources/estudiante/crear/" + nombre + "/" + user + "/" +
		             Persistencia.sistema.actual.fechaNacimiento + "/" + sele;
		Debug.Log (cad);
		WWW w = new WWW(cad);
		yield return w;

		yield return new WaitForSeconds(1f);

		procesarCrearEstudiante(w.text);
	}
		

	void procesarCrearEstudiante(string jsonResponse){
		if (jsonResponse != null && !jsonResponse.Equals ("")) {			
			Debug.Log (jsonResponse);
			Persistencia.sistema.actual.idEstudiante = int.Parse (jsonResponse);
			Persistencia.Save ();
			Debug.Log ("Exito en la creación");
			if (Persistencia.sistema.actual.escenario.Equals ("NO")) {
				Application.LoadLevel ("Escenario");
			} else {
				Application.LoadLevel ("MenuActividades");
			}
		}else{
			Debug.Log ("Error en la creación");
		}

	}

    public void menuPrincipal()
    {
        if (Persistencia.sistema.actual.escenario.Equals("NO"))
        {
            Application.LoadLevel("Escenario");
        }
        else
        {
            Application.LoadLevel("MenuActividades");
        }
    }

}
