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

	private dropItemShop[] dpIS;
	public void OnDrag(PointerEventData data){
		trans.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData){
		
        trans.position = posInicial;
		

    }

	public void OnDrop(PointerEventData eventData){
		dragItemShop dropped = eventData.pointerDrag.GetComponent<dragItemShop>();
		for(int i=0;i<dpIS.Length;i++){
			if(!dpIS[i].isActiveAndEnabled)
				continue;
			
			RectTransform invPanel =dpIS[i].transform as RectTransform;
			if(RectTransformUtility.RectangleContainsScreenPoint(invPanel,Input.mousePosition)){
				Debug.Log(dropped.armaID);
				boss.colocarArma(dropped.armaID,dpIS[i].slotId,dropped.armaType);
			}
		}

	}

	void Start(){
		dpIS = FindObjectsOfType<dropItemShop>();
		trans = GetComponent<Transform>();
		posInicial = trans.position;
		boss = FindObjectOfType<construindoNave>();
	}
	// Update is called once per frame
	void Update () {
		
	}

}
