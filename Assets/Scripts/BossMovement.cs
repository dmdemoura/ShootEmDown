using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {
	[SerializeField] private float bossSpeed;
	private Rigidbody2D myRigidbody2d;
	void Start () {
		myRigidbody2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 v = Camera.main.WorldToViewportPoint(transform.position + Input.acceleration);
		if (v.x > 0f && v.x < 1f)
			myRigidbody2d.velocity = new Vector2(Input.acceleration.x * bossSpeed, 0f);	
		else
			myRigidbody2d.velocity = new Vector2(0f, 0f);	
	}
}
