using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intemSkySpwner : MonoBehaviour {
    public GameObject spawner;
    private Vector2 posSpawner;
    public GameObject itemSpawned;
    public Transform target;
    public float timeToDestroy;
    private float firstTime;
    private GameObject Spawned;
    // velocidad de movimiento
    public float speed;

    private Vector3 start, end;

    // Use this for initialization
    void Start()
    {
        if (target != null)
        {
            target.parent = null;
            start = transform.position;
            end = target.position;
        }
        firstTime = timeToDestroy;

    }

    // Update is called once per frame
    void Update()
    {
        posSpawner = (GameObject.Find(this.gameObject.name)).transform.position;
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0)
        {
            Spawned = (GameObject)Instantiate(itemSpawned, new Vector3(posSpawner.x, posSpawner.y, 0), transform.rotation);
            timeToDestroy = firstTime;

        }
       
    }

    void FixedUpdate()
    {
        // movimiento
        if (target != null)
        {
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);
        }
        // correccion de movimiento
        if (transform.position == target.position)
        {
            // Operador ternario
            // cambia de valor la variable target dependiendo de donde este
            target.position = (target.position == start) ? end : start;
        }
    }
}
