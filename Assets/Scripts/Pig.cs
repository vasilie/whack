using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour {

    public string type;
    public int health = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void LoseHealth(int damage){
        health -= damage;
        if (health < 0 ) {
            Die();
        }
    }
    void Die(){
        Debug.Log("Pig died");
    }

}
