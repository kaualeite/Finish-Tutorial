using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mikuController : MonoBehaviour {
    public int mikuHealth;
    public int mikuMaxhealth = 5000;
    public bool atackt2 = false;
    public Text healthText;
    public int damage = 20;
    public PlayerController player;
	// Use this for initialization
	void Start () {
        player = (GameObject.Find("Player").GetComponent(typeof(PlayerController)) as PlayerController);

        mikuHealth = mikuMaxhealth;
	}
	
	// Update is called once per frame
	void Update () {

        healthText.text ="Miku: " +  mikuHealth.ToString() + "/" + mikuMaxhealth.ToString();
        if(mikuHealth == mikuMaxhealth/2){
            atackt2 = true;
        }
        if(mikuHealth == 0){
            Destroy(GameObject.Find(this.gameObject.name));
        }
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.EnemyKnockBack(200);
            player.Hit(damage);

        }

      
        if (col.gameObject.tag == "bomb")
        {
            mikuHealth = mikuHealth - 200;
        }
    }
}
