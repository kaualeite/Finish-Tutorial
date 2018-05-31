using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impulseRight : MonoBehaviour {

    public GameObject obj;
    public float vx = 0;
    public float vy = 0;
    private Rigidbody2D rb2d;
    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(new Vector2(vx, vy));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
