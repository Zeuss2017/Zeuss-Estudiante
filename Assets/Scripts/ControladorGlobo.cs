using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControladorGlobo : MonoBehaviour {

   
    public GameObject globo;
    public float speed;
    public float rebote;
	public int correcta=-1;
    public Rigidbody2D rb;
    private bool enPausa = false;
    

    // Use this for initialization
    void Start () {
        rb.GetComponent<Rigidbody2D>();
       
    }
	
	// Update is called once per frame
	void Update () {
        rb.AddForce(new Vector2(Random.Range(-0.3f,0.3f), Random.Range(-0.3f, 0.3f) ) * speed );
    }

    public void OnMouseDown()
    {
        if (!enPausa)
        {
            if (this.correcta == 0)
            {
                this.gameObject.SetActive(false);
                Persistencia.sistema.erroresActual++;
                Destroy(this.gameObject);
                CargarActividad2.victoria(false);
            }
            else if (this.correcta == 1)
            {
                Persistencia.sistema.aciertosActual++;
                Persistencia.sistema.tiempoActual = Time.time - Persistencia.sistema.tiempoActual;
                int diferencia = Persistencia.sistema.guardarEjercicio();
                Destroy(this.gameObject);
                CargarActividad2.victoria(true);
				if (diferencia > 0) {
					Debug.Log ("Mostrar mensaje de felicitaciones");
				} else {
					Debug.Log ("Mostrar mensaje de siguiente nivel");
				}
            }
        }
    }
    public void EnPausa(bool pausado)
    {
        this.enPausa = pausado;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Arriba")
        {
            rb.AddForce(new Vector2(0.1f, -0.3f) * rebote, ForceMode2D.Impulse);
        }
        else if(coll.gameObject.tag == "Derecha")
        {
            rb.AddForce(new Vector2(-0.3f, 0.1f) * rebote, ForceMode2D.Impulse);
        }
        else if (coll.gameObject.tag == "Izquierda")
        {
            rb.AddForce(new Vector2(0.3f, 0.1f) * rebote, ForceMode2D.Impulse);
        }
        else if (coll.gameObject.tag == "Abajo")
        {
            rb.AddForce(new Vector2(0.1f, 0.3f) * rebote, ForceMode2D.Impulse);
        }
        else if (coll.gameObject.tag == "Globo")
        {
            rb.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) , ForceMode2D.Impulse);
        }

    }

}
