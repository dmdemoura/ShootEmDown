using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//carcaça do boss
public class carcaca : MonoBehaviour {
	public int carcacaId;
	public float maxHp;
	private listaArmas lista;
	public slotArma[] slot;//slots das armas

	public Button buttonA;
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


	public void avancarW(){
		for(int i=0;i<slot.Length;i++){
			if(slot[i].arma.GetComponent<armaDash>() != null){
				slot[i].arma.GetComponent<armaDash>().avancarW();
				break;
			}
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