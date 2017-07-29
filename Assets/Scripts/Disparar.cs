using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour {

    public float velocidad;
    public GameObject proyectil;
    private bool disparar = false;
    private int pregunta;
	private GameObject vivo;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * velocidad;

        transform.Translate(h, v, 0);

		if (Input.GetMouseButtonDown(0) && disparar && vivo == null)
        {
            
            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x,Input.mousePosition.y));
            Vector2 myPos = new Vector2(transform.position.x+0.6f, transform.position.y+0.3f);
            Vector2 direction = target - myPos;
            direction.Normalize();
            vivo = (GameObject)Instantiate(proyectil, myPos, Quaternion.identity);
			vivo.GetComponent<Rigidbody2D>().velocity = direction * velocidad;
			vivo.SendMessage("asignarPregunta", pregunta);
        }
    }

    void activarDisparo(int pre)
    {
        disparar = true;
        this.pregunta = pre;
    }
    void desactivarDisparo()
    {
        disparar = false;
    }

}
