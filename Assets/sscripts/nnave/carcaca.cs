using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//carcaça do boss
public class carcaca : MonoBehaviour {
	public float maxHp;
	private listaArmas lista;
	public slotArma[] slot;//slots das armas
	void Start () {
		lista = FindObjectOfType<listaArmas>();
		for(int i=0;i<slot.Length;i++){
			Debug.Log(PlayerPrefs.GetInt("arma"+i));
			GameObject a =lista.l[PlayerPrefs.GetInt("arma"+i)];
			Instantiate(a,slot[i].pos.transform);
			slot[i].arma = Instantiate(a,slot[i].pos.transform).GetComponent<armaBase>();
		}
	}
	
	void Update(){
		if (Input.GetKeyDown("space"))
			for(int i=0;i<slot.Length;i++){
				if(slot[i].arma == null)
					Debug.Log("OQUE");
				slot[i].arma.atirar();
		}
	}

}

[System.Serializable]
public class slotArma {
    public GameObject pos;//posição
	[HideInInspector]
	public armaBase arma = null;
	public int type;
}