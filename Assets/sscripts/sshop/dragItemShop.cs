using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class dragItemShop : MonoBehaviour, IDragHandler,IEndDragHandler, IDropHandler {

	public int armaID;
	public int armaType;
	Transform trans;
	Vector3 posInicial;
	private construindoNave boss;

	public void OnDrag(PointerEventData data){
		trans.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData){
        trans.position = posInicial;
    }

	public void OnDrop(PointerEventData eventData){
		GameObject dropped = eventData.pointerDrag;
		Debug.Log(dropped.GetComponent<dropItemShop>());
		RectTransform invPanel = transform as RectTransform;
		if(RectTransformUtility.RectangleContainsScreenPoint(invPanel,Input.mousePosition)){
			Debug.Log(dropped.name);
			//boss.colocarArma(dropped.armaID,slotId,dropped.armaType);
		}
	}

	void Start(){
		trans = GetComponent<Transform>();
		posInicial = trans.position;
		boss = FindObjectOfType<construindoNave>();
	}
	// Update is called once per frame
	void Update () {
		
	}

}
