using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiendaController : MonoBehaviour {

    // Use this for initialization

    public GameObject avatar1;
    public GameObject avatar2;
    public GameObject avatar3;
    public GameObject avatar4;
    public Text monedas;
    private int contadorAvatar;
    private int precioA1=20;
    private int precioA2=50;
    private int precioA3=80;
    private int precioA4=120;
    private int precioPista=20;
    private int monedasUsuario;
    public GameObject uiMensajeAlerta;


    void Start () {
        monedasUsuario = int.Parse(monedas.GetComponent<Text>().text);
        avatar1.SendMessage("AsignarPrecio", precioA1);
        avatar2.SendMessage("AsignarPrecio", precioA2);
        avatar3.SendMessage("AsignarPrecio", precioA3);
        avatar4.SendMessage("AsignarPrecio", precioA4);
        avatar1.SetActive(true);
        avatar1.SendMessage("mostrarAvatar");
        contadorAvatar++;
        avatar2.SetActive(false);
        avatar3.SetActive(false);
        avatar4.SetActive(false);
        uiMensajeAlerta.SetActive(false);
}

    // Update is called once per frame
    void Update () {
        
        switch (contadorAvatar)
        {
            case 1:
                avatar1.SetActive(true);
                avatar1.SendMessage("mostrarAvatar");
                avatar2.SetActive(false);
                avatar3.SetActive(false);
                avatar4.SetActive(false);
                
                break;
            case 2:
                avatar1.SetActive(false);
                avatar2.SetActive(true);
                avatar2.SendMessage("mostrarAvatar");
                avatar3.SetActive(false);
                avatar4.SetActive(false);
                break;
            case 3:
                avatar1.SetActive(false);
                avatar2.SetActive(false);
                avatar3.SetActive(true);
                avatar3.SendMessage("mostrarAvatar");
                avatar4.SetActive(false);
                break;
            case 4:
                avatar1.SetActive(false);
                avatar2.SetActive(false);
                avatar3.SetActive(false);
                avatar4.SetActive(true);
                avatar4.SendMessage("mostrarAvatar");
                break;
        }
		
	}
    IEnumerator mostrarAlerta()
    {
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
            contadorAvatar = 1;
        }
        else
        {
            contadorAvatar++;
        }
    }
    public void DecrementarContador()
    {
        if (contadorAvatar == 1)
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

    }

    public void ComprarAvatar()
    {
        switch (contadorAvatar)
        {
            case 1:
                if (precioA1 <= monedasUsuario)
                {
                    monedasUsuario = monedasUsuario - precioA1;
                    monedas.GetComponent<Text>().text = monedasUsuario.ToString();
                    avatar1.SendMessage("AvatarComprado", true);
                    avatar1.SendMessage("mostrarAvatar");
                }
                else
                {
                    StartCoroutine(mostrarAlerta());
                }

                break;
            case 2:
                if (precioA2 <= monedasUsuario)
                {
                    monedasUsuario = monedasUsuario - precioA2;
                    monedas.GetComponent<Text>().text = monedasUsuario.ToString();
                    avatar2.SendMessage("AvatarComprado", true);
                    avatar2.SendMessage("mostrarAvatar");
                }
                else
                {
                    StartCoroutine(mostrarAlerta());
                }
                break;
            case 3:
                if (precioA3 <= monedasUsuario)
                {
                    monedasUsuario = monedasUsuario - precioA3;
                    monedas.GetComponent<Text>().text = monedasUsuario.ToString();
                    avatar3.SendMessage("AvatarComprado", true);
                    avatar3.SendMessage("mostrarAvatar");
                }
                else
                {
                    StartCoroutine(mostrarAlerta());
                }
                break;
            case 4:
                if (precioA4 <= monedasUsuario)
                {
                    monedasUsuario = monedasUsuario - precioA4;
                    monedas.GetComponent<Text>().text = monedasUsuario.ToString();
                    avatar4.SendMessage("AvatarComprado", true);
                    avatar4.SendMessage("mostrarAvatar");
                }
                else
                {
                    StartCoroutine(mostrarAlerta());
                }
                break;
        }
    }  
    
    public void ComprarPista()
    {
        if (precioPista <= monedasUsuario)
        {
            monedasUsuario = monedasUsuario - precioPista;
            monedas.GetComponent<Text>().text = monedasUsuario.ToString();
            
        }
        else
        {
            StartCoroutine(mostrarAlerta());
        }
    }

}
