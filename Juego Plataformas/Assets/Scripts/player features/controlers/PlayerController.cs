using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using  System.IO;

public class PlayerController : MonoBehaviour{
     Image image2;
     Image image;


    private bool charge = false;
    public float posx = 0;
    public float posy = 0;
    public Sprite nothing;
    public Sprite fuego;
    public Sprite hielo;
    public Sprite trueno;
    public Sprite velocidad;
    public Sprite jumpe;
    public Sprite inmune;
    public Text healthText;
    public Text keyText;
    public Text shieldText;
    public Text coinsText;
    // Variables para la velocidad
    public float maxSpeed = 5f;
    public float speed = 2f;
    // Variable para detectar el suelo
    public bool grounded;
    // Variable para poner fuerza al saltar
    public float jumpPower = 6.5f;
    // Variables para la vida
	public int health;
	public int maxhealth = 100;
    //variables para el escudo
    public int shield;
    public int maxshield = 200;

	public float porterx = 0;
	public float portery = 0;

    //status
    public bool changeStatus = false;
    public bool slowed = false;
    public bool burned = false;
    public bool lightned = false;

    //boosts
    public bool boosted = false;
    public bool jumper = false;
    public bool runner = false;
    public bool inmunity = false;



    public float Savepointx = 0;
	public float savepointy = 0;

    //items
	public float keyNumber = 0;
    public float coins = 0;

    public bool comproba = false;

    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer spr;
    // Comprobacion de si salta o no
    public bool jump;
    // Salto doble
    public bool doubleJump;
    // Control de movimiento
    private bool movement = true;

    // Use this for initialization
    void Start(){
        image = GameObject.Find("status").GetComponent<Image>();
        image2 = GameObject.Find("boost").GetComponent<Image>(); 
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
		health = maxhealth;

        charge = persistentManager.instance.cargar;
        if (charge == true)
        {
            read();
            Savepointx = posx;
            savepointy = posy;
            transform.position = new Vector3(posx, posy, 0);

            health = persistentManager.instance.life;
            maxhealth = persistentManager.instance.maaxlife;
            shield = persistentManager.instance.shield;
            maxshield = persistentManager.instance.maxshield;
            coins = persistentManager.instance.coins;
            keyNumber = persistentManager.instance.keys;

            healthText.text = persistentManager.instance.life.ToString() + "/" + persistentManager.instance.maaxlife.ToString();
            shieldText.text = persistentManager.instance.shield.ToString() + "/" + persistentManager.instance.maxshield.ToString();
            coinsText.text = persistentManager.instance.coins.ToString();
            keyText.text = persistentManager.instance.keys.ToString();
            persistentManager.instance.cargar = false;
            comproba = true;
        }
        else
        {
            comproba = false;
            healthText.text = health.ToString() + "/" + maxhealth.ToString();
            shieldText.text = shield.ToString() + "/" + maxshield.ToString();
            coinsText.text = coins.ToString();
            keyText.text = keyNumber.ToString();
        }
    }

    // Update is called once per frame
    void Update(){

        if (comproba == true)
        {
        
            healthText.text = health.ToString() + "/" + maxhealth.ToString();
            shieldText.text = shield.ToString() + "/" + maxshield.ToString();
            coinsText.text = coins.ToString();
            keyText.text = keyNumber.ToString();
        }
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);


        if(changeStatus == true){
            if(burned == true){

                image.sprite = fuego;


            }
            if(lightned == true){

                image.sprite = trueno;


            }
            if(slowed == true){
                
                image.sprite = hielo;
            }
        }else{
            image.sprite = nothing;
        }

        if (boosted == true)
        {
            if (runner == true)
            {

                image2.sprite = velocidad;


            }
            if (jumper == true)
            {

                image2.sprite = jumpe;


            }
            if (inmunity == true)
            {

                image2.sprite = inmune;
            }
        }
        else
        {
            image2.sprite = nothing;
        }

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
        if (shield > maxshield)
        {
            shield = maxshield;
        }
        if(shield < 0){
            shield = 0;
        }
		if (health <= 0) {
			Die ();
		}
    }

    void FixedUpdate(){
        // Corrigiendo friccion, a friccion finita
        if (lightned == false)
        {
            Vector3 fixedVelocity = rb2d.velocity;
            fixedVelocity.x *= 0.75f;

            if (grounded)
            {
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
            if (h > 0.1f)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }

            if (h < -0.1f)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }

            // Salto
            if (jump)
            {
                // Quitamos la fuerza del salto
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                // Salto normal 
                rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                jump = false;
            }
        }
        //Debug.Log(rb2d.velocity.x);
    }

    // Salto al matar un enemigo
    public void EnemyJump() {
        jump = true;
    }
    public void PlayerIsPushedByGreenPower(Vector2 vector, float push)
    {
        vector.Normalize();
        rb2d.AddForce(new Vector2(vector.x * push, vector.y * push));

    }

 
    // Deteccion de daño al colisionar con un enemigo
    public void EnemyKnockBack(float enemyPosX/*, int damage*/) {
        jump = true;

        float side = Mathf.Sign(enemyPosX - transform.position.x);

        // Salto hacia la izquierda al detectar una colision
        rb2d.AddForce(Vector2.left * side * jumpPower, ForceMode2D.Impulse);

        // Quitamos el movimiento
        movement = false;
        Invoke("EnableMovement", 1f);

        Invoke("Normal", 0.2f);
        
    }

    // Añadimos movimiento
    void EnableMovement() {
        movement = true;
    }

    // Distintos Estados
    void Normal() {
        UpdateState("Player_Idle");
    }
    public void Hit(int damage){
        if (inmunity == false)
        {
            if (shield <= 0)
            {
                health = health - damage;
                UpdateState("Player_Damage");
            }
            else
            {
                shield = shield - damage;
                if (shield < 0)
                {
                    health = health + shield;
                }
            }
        }
        inmunity = false;
        boosted = false;
	}
    void Die() {
		transform.position = new Vector3(Savepointx, savepointy, 0);
		health = maxhealth;
    }
	public void Playerusekeydoor() {
		transform.position = new Vector3(porterx, portery, 0);
		keyNumber = keyNumber - 1;
	}

    // Cambio de Animaciones
    public void UpdateState(string state = null) {
        anim.Play(state);
    }
    public void read()
    {
        StreamReader reader = new StreamReader("./Save.txt");
        string itemStrings = reader.ReadLine();
        char[] delimiter = { ';' };
        string[] fields = itemStrings.Split(delimiter);
        while (itemStrings != null)
        {


            for (int i = 0; i < fields.Length; i++)
            {

                Debug.Log(fields[i]);


            }

            itemStrings = reader.ReadLine();


        }
       
        posx = float.Parse(fields[1]);
        posy = float.Parse(fields[2]);
    }
}

