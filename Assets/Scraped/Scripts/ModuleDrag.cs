using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleDrag : MonoBehaviour {

	[SerializeField] BoxCollider2D touchCollider, hitCollider;
	public Vector2 fixedPos;
	public bool isHoveringSlot = false, isAttached = false;
	public Slot attachedSlot;

	private void Awake() {
		
	}

	private void Update() {
		if(Input.GetMouseButtonDown(0))
		{
			isAttached = false;
			Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Debug.Log(MousePos);
			if(touchCollider.bounds.Contains((Vector2)MousePos))
			{
				Debug.Log("Attached.");
				this.transform.SetParent(null, true);
				InvokeRepeating("DragModule", 0, Time.deltaTime);
			}
		}
	}

	private void DragModule()
	{
		Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		this.transform.position = (Vector2)MousePos;

		if(Input.GetMouseButtonUp(0) && !isHoveringSlot || isAttached || !Input.GetMouseButton(0) && !isHoveringSlot)
		{
			this.transform.position = (Vector2)fixedPos;
			CancelInvoke();
		}

	}

}
