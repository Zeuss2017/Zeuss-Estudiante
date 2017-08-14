using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarTiendaControlador : MonoBehaviour {

    // Use this for initialization
    public GameObject imagenBn;
    public GameObject imagenColor;
    public Text valor;
    public GameObject botonComprar;
    private int precio;
    private bool comprado;
    

    void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AsignarPrecio(int p)
    {
        this.precio = p;
        this.valor.GetComponent<Text>().text = p.ToString();
    }

    public void mostrarAvatar()
    {
        if (comprado)
        {
            imagenBn.SetActive(false);
            imagenColor.SetActive(true);
            botonComprar.SetActive(false);
        }else
        {
            imagenBn.SetActive(true);
            imagenColor.SetActive(false);
        }
    }
    public void AvatarComprado(bool c)
    {
        comprado = c;
    }
    
    

}
