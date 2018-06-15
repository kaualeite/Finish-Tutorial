using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hyperRandomSpwner : MonoBehaviour {
    public GameObject[] theGoodies;
    public float timeToDestroy;
    private float firstTime;

    private GameObject Spawned;
    private Vector2 posSpawner;
    private int x;

	// Use this for initialization
	void Start () {
        firstTime = timeToDestroy;
	}
	
	// Update is called once per frame
	void Update () {
        setRandomNum();
        posSpawner = (GameObject.Find(this.gameObject.name)).transform.position;
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0)
        {
            Spawned = (GameObject)Instantiate(theGoodies[x], new Vector3(posSpawner.x, posSpawner.y, 0), transform.rotation);
            timeToDestroy = firstTime;

        }
	}
    public void setRandomNum()
    {
        var lucky = Random.Range(0, 5);
        x = lucky;



    }
}
