using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class PlayerController : MonoBehaviour {

   
    public GameObject globo;
    public float speed;
    public float rebote;
	public int correcta=-1;
    public Rigidbody2D rb;
   // private Animator animator;
	// Use this for initialization
	void Start () {
        rb.GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        rb.AddForce(new Vector2(Random.Range(-0.3f,0.3f), Random.Range(-0.3f, 0.3f) ) * speed );
    }
    
    public void OnMouseDown()
    {
		if (this.correcta == 0) {
			this.gameObject.SetActive (false);
			Destroy (this.gameObject);
		} else if(this.correcta == 1){
			EditorUtility.DisplayDialog ("Actividad", "Escogiste la opción correcta", "Ok");
		}
    }

   /* public void UpdateState(string state=null)
    {
        if (state != null)
        {

            animator.Play(state);
        }
    }*/

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
            rb.AddForce(new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f)) , ForceMode2D.Impulse);
        }

    }

}
