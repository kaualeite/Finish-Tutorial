using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_block : MonoBehaviour {
	public GameObject enemy;
    public int NumEnemies = 1;
    private GameObject enemyspawn;
  
	public GameObject block;
	public Vector3 spawnSpot = new Vector3(0,5,0);
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
       
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		var positions = (GameObject.Find (this.gameObject.name)).transform.position;

        if (other.gameObject.tag == "Player")
        {
            var cont = 1;
            for (int i = 0; i < NumEnemies; i++) {
                 enemyspawn = (GameObject)Instantiate(enemy, new Vector3(positions.x  , positions.y , 0), transform.rotation);
                cont = cont + 1;  
            }
        }
			Destroy (GameObject.Find (this.gameObject.name));
		}
	}

