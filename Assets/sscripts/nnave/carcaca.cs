using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//carcaça do boss
public class carcaca : MonoBehaviour {
	public int carcacaId;
	public float maxHp;
	private listaArmas lista;
	public slotArma[] slot;//slots das armas
	void Start () {
		if(PlayerPrefs.GetInt("modeloAtual") != carcacaId)
			Destroy(gameObject);
		lista = FindObjectOfType<listaArmas>();
		for(int i=0;i<slot.Length;i++){
			GameObject a =lista.l[PlayerPrefs.GetInt("arma"+carcacaId+"-"+i)];
			slot[i].arma = Instantiate(a,slot[i].pos.transform).GetComponent<armaBase>();
		}
	}
	
	void Update(){
		if (Input.GetKeyDown("space"))
			for(int i=0;i<slot.Length;i++){
				if(slot[i].arma == null)
					Debug.Log("OQUE");
					Debug.Log("atirou");
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