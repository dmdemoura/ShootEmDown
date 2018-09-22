using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaSimples : MonoBehaviour {

	public float dano;
	public bool amigo;
	public float vel;
	public float tempoDeVida;
	void Start (){
        StartCoroutine(coroutine(tempoDeVida));
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(vel,0f);
    }
    public IEnumerator coroutine(float waitTime){
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
	 }
        
}
