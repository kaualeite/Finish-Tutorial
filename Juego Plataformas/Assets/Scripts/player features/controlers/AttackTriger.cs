﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTriger : MonoBehaviour {

    public int dmg = 20;

    void OnTriggerEnter2D(Collider2D col) {
        if(col.isTrigger != true && col.CompareTag("Bue_Enemy")) {
        }
    }
}