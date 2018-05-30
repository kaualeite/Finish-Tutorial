using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugHealth : MonoBehaviour {

    public int health;
    private Animator anim;

    void Start () {
        anim = gameObject.GetComponent<Animator>();
    }

    public void die(int damage)
    {
        health = health - damage;

    }
}
