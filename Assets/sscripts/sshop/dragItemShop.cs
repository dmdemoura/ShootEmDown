using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class dragItemShop : MonoBehaviour, IDragHandler,IEndDragHandler, IDropHandler {

	public int valor;
	public int armaID;
	public int armaType;
	Transform trans;
	Vector3 posInicial;
	private construindoNave boss;

	private dropItemShop[] dpIS;
	public void OnDrag(PointerEventData data){
		trans.position = Input.mousePosition;
		//trans.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
				if(PlayerPrefs.GetInt("money") < valor)
					break;
				
				PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money")-valor);
				boss.atualizarTextMoney();
				Debug.Log(dropped.armaID);
				invPanel.gameObject.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
				boss.colocarArma(dropped.armaID,dpIS[i].slotId,dropped.armaType);
			}
		}

	}

	public void atualizarDpIS(){
		dpIS = FindObjectsOfType<dropItemShop>();
	}
	void Start(){
		atualizarDpIS();
		trans = GetComponent<Transform>();
		posInicial = trans.position;
		boss = FindObjectOfType<construindoNave>();
	}
	// Update is called once per frame
	void Update () {
		
	}

}
