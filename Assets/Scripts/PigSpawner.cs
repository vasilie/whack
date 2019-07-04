using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigSpawner : MonoBehaviour {

	public GameObject pig;
    public GameObject pigWorker;
    public GameObject pigSoldier;
	public float initialSpawnTimer = 3;
    public int spawnWorker = 4;
    public int spawnSoldier = 7;
    public int maxSpawn = 1;
    private int spawnCount = 0;
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
        if (spawnCount < maxSpawn){
            spawnWorker--;
            spawnSoldier--;
            if (spawnWorker <= 0)
            {
                Instantiate(pigWorker, gameObject.transform.position, Quaternion.identity);
                spawnWorker = 4;
            }
            else
            {
                Instantiate(pig, gameObject.transform.position, Quaternion.identity);
            }
            if (spawnSoldier <= 0)
            {
                Instantiate(pigSoldier, gameObject.transform.position, Quaternion.identity);
                spawnSoldier = 7;
            }
            spawnCount++;
        }

	}
}
