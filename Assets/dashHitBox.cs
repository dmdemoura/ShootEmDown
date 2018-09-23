using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashHitBox : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D co)
    {
        if(co.gameObject.tag == "Heroes"|| co.gameObject.tag == "HeroesBullet"){
            Health aux = co.gameObject.GetComponent<Health>();
            if(aux != null)
            {
                aux.HitPoints = 0;
            }
            else 
                Destroy(co.gameObject);
        }
    }
}
