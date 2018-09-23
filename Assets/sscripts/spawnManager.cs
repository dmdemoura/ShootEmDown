using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnManager : MonoBehaviour {

	public int id;
	public int heroisVivos;
	public int heroisRestantes;
	public wave[] waves;
	public int minHerois;//numero minimo de herois 

	float proxWave = 0;
	private Transform trans;

	public void heroiMorreu(object sender, System.EventArgs e){
		heroisVivos--;
		PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money") +12 -(int)(PlayerPrefs.GetInt("dificuldade")*0.5));
		if(heroisRestantes <= 0 && heroisVivos <= 0){
			SceneManager.LoadScene("ccena");
	
		}
		if(heroisVivos <= minHerois){
			spawnWave(Random.Range(0,waves.Length-1));
			Debug.Log("heroiMorreu spawna nova wave");
		}
	}
	void spawnWave(int id){
		proxWave = waves[id].proxWave;
		Vector2 pos;
		for(int i=0;i<waves[id].quant && heroisRestantes > 0;i++){

			heroisRestantes--;
			heroisVivos++;
			pos = Camera.main.ViewportToWorldPoint(new Vector2(Random.Range(0f, 1f) , Random.Range(0f,0.2f)));
			GameObject heroi = Instantiate(waves[id].heroi,pos,trans.rotation);
			Health healthHeroi = heroi.GetComponent<Health>();
			healthHeroi.Death += heroiMorreu;
		}
	}
	void Start(){
		if(id != PlayerPrefs.GetInt("level"))
			gameObject.SetActive(false);
		heroisRestantes += (PlayerPrefs.GetInt("dificuldade")*3);
		//for(int i=0;i<waves.Length;i++){
		//	waves[i].proxWave -= (PlayerPrefs.GetInt("dificuldade")*1);
		//}

		trans = GetComponent<Transform>();
	}

	void Update(){
		proxWave -= Time.deltaTime;
		if(proxWave <= 0)
		{
			spawnWave(Random.Range(0,waves.Length-1));
			Debug.Log("Update spawna nova wave");
		}
	}
}



[System.Serializable]
public class wave{
   	public GameObject heroi;
	public int quant;
	public float proxWave;
}