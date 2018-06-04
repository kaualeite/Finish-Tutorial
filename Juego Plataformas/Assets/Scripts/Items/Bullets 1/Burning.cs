using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burning : MonoBehaviour {

    public PlayerController player;
    public float timeToDestroy = 5;
    private float firstTime = 5;
    private int contburnt = 5;
    private float timeToBurn = 1;
    private int damage = 2;
  
    // Use this for initialization
    void Start()
    {
        player = (GameObject.Find("Player").GetComponent(typeof(PlayerController)) as PlayerController);
        timeToBurn = timeToDestroy;
    
        player.changeStatus = true;
        player.burned = true;
    }

    // Update is called once per frame
    void Update()
    {
        timeToBurn -= Time.deltaTime;
        timeToDestroy -= Time.deltaTime;
        if (contburnt != 0)
        {
            if (timeToBurn <= 0)
            {
                
                player.Hit(damage);
                timeToBurn = 1;
                contburnt = contburnt - 1;
            }
        }

        if (timeToDestroy <= 0)
        {
            player.changeStatus = false;
            player.burned = false;
            timeToDestroy = firstTime;
            //Destroy(this);
            if(contburnt == 0){
                Destroy(this);
            }
        }
      
    }
}
