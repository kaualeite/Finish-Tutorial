﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTriger : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col) {
        //Debug.LogError(col.name);
        if (/*col.isTrigger != true && */col.CompareTag("Blue_Enemy")) {
            Destroy(col.gameObject);
        }
    }
}
