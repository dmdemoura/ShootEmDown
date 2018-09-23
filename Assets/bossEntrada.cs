using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//carcaça do boss
public class bossEntrada : MonoBehaviour {

	private listaArmas lista;
	public slotArma[] slot;//slots das armas


	void Start () {
		PlayerPrefs.SetInt("arma0-0",2);
		PlayerPrefs.SetInt("arma0-1",2);
		PlayerPrefs.SetInt("arma0-2",2);
		PlayerPrefs.SetInt("arma0-3",2);
		PlayerPrefs.SetInt("arma0-4",2);
		PlayerPrefs.SetInt("arma0-5",2);
		PlayerPrefs.SetInt("arma0-6",2);
		PlayerPrefs.SetInt("arma0-7",2);

		lista = FindObjectOfType<listaArmas>();
		for(int i=0;i<slot.Length;i++){
			GameObject a =lista.l[PlayerPrefs.GetInt("arma0"+"-"+i)];
			slot[i].arma = Instantiate(a,slot[i].pos.transform).GetComponent<armaBase>();
			slot[i].arma.idNaFase = i;
			((MachineGun)slot[i].arma).cutcene = true;

		}

		GetComponent<Rigidbody2D>().velocity = new Vector2(0,-12f);//-8
		Invoke("parar", 4f);
	}

	void parar(){
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		for(int i=0;i<slot.Length;i++){
			((MachineGun)slot[i].arma).cutcene = false;
		}
		SceneManager.LoadScene("mmenu");
	}


}
