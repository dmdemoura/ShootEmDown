using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuInicial : MonoBehaviour {
	public GameObject uiMenu;
	public GameObject uiInstructions;
	public GameObject uiCredits;
	public GameObject uiDificuldade;
	public void buttonStart(){
		for(int i=0;i<10;i++){
			for(int j=0;j<10;j++){
				PlayerPrefs.SetInt("arma"+i+"-"+j, 0);
			}
		}
		PlayerPrefs.SetInt("money",300);
		PlayerPrefs.SetInt("level",-1);
		SceneManager.LoadScene("ccena");
	}

	public void tutorial(){
		PlayerPrefs.SetInt("dificuldade",0);
		buttonStart();
	}
	public void hard(){
		PlayerPrefs.SetInt("dificuldade",1);
		buttonStart();
	}
	public void medio(){
		PlayerPrefs.SetInt("dificuldade",2);
		buttonStart();
	}
	public void easy(){
		PlayerPrefs.SetInt("dificuldade",3);
		buttonStart();
	}
	public void buttonInstruction(){
		uiMenu.SetActive(false);
		uiInstructions.SetActive(true);
	}
	public void buttonDificuldade(){
		uiMenu.SetActive(false);
		uiInstructions.SetActive(false);
		uiDificuldade.SetActive(true);
	}
	public void buttonVoltarMenu(){
		uiCredits.SetActive(false);
		uiMenu.SetActive(true);
		uiDificuldade.SetActive(false);
		uiInstructions.SetActive(false);
	}
	public void buttonCredits(){
		uiMenu.SetActive(false);
		uiCredits.SetActive(true);
	}

	void Start(){
		uiInstructions.SetActive(false);
	}
}
