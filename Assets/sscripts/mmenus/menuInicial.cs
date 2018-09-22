﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuInicial : MonoBehaviour {
	public GameObject uiMenu;
	public GameObject uiInstructions;
	public GameObject uiDificuldade;
	public void buttonStart(){
		for(int i=0;i<10;i++){
			PlayerPrefs.SetInt("arma"+i, 0);
		}
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
		uiMenu.SetActive(true);
		uiDificuldade.SetActive(false);
		uiInstructions.SetActive(false);
	}
	public void buttonExit(){
		Debug.Log("devia sair...");
		Application.Quit();
	}

	void Start(){
		uiInstructions.SetActive(false);
	}
}