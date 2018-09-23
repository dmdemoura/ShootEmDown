using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {
	[SerializeField] private float bossSpeed;
	private dashHitBox hitBox;
	private Rigidbody2D myRigidbody2d;
	[HideInInspector]
	private bool indoF = false;
	
	void Start () {
		hitBox = FindObjectOfType<dashHitBox>();
		myRigidbody2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 v = Camera.main.WorldToViewportPoint(transform.position + Input.acceleration);


		v = Camera.main.WorldToViewportPoint(transform.position );
		if (v.y < 0f){
			indoF = true;
			myRigidbody2d.velocity = new Vector2(0,6);
		}
		else if(v.y > 0.8f && indoF == true){
			indoF = false;
			hitBox.gameObject.SetActive(false);
			myRigidbody2d.velocity = new Vector2(0,0);
		}
	}
}
