using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class dropItemShop : MonoBehaviour, IDropHandler {
	private construindoNave boss;
	public int slotId;

	void Start(){
		boss = FindObjectOfType<construindoNave>();
	}
	public void OnDrop(PointerEventData eventData){

	}
}
