using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armaDash : armaBase {
	private dashHitBox hitBox;
	private GameObject bsMv;

	public void avancarW(){
		if(!pdAtirar)
			return;
		BossMovement aux = bsMv.GetComponent<BossMovement>();

		bsMv.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-12);
		hitBox.gameObject.SetActive(true);
		StartCoroutine(coroutine(cooldown));
	}

	public override void atirarando (){}//retirando cooldown de só atirar(nao utilizado em dash)
	void Start(){
		hitBox = FindObjectOfType<dashHitBox>();
		bsMv = FindObjectOfType<BossMovement>().gameObject;
	}
}
