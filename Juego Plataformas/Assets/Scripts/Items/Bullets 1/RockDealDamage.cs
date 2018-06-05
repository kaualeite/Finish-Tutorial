using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDealDamage : MonoBehaviour {
    public int damage;
    public PlayerController player;
    void Start()
    {
        player = (GameObject.Find("Player").GetComponent(typeof(PlayerController)) as PlayerController);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.EnemyKnockBack(15);
            player.Hit(damage);
            Destroy(GameObject.Find(this.gameObject.name));

        }
    }
}
