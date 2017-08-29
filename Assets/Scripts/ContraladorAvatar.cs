using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContraladorAvatar : MonoBehaviour {

    // Use this for initialization

    private Animator animator;
    private Rigidbody2D m_Rigidbody2D;
    [SerializeField]private float m_MaxSpeed = 10f;
    [SerializeField]private float m_JumpForce = 400f;
    private bool derecha = false;
    private bool izquierda = false;
    private bool suelo;
    private int saltar = 0;
    void Start() {

        animator = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Rigidbody2D.freezeRotation = true;
        UpdateState("quietoDerecha");
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            derecha = true;
            izquierda = false;
            UpdateState("moverDerecha");
            m_Rigidbody2D.velocity = new Vector2(1f * m_MaxSpeed, m_Rigidbody2D.velocity.y);
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                derecha = false;
                izquierda = true;
                UpdateState("moverIzquierda");
                m_Rigidbody2D.velocity = new Vector2(-1 * m_MaxSpeed, m_Rigidbody2D.velocity.y);
            }
            else
            {
                if (derecha)
                {
                    m_Rigidbody2D.velocity = new Vector2(-0.1f, m_Rigidbody2D.velocity.y);
                    UpdateState("moverDerecha");
                    UpdateState("quietoDerecha");
                    derecha = false;
                }

                if (izquierda)
                {
                    m_Rigidbody2D.velocity = new Vector2(-0.1f, m_Rigidbody2D.velocity.y);
                    UpdateState("moverIzquierda");
                    UpdateState("quietoIzquierda");
                    izquierda = false;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            saltar = saltar + 1;
            if (saltar == 1)
            {
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
                UpdateState("saltar");
            }
        }
}

    void OnCollisionEnter2D()
    {
        UpdateState("quietoDerecha");
        saltar = 0;
     }


    public void UpdateState(string state = null)
    {
        if (state != null)
        {
            animator.Play(state);
        }
    }
}
