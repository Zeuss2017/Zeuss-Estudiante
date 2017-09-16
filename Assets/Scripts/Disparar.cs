using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour {

    public float velocidad;
    public GameObject proyectil;
    private bool disparar = false;
    private int pregunta;
	private GameObject vivo;
	public bool arriba = true;
	public bool pasazero = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (Input.mousePosition.y);
		if (Input.GetMouseButtonDown(0) && disparar && vivo == null && Input.mousePosition.y < Screen.height*0.8)
        {
			Actividad3_Logica.disp = true;
            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x,Input.mousePosition.y));
            Vector2 myPos = new Vector2(transform.position.x + 0.2f, transform.position.y);
            Vector2 direction = target - myPos;
            direction.Normalize();
            vivo = (GameObject)Instantiate(proyectil, myPos, Quaternion.identity);
			//
			float theta = transform.localEulerAngles.z;
			float newDirX = Mathf.Cos (theta * Mathf.Deg2Rad);
			float newDirY = Mathf.Sin (theta   * Mathf.Deg2Rad);
			float newDirY2 = Mathf.Sin ((theta + 20f)  * Mathf.Deg2Rad);
			vivo.transform.localEulerAngles = this.transform.localEulerAngles;
			vivo.GetComponent<Rigidbody2D>().velocity = new Vector2 (newDirX, newDirY2) * velocidad;
			//vivo.GetComponent<Rigidbody2D>().velocity = transform.localEulerAngles * velocidad;
			//vivo.GetComponent<Rigidbody2D>().AddForce(transform.localEulerAngles);
			vivo.SendMessage("asignarPregunta", pregunta);
        }


		if (disparar) {
			float angle = transform.localEulerAngles.z;
			angle = (angle > 180) ? angle - 360 : angle;

			if (angle > 30f) {
				arriba = false;
				Debug.Log ("Comienza a bajar");
			}

			if (angle < -65f) {
				arriba = true;
				Debug.Log ("Comienza a subir");
			}
			//Debug.Log (angle);

			if (arriba == true) {
				this.transform.Rotate (0, 0, 27 * Time.deltaTime);
			} else {
				this.transform.Rotate (0, 0, -27 * Time.deltaTime);
			}
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
