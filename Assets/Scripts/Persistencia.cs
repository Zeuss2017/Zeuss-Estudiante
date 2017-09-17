using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Persistencia {


    public static Sistema sistema = new Sistema();

    //it's static so we can call it from anywhere
    public static void Save()
    {
        Estudiante es = null;
        bool bandera = false;
        foreach(Estudiante e in Persistencia.sistema.estudiantes)
        {
            if(e.usuario.Equals(Persistencia.sistema.actual.usuario))
            {
                es = e;
                bandera = true;
            }
        }
        if(bandera == true)
        {
            Persistencia.sistema.estudiantes.Remove(es);
        }
		if (!Persistencia.sistema.actual.nombre.Equals ("-")) {
			Persistencia.sistema.estudiantes.Add (Persistencia.sistema.actual);
		}
        BinaryFormatter bf = new BinaryFormatter();
        //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
        //Debug.Log(Application.persistentDataPath);
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd"); //you can call it anything you want
        bf.Serialize(file, Persistencia.sistema);
        file.Close();
    }

    public static void Load()
    {
		if (File.Exists (Application.persistentDataPath + "/savedGames.gd")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
			Persistencia.sistema = (Sistema)bf.Deserialize (file);
			file.Close ();
		} else {
			Awake.cargarEjercicios ();
		}
    }

}
