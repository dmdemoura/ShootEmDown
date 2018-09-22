using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navinhaMenu : MonoBehaviour {
	public GameObject menuUi;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
	}
	
	void OnCollisionEnter(Collision collision){
		Destroy(gameObject);
		menuUi.SetActive(true);
	}
}
