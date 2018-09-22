using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class construindoNave : MonoBehaviour {

	public modelo[] carcacas;

	void Start(){
		if(PlayerPrefs.GetInt("modeloAtual") < 0){
			PlayerPrefs.SetInt("modeloAtual",0);
		}

		int aux = 0;
		for(int i= 0;i<carcacas.Length;i++){
			//desativando todos os slots não da carcaça atual
			if(i!=PlayerPrefs.GetInt("modeloAtual"))
				carcacas[i].ui.SetActive(false);

			//procurando o index máximo das armas
			if(carcacas[i].tipoArma.Length > aux)
				aux = carcacas[i].tipoArma.Length;
		}

		//colocando valor inicial as armas caso precise
		for(int i=0;i<aux;i++){
			if(PlayerPrefs.GetInt("arma"+i) < 0)
				PlayerPrefs.SetInt("arma"+1, 0);
		}
	}

	//trocando carcaça
	public void trocarmodelo(int modeloId){
		carcacas[PlayerPrefs.GetInt("modeloAtual")].ui.SetActive(false);
		PlayerPrefs.SetInt("modeloAtual",modeloId);
		carcacas[PlayerPrefs.GetInt("modeloAtual")].ui.SetActive(true);
	}

	public void colocarArma(int armaId,int slotId, int tipoArma){//caso 0, retira arma
		Debug.Log("aaa");
		int modAtu = PlayerPrefs.GetInt("modeloAtual");
		if(carcacas[modAtu].tipoArma[slotId] == tipoArma){
			PlayerPrefs.SetInt("arma"+slotId, armaId);
		}
	}
	
	//entrar na batalha
	public void entrarBatalha(){
		int aux = PlayerPrefs.GetInt("modeloAtual");
		Debug.Log(aux);
		for(int i=0;i<carcacas[aux].tipoArma.Length;i++){
			Debug.Log(PlayerPrefs.GetInt("arma"+i));
		}

		SceneManager.LoadScene("ccena2");
	}

	public void entrarMenuInicial(){
		SceneManager.LoadScene("mmenu");	
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape))
			trocarmodelo((PlayerPrefs.GetInt("modeloAtual")+1) % 2);
		 if (Input.GetKeyDown("space"))
		 	entrarBatalha();
	}

}

[System.Serializable]
public class modelo {
    public int[] tipoArma;
	public GameObject ui;
}

