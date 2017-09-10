using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiendaController : MonoBehaviour {

    // Use this for initialization

    public GameObject avatar0;
    public GameObject avatar1;
    public GameObject avatar2;
    public GameObject avatar3;
    public GameObject avatar4;
    public Text monedas;
    public Text pistas;
    private int contadorAvatar;
    private int precioA1=20;
    private int precioA2=50;
    private int precioA3=80;
    private int precioA4=120;
    private int precioPista=20;
    private int monedasUsuario;
    public GameObject uiMensajeAlerta;
    public Image alerta;
    public Sprite alertaSinMonedas;
    public Sprite alertaCompraAvatar;
    public Sprite alertaCompraPista;
    public Sprite alertaSeleccionAvatar;
    

    void Start () {
        //monedasUsuario = int.Parse(monedas.GetComponent<Text>().text);
		monedas.GetComponent<Text>().text = Persistencia.sistema.actual.monedas.ToString();
        pistas.GetComponent<Text>().text = Persistencia.sistema.actual.cantidadAyudas.ToString();
        avatar1.SendMessage("AsignarPrecio", precioA1);
        avatar2.SendMessage("AsignarPrecio", precioA2);
        avatar3.SendMessage("AsignarPrecio", precioA3);
        avatar4.SendMessage("AsignarPrecio", precioA4);
        Persistencia.sistema.actual.avataresComprados.Add(0);
        Persistencia.sistema.actual.avatar = 0;
        Persistencia.Save();
        

        foreach (int i in Persistencia.sistema.actual.avataresComprados) {
            if (i == 0)
            {
                
                avatar0.SendMessage("AvatarComprado", true);

            }
            if (i == 1) {
				avatar1.SendMessage("AvatarComprado", true);
            }
            else
            {
                avatar1.SendMessage("AvatarComprado", false);

            }
            if (i == 2) {
				avatar2.SendMessage("AvatarComprado", true);
            }else
            {
                avatar2.SendMessage("AvatarComprado", false);
            }
            if (i == 3) {
				avatar3.SendMessage("AvatarComprado", true);
            }
            else
            {
                avatar3.SendMessage("AvatarComprado", false);

            }
            if (i == 4) {
				avatar4.SendMessage("AvatarComprado", true);
            }
            else
            {
                avatar4.SendMessage("AvatarComprado", false);

            }
        }
        avatar0.SetActive(true);
        avatar0.SendMessage("mostrarAvatar");
        avatar1.SetActive(false);
        avatar2.SetActive(false);
        avatar3.SetActive(false);
        avatar4.SetActive(false);
        uiMensajeAlerta.SetActive(false);
}

    // Update is called once per frame
    void Update () {
        
        switch (contadorAvatar)
        {
            case 0:
                avatar0.SetActive(true);
                avatar0.SendMessage("mostrarAvatar");
                avatar1.SetActive(false);
                avatar2.SetActive(false);
                avatar3.SetActive(false);
                avatar4.SetActive(false);

                break;
            case 1:
                avatar0.SetActive(false);
                avatar1.SetActive(true);
                avatar1.SendMessage("mostrarAvatar");
                avatar2.SetActive(false);
                avatar3.SetActive(false);
                avatar4.SetActive(false);
                
                break;
            case 2:
                avatar0.SetActive(false);
                avatar1.SetActive(false);
                avatar2.SetActive(true);
                avatar2.SendMessage("mostrarAvatar");
                avatar3.SetActive(false);
                avatar4.SetActive(false);
                break;
            case 3:
                avatar0.SetActive(false);
                avatar1.SetActive(false);
                avatar2.SetActive(false);
                avatar3.SetActive(true);
                avatar3.SendMessage("mostrarAvatar");
                avatar4.SetActive(false);
                break;
            case 4:
                avatar0.SetActive(false);
                avatar1.SetActive(false);
                avatar2.SetActive(false);
                avatar3.SetActive(false);
                avatar4.SetActive(true);
                avatar4.SendMessage("mostrarAvatar");
                break;
        }
		
	}
    IEnumerator mostrarAlerta( int mensaje)
    {
        switch (mensaje)
        {
            case 1:
                alerta.sprite = alertaSinMonedas;
                break;
            case 2:
                alerta.sprite = alertaCompraAvatar;
                break;
            case 3:
                alerta.sprite = alertaCompraPista;
                break;
            case 4:
                alerta.sprite = alertaSeleccionAvatar;
                break;

        }
        uiMensajeAlerta.SetActive(true);
        Time.timeScale = 0.0000001f;
        yield return new WaitForSeconds(1 * Time.timeScale);
        Time.timeScale = 1;
        uiMensajeAlerta.SetActive(false);

    }

    

    public void IncrementarContador()
    {
        if (contadorAvatar == 4)
        {
            contadorAvatar = 0;
        }
        else
        {
            contadorAvatar++;
        }
    }
    public void DecrementarContador()
    {
        if (contadorAvatar == 0)
        {
            contadorAvatar = 4;
        }
        else
        {
            contadorAvatar--;
        }
    }



    public void Volver()
    {
		if (Persistencia.sistema.actual.escenario.Equals ("COMIDA")) {
			Application.LoadLevel ("IntermediaComida");
		} else {
			Application.LoadLevel ("IntermediaPiratas");
		}
    }
    public void SeleccionarAvatar()
    {
        switch (contadorAvatar)
        {
            case 0:
                Persistencia.sistema.actual.avatar = 0;
                Persistencia.Save();
                StartCoroutine(mostrarAlerta(4));
                break;
            case 1:
                Persistencia.sistema.actual.avatar = 1;
                Persistencia.Save();
                StartCoroutine(mostrarAlerta(4));
                break;
            case 2:
                Persistencia.sistema.actual.avatar = 2;
                Persistencia.Save();
                StartCoroutine(mostrarAlerta(4));
                break;
            case 3:
                Persistencia.sistema.actual.avatar = 3;
                Persistencia.Save();
                StartCoroutine(mostrarAlerta(4));
                break;
            case 4:
                Persistencia.sistema.actual.avatar = 4;
                Persistencia.Save();
                StartCoroutine(mostrarAlerta(4));
                break;
        }
    }
    
    public void ComprarAvatar()
    {
        switch (contadorAvatar)
        {
            case 1:
				if (precioA1 <= Persistencia.sistema.actual.monedas)
                {
					Persistencia.sistema.actual.monedas -= precioA1;
					monedas.GetComponent<Text>().text = Persistencia.sistema.actual.monedas.ToString();
                    avatar1.SendMessage("AvatarComprado", true);
                    avatar1.SendMessage("mostrarAvatar");
					Persistencia.sistema.actual.avataresComprados.Add (1);
                    Persistencia.sistema.actual.avatar = 1;
					Persistencia.Save ();
                    StartCoroutine(mostrarAlerta(2));
                }
                else
                {
                    StartCoroutine(mostrarAlerta(1));
                }

                break;
            case 2:
				if (precioA2 <= Persistencia.sistema.actual.monedas)
                {
					Persistencia.sistema.actual.monedas -= precioA2;
					monedas.GetComponent<Text>().text = Persistencia.sistema.actual.monedas.ToString();
                    avatar2.SendMessage("AvatarComprado", true);
                    avatar2.SendMessage("mostrarAvatar");
					Persistencia.sistema.actual.avataresComprados.Add (2);
                    Persistencia.sistema.actual.avatar = 2;
                    Persistencia.Save ();
                    StartCoroutine(mostrarAlerta(2));
                }
                else
                {
                    StartCoroutine(mostrarAlerta(1));
                }
                break;
            case 3:
				if (precioA3 <= Persistencia.sistema.actual.monedas)
                {
					Persistencia.sistema.actual.monedas -= precioA3;
					monedas.GetComponent<Text>().text = Persistencia.sistema.actual.monedas.ToString();
                    avatar3.SendMessage("AvatarComprado", true);
                    avatar3.SendMessage("mostrarAvatar");
					Persistencia.sistema.actual.avataresComprados.Add (3);
                    Persistencia.sistema.actual.avatar = 3;
                    Persistencia.Save ();
                    StartCoroutine(mostrarAlerta(2));
                }
                else
                {
                    StartCoroutine(mostrarAlerta(1));
                }
                break;
            case 4:
				if (precioA4 <= Persistencia.sistema.actual.monedas)
                {
					Persistencia.sistema.actual.monedas -= precioA4;
					monedas.GetComponent<Text>().text = Persistencia.sistema.actual.monedas.ToString();
                    avatar4.SendMessage("AvatarComprado", true);
                    avatar4.SendMessage("mostrarAvatar");
					Persistencia.sistema.actual.avataresComprados.Add (4);
                    Persistencia.sistema.actual.avatar = 4;
                    Persistencia.Save ();
                    StartCoroutine(mostrarAlerta(2));
                }
                else
                {
                    StartCoroutine(mostrarAlerta(1));
                }
                break;
        }
    }  
    
    public void ComprarPista()
    {
		if (precioPista <= Persistencia.sistema.actual.monedas)
        {
			Persistencia.sistema.actual.monedas -= precioPista;
			monedas.GetComponent<Text>().text = Persistencia.sistema.actual.monedas.ToString();
			Persistencia.sistema.actual.cantidadAyudas++;
			Persistencia.Save ();
            StartCoroutine(mostrarAlerta(3));
        }
        else
        {
            StartCoroutine(mostrarAlerta(1));
        }
    }

}
