using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowPop : MonoBehaviour {

	[SerializeField] float popUpSpeed, hidingSpeed;
	[SerializeField] Transform hidingSpot, popUpSpot;
	bool isHidden = true;

	public void Swap()
	{
		if(isHidden)
			PopUp();
		else
			Hide();
	}

	private void PopUp()
	{
		InvokeRepeating("PopUpTransition", 0, Time.deltaTime);
	}

	private void Hide()
	{
		InvokeRepeating("HideTransition", 0, Time.deltaTime);
	}

	private void PopUpTransition()
	{
		this.transform.position = Vector2.MoveTowards(this.transform.position, popUpSpot.position, popUpSpeed);
		if(((Vector2)this.transform.position - (Vector2)popUpSpot.position).magnitude < 0f)
		{
			isHidden = false;
			CancelInvoke();
		}
	}

	private void HideTransition()
	{
		this.transform.position = Vector2.MoveTowards(this.transform.position, hidingSpot.position, hidingSpeed);
		if(((Vector2)this.transform.position - (Vector2)hidingSpot.position).magnitude > 0f)
		{
			isHidden = true;
			CancelInvoke();
		}
	}
}
