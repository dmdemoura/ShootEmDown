﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : armaBase {

	[SerializeField] GameObject bullet;
	[SerializeField]float shootingSpeed, bulletSpeed;
	Transform target;

	[HideInInspector]
	public bool cutcene = false;

	private float cutceneCooldown = 5;

	private void Update()
	{
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
     	Vector3 dir = Input.mousePosition - pos;
     	float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
     	transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 

		cutceneCooldown -= Time.deltaTime;
		if((pdAtirar && Input.GetMouseButton(0)) || (cutcene && cutceneCooldown < 0))
		{
			cutceneCooldown = 1f;
			// Debug.Log("Getting ready...");
			atirar();
		}
	}

	public override void atirarando()
	{
		pdAtirar = false;
		InvokeRepeating("MachineGunShot", 0, shootingSpeed);
	}

	void MachineGunShot()
	{
		// Debug.Log("Take this!");

		GameObject currentBullet = Instantiate(bullet, this.transform.position, Quaternion.Euler(0f,0f,-90f)  * this.transform.rotation);
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		currentBullet.GetComponent<Rigidbody2D>().velocity = (mousePos - (Vector2)this.transform.position).normalized * bulletSpeed;

		if(!Input.GetMouseButton(0))
		{
			pdAtirar = true;
			// Debug.Log("Gone.");
			CancelInvoke();
		}
	}

}