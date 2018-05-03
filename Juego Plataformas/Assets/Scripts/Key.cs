using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
	public GameObject door;
	public Transform targets;
	// Use this for initialization
	public Vector3 start;
	public Vector3 end;
	public float positionx = 0;
	public float positiony = 0;
	void Start () {

		start = transform.position;
		end = targets.position;
		positionx = end.x;
		positiony = end.y;

	}
	// Update is called once per frame
	void Update () {

	}
}

