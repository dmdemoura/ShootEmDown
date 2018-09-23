using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armaBase : MonoBehaviour {
    [HideInInspector]
    public int idNaFase;
	public int type;
	public float cooldown;
	protected bool pdAtirar = true;
	

	public void atirar (){
		if(!pdAtirar)
			return;

        atirarando();
    }
 
 	public virtual void atirarando (){
        StartCoroutine(coroutine(cooldown));
    }
     public IEnumerator coroutine(float waitTime){
		pdAtirar = false;
        yield return new WaitForSeconds(waitTime);
        pdAtirar = true;
        
    }

}
