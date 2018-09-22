using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armaTiro : armaBase {

	public GameObject bala;

	public Transform[] pontoTiro;


	public override void atirarando (){
		for(int i=0;i< pontoTiro.Length;i++){
			Instantiate(bala,pontoTiro[i].position,pontoTiro[i].rotation);
		}
        base.atirarando();
    }

}
