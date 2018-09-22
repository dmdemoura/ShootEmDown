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
		RectTransform invPanel = transform as RectTransform;
		Debug.Log("euq");
		if(!RectTransformUtility.RectangleContainsScreenPoint(invPanel,Input.mousePosition)){
			Debug.Log("QUE");
			dragItemShop dropped = eventData.pointerDrag.GetComponent<dragItemShop>();
			boss.colocarArma(dropped.armaID,slotId,dropped.armaType);
		}
	}
}
