using System;
using UnityEngine;

public class navinhaEntrando : MonoBehaviour
{

    private Rigidbody2D myRigidbody2D;

    private void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
		myRigidbody2D.velocity = new Vector2(0,1f);

    }

}