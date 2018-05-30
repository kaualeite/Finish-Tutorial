using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugHealth : MonoBehaviour {

    //public GameObject bicho;
    private Animator anim;
    private bool dead;
    public int health;
    public int damage;

    void Start () {
        anim = gameObject.GetComponent<Animator>();
        //bicho = GameObject.Find("Bicho");
        dead = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerAtack"))
        {
            BugHit(damage);
        }
    }

    public void BugHit(int damage)
    {
        health = health - damage;
        if(health == 0)
        {
            dead = true;
            BugDie(dead);
        }
    }

    public void BugDie(bool dead)
    {
        anim.SetBool("Dead", dead);
        Invoke("BugDiiie", 0.7f);
    }

    public void BugDiiie()
    {
        Destroy(this.gameObject);
    }
}
