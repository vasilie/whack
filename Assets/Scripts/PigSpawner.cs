using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigSpawner : MonoBehaviour {

	public GameObject pig;
	public float initialSpawnTimer = 3;
	private float spawnTimer;
	// Use this for initialization
	void Start () {
		spawnTimer = initialSpawnTimer;
	}
	
	// Update is called once per frame
	void Update () {
		spawnTimer-= Time.deltaTime;
		if (spawnTimer <= 0) {
			spawnTimer = initialSpawnTimer;
			spawnEnemy();
		}
	}

	void spawnEnemy(){
		Instantiate(pig, gameObject.transform.position, Quaternion.identity);
	}
}
