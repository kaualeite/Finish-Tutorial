using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
	public Transform target;
	// Use this for initialization
	public Vector3 start, end;
	public float positionx = 0;
	public float positiony = 0;
	void Start () {
		target.parent = null;
		start = transform.position;
		end = target.position;
		positionx = end.x;
		positiony = end.y;
	}

	// Update is called once per frame
	void Update () {

	}
}

