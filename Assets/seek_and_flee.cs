using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seek_and_flee : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
		//transform.position = new Vector2(mouseWorld.x, mouseWorld.y);

		Vector2 direcaoDesejada = mouseWorld - (Vector2)transform.position;

		GetComponent<Rigidbody2D>().AddForce( direcaoDesejada );
	}
}
