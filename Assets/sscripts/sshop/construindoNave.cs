using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class construindoNave : MonoBehaviour {
	public GameObject moneyText;
	public modelo[] carcacas;

	public void atualizarTextMoney(){
		moneyText.GetComponent<Text>().text = "Money: "+PlayerPrefs.GetInt("money");
	}
	void Start(){
		if(PlayerPrefs.GetInt("modeloAtual") < 0){
			PlayerPrefs.SetInt("modeloAtual",0);
		}

		atualizarTextMoney();

		for(int i= 0;i<carcacas.Length;i++){

			//procurando o index máximo das armas
			for(int j=0;j<carcacas[i].tipoArma.Length;j++){
				if(PlayerPrefs.GetInt("arma"+i+"-"+j) < 0){
					PlayerPrefs.SetInt("arma"+i+"-"+j,0);
					GameObject armaslot = GameObject.Find("armaSlot"+i+j);
					GameObject dragItem = GameObject.Find("dragItem0"+PlayerPrefs.GetInt("arma"+i+"-"+j));
armaslot.gameObject.GetComponent<Image>().sprite = dragItem.gameObject.GetComponent<Image>().sprite;
				}
				else{
					GameObject armaslot = GameObject.Find("armaSlot"+i+j);
					GameObject dragItem = GameObject.Find("dragItem0"+PlayerPrefs.GetInt("arma"+i+"-"+j));
					if(armaslot == null || dragItem == null)
						continue;
					armaslot.gameObject.GetComponent<Image>().sprite = dragItem.gameObject.GetComponent<Image>().sprite;
				}
			}
			//desativando todos os slots não da carcaça atual
			if(i!=PlayerPrefs.GetInt("modeloAtual"))
				carcacas[i].ui.SetActive(false);
		}


	}

	//trocando carcaça
	public void trocarmodelo(int modeloId){
		carcacas[PlayerPrefs.GetInt("modeloAtual")].ui.SetActive(false);
		PlayerPrefs.SetInt("modeloAtual",modeloId);
		carcacas[PlayerPrefs.GetInt("modeloAtual")].ui.SetActive(true);
		for(int i=0;i<6;i++){
			GameObject.Find("dragItem0"+i).GetComponent<dragItemShop>().atualizarDpIS();
		}
	}

	public void colocarArma(int armaId,int slotId, int tipoArma){//caso 0, retira arma
		//Debug.Log("aaa");
		int modAtu = PlayerPrefs.GetInt("modeloAtual");
		if(carcacas[modAtu].tipoArma[slotId] == tipoArma){
			PlayerPrefs.SetInt("arma"+PlayerPrefs.GetInt("modeloAtual")+"-"+slotId, armaId);
		}
	}
	
	//entrar na batalha
	public void entrarBatalha(){
		int aux = PlayerPrefs.GetInt("modeloAtual");
		Debug.Log(aux);
		for(int i=0;i<carcacas[aux].tipoArma.Length;i++){
			Debug.Log(PlayerPrefs.GetInt("arma"+i));
		}
		if(PlayerPrefs.GetInt("level")!= 3)
			PlayerPrefs.SetInt("level",PlayerPrefs.GetInt("level")+1);
		
		SceneManager.LoadScene("dmTest2");
	}

	public void entrarMenuInicial(){
		SceneManager.LoadScene("mmenu");	
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape))
			trocarmodelo((PlayerPrefs.GetInt("modeloAtual")+1) % 1);
		 if (Input.GetKeyDown("space"))
		 	entrarBatalha();
	}

}

[System.Serializable]
public class modelo {
    public int[] tipoArma;
	public GameObject ui;
}

