using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeDestroy : MonoBehaviour {

    public float timeToDestroy = 2;
    private float firstTime = 2;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0)
        {

     
            Destroy(GameObject.Find(this.gameObject.name));

        }
    }
}
