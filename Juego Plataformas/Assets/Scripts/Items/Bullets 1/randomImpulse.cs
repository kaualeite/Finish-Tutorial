using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomImpulse : MonoBehaviour {

    private float vx = 0;
    private float vy = 0;
    private Rigidbody2D rb2d;
    // Use this for initialization
    void Start()
    {
        setRandomNum();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(new Vector2(vx, vy));
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setRandomNum(){
        var lucky = Random.Range(0, 5);
            
        

         vx = Random.Range(100, 201);
         vy = Random.Range(600, 701);
        if(lucky > 2){
            vx = vx * -1;
        }
    }
}
