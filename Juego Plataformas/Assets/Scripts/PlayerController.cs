using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour{

    // Variables para la velocidad
    public float maxSpeed = 5f;
    public float speed = 2f;
    // Variable para detectar el suelo
    public bool grounded;
    // Variable para poner fuerza al saltar
    public float jumpPower = 6.5f;

	public int health;
	public int maxhealth = 100;


	public float Savepointx = 0;
	public float savepointy = 0;

	public float keyNumber = 0;

    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer spr;
    // Comprobacion de si salta o no
    private bool jump;
    // Salto doble
    private bool doubleJump;
    // Control de movimiento
    private bool movement = true;

    // Use this for initialization
    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
		health = maxhealth;
    }

    // Update is called once per frame
    void Update(){
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);

        // Salto de precaución
        if (grounded){
            doubleJump = true;
        }

        // Salto normal con flecha hacia arriba
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            // Si toca suelo
            if (grounded){
                jump = true;
                doubleJump = true;
                // Si doubleJump esta activados
            }else if (doubleJump){
                jump = true;
                // La ponemos a "false"
                doubleJump = false;
            }
        }
		if (health > maxhealth) {

			health = maxhealth;

		}

		if (health <= 0) {

			Die ();

		}
    }

    void FixedUpdate(){
        // Corrigiendo friccion, a friccion finita
        Vector3 fixedVelocity = rb2d.velocity;
        fixedVelocity.x *= 0.75f;

        if (grounded){
            rb2d.velocity = fixedVelocity;
        }
        // Movimiento
        float h = Input.GetAxis("Horizontal");

        rb2d.AddForce(Vector2.right * speed * h);

        // Si no hay movimiento quitamos la fuerza horizontal
        if (!movement) h = 0;

        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        // Cambio de posicion izquierda - derecha
        if (h > 0.1f){
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (h < -0.1f){
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        // Salto
        if (jump){
            // Quitamos la fuerza del salto
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            // Salto normal 
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }

        Debug.Log(rb2d.velocity.x);
    }

    void OnBecameInvisible(){
		transform.position = new Vector3(Savepointx, savepointy, 0);
    }

    // Salto al matar un enemigo
    public void EnemyJump() {
        jump = true;
    }

    // Deteccion de daño al colisionar con un enemigo
    public void EnemyKnockBack(float enemyPosX) {
        jump = true;

        float side = Mathf.Sign(enemyPosX - transform.position.x);

        // Salto hacia la izquierda al detectar una colision
        rb2d.AddForce(Vector2.left * side * jumpPower, ForceMode2D.Impulse);

        // Quitamos el movimiento
        movement = false;
        Invoke("EnableMovement", 1f);

        Hit();

        Invoke("Normal", 0.2f);
        
    }

    // Añadimos movimiento
    void EnableMovement() {
        movement = true;
    }

    void Normal() {
        UpdateState("Player_Idle");
    }
	void Hit(){
		health = health - 20;
		UpdateState("Player_Damage");

	}
    void Die() {
		transform.position = new Vector3(Savepointx, savepointy, 0);
		health = maxhealth;
    }

    // Cambio de Sprites
    public void UpdateState(string state = null) {
        anim.Play(state);
    }
}
