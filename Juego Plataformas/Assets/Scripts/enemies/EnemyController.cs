using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    // Variables para la velocidad
    public float maxSpeed = 1f;
    public float speed = 1f;

    public bool grounded;

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (grounded)
        {

        }

        // Movimiento
        rb2d.AddForce(Vector2.right * speed);

        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        // Movimiento hacia ambos lados
        if(rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f) {
            speed = -speed;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }

        // Cambio de posicion izquierda - derecha
        if (speed > 0) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }else {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
