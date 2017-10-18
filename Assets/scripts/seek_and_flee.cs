using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seek_and_flee : MonoBehaviour {

	public float max_vel = 5.0f;
	public int state = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
		//transform.position = new Vector2(mouseWorld.x, mouseWorld.y);

		//	aponta do agente para o mouse
		Vector2 direcaoDesejada = mouseWorld - (Vector2)transform.position;
		//direcaoDesejada *= -1.0f;

		//	passando para modulo (tamanho) 1
		Vector2 direcao_norm = direcaoDesejada.normalized;

		float distancia = direcaoDesejada.magnitude;

		if(distancia > GetComponent<Arrive>().distancia_arrive)
		{
			//	multiplicando pelo tamanho desejado
			Vector2 v_desejada = max_vel * direcao_norm;

			//	STEER = V_DESEJADA - V_ATUAL
			Vector2 steer = v_desejada - GetComponent<Rigidbody2D>().velocity; 

			GetComponent<Rigidbody2D>().AddForce( steer );
		}*/
	}
}
