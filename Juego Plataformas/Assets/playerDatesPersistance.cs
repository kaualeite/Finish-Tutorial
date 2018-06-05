using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDatesPersistance : MonoBehaviour {

    public static persistentManager instance = null;
    public float life;
    public float shield;
    public float lastPosx;
    public float lasPosy;
    public float coins;
    public float keys;


    private void Awake()
    {
        if (instance == null) { 
          //  instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
