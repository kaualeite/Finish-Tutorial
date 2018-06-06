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
    private float firstTime;
    private GameObject bulletSpawned;
    private Rigidbody2D rb2d;
    // Use this for initialization
    void Start () {
       
        rb2d = GetComponent<Rigidbody2D>();
        firstTime = timeToDestroy;
            }
	
	// Update is called once per frame
	void Update () {
        posCanon = (GameObject.Find(this.gameObject.name)).transform.position;
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0)
        {
            bulletSpawned = (GameObject)Instantiate(bullet, new Vector3(posCanon.x + (positionspawnx) , posCanon.y + (positionspawny) , 0), transform.rotation);
            timeToDestroy = firstTime;

        }
    }

        

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Plataform")
            {
                
                (GameObject.Find(this.gameObject.name)).transform.parent = col.transform;
                
            }


        }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Plataform")
        {
            
            (GameObject.Find(this.gameObject.name)).transform.parent = col.transform;

        }

    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Plataform")
        {

            (GameObject.Find(this.gameObject.name)).transform.parent = col.transform;

        }

    }

}
