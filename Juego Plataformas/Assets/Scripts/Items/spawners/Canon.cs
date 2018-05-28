using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour {
	public float positionspawnx;
    public float positionspawny;
    private Vector2 posCanon;
    public GameObject canon;
    public GameObject bullet;
    public float timeToDestroy;
    public float firstTime;
    private GameObject bulletSpawned;
    // Use this for initialization
    void Start () {
       
        posCanon = (GameObject.Find(this.gameObject.name)).transform.position;
        Debug.Log(posCanon);
        firstTime = timeToDestroy;
            }
	
	// Update is called once per frame
	void Update () {
        
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0)
        {
            bulletSpawned = (GameObject)Instantiate(bullet, new Vector3(posCanon.x + (positionspawnx) , posCanon.y + (positionspawny) , 0), transform.rotation);
            timeToDestroy = firstTime;

        }
    }
}
