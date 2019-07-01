using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Animator anim;
	AudioSource audioData;
	private bool hit;
	public float timerInit;
	private float timer;
	public AudioClip hitSound;
    private CapsuleCollider2D capsule;
	// Use this for initialization

	void Start () {
		anim = GetComponent<Animator>();
		audioData = GetComponent<AudioSource>();
		hit = false;
		timerInit = 10f;
		timer = timerInit;
        capsule = gameObject.GetComponent<CapsuleCollider2D>();
        capsule.enabled = false;
    }
    void HitFalse ()
    {
        hit = false;
        capsule.enabled = false;
    }
    void HitTrue()
    {
        hit = true;
        capsule.enabled = true;
    }
    void OnTriggerEnter2D (Collider2D other){
		
		
			other.attachedRigidbody.AddForce(new Vector2(1500f, 1400f));
            capsule.enabled = false;
            Debug.Log("Whack!");
			Debug.Log(other.attachedRigidbody);
			audioData.PlayOneShot(hitSound, 1f);
		

	
	}
	// Update is called once per frame
	void Update () {
		

		Debug.Log( hit);

		if (Input.GetKeyDown(KeyCode.Space)){
			
			anim.SetBool("space-pressed", true);
			anim.SetBool("space-released", false);
		}
		if (Input.GetKeyUp(KeyCode.Space)){
			anim.SetBool("space-pressed", false);
			anim.SetBool("space-released", true);
			audioData.Play(0);

		}
	}


}
