using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour {
        
    public string type;
    public int health = 10;
    public int armor = 0;
    public float offsetRay;
    public GameObject coin;

    public LayerMask playerLayerMask;

    private Rigidbody2D helmet;
    private RaycastHit2D hit;
    private ConstantForce2D force;

    public string state;

    private Rigidbody2D rb;


    private float snortTimer;
    private AudioSource[] aSources;
    private AudioSource pigSnort;
    private AudioSource pigSnortLong;

    private int attackingTimer = 0;

    private CapsuleCollider2D collider;


    public float[] speeds;
	// Use this for initialization
	void Start () {
        state = "searching-target";
        aSources = gameObject.GetComponents<AudioSource>();
        if (type == "worker" || type == "soldier") {
            helmet = gameObject.transform.GetChild(0).gameObject.GetComponent<Rigidbody2D>();
        }
        rb = gameObject.GetComponent<Rigidbody2D>();

        collider = GetComponent<CapsuleCollider2D>();
        force = GetComponent<ConstantForce2D>();

        pigSnort = aSources[0];
        pigSnortLong = aSources[1];

        snortTimer = 8f;
        if (type == "worker"){
            armor = 10;
        }

	}
	
	// Update is called once per frame
	void Update () {
        if (state == "searching-target"){
            force.force = new Vector2(speeds[0], 0);
        } else if (state == "running" ){
            force.force = new Vector2(speeds[1], 0);
        } else if (state == "attacking"){
            force.force = new Vector2(0f, 0f);
            if (attackingTimer == 0){
                rb.velocity = new Vector2(0f, 0f);
            }
            if (attackingTimer == 100){
                
                rb.AddForce(new Vector2(-460f, 420f));
            }
            if (attackingTimer > 200 && attackingTimer < 230){
                force.force = new Vector2(25f, 0f);
            }
            attackingTimer++;
            if (attackingTimer >= 300){
                attackingTimer = 0;
            }
            //Debug.Log(attackingTimer);

        }

        snortTimer -= 0.01f;
        if (snortTimer <= 0){
            pigSnort.Play();
            Debug.Log("oink");
            snortTimer = Random.RandomRange(3f, 7f);
        }

	}
    public void LoseHealth(int damage){
        
        if ( type == "worker" || type =="soldier"){
            armor -= damage;
            if (armor <= 0){
                helmet.bodyType = RigidbodyType2D.Dynamic;
                helmet.AddForce(new Vector2(400f, 400f));
                health -= damage;

            }
           
        } else {
            health -= damage;
        }
        if (health <= 0)
        {
            Drop(coin);
            Run();

        }

    }
    void Run(){
        Debug.Log("Pig running");
        gameObject.layer = 8;
        pigSnortLong.Play();
        gameObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
        state = "running";
    }
    void Drop(GameObject obj){
        Instantiate(obj, gameObject.transform.position, Quaternion.identity);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
 
	private void FixedUpdate()
	{
        if (health > 0){
            hit = Physics2D.Raycast(new Vector2(transform.position.x - offsetRay, transform.position.y), Vector2.left , 1.2f, playerLayerMask);
            Debug.DrawRay(new Vector2(transform.position.x - offsetRay, transform.position.y), Vector2.left * 1.2f, Color.red);
            Debug.Log(hit.collider); 
            if (hit.collider){
                if (hit.collider.name == "Player"){
                    state = "attacking";
                } 

            } else {
                state = "searching-target";
            }


        } 

	}

}
