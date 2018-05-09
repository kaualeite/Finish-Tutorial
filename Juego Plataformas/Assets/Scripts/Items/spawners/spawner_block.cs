using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_block : MonoBehaviour {
	public GameObject enemy;
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
			
			GameObject enemyspawn = (GameObject)Instantiate(enemy, new Vector3(positions.x,positions.y,0), transform.rotation);
			if (enemyspawn.tag != "Key") {
				GameObject enemyspawn2 = (GameObject)Instantiate (enemy, new Vector3 (positions.x + 1, positions.y, 0), transform.rotation);

				GameObject enemyspawn3 = (GameObject)Instantiate (enemy, new Vector3 (positions.x + 2, positions.y, 0), transform.rotation);
			} else {

				enemyspawn.isStatic = true;

			}
			Destroy (GameObject.Find (this.gameObject.name));
		}
	}
}
