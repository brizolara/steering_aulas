using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : MonoBehaviour {

	public float distancia_arrive = 3.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(GetComponent<seek_and_flee>().);
		Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
		//transform.position = new Vector2(mouseWorld.x, mouseWorld.y);

		//	aponta do agente para o mouse
		Vector2 direcaoDesejada = mouseWorld - (Vector2)transform.position;
		//direcaoDesejada *= -1.0f;

		//	passando para modulo (tamanho) 1
		Vector2 direcao_norm = direcaoDesejada.normalized;

		float distancia = direcaoDesejada.magnitude;

		if(distancia < distancia_arrive)
		{
			Vector2 v_desejada = direcao_norm * distancia * GetComponent<SteeringManager>().vmax / distancia_arrive;

			Debug.Log(v_desejada);

			//	STEER = V_DESEJADA - V_ATUAL
			Vector2 steer = v_desejada - GetComponent<Rigidbody2D>().velocity;

			//	nao deixamos a forca passar de fmax
			steer = Vector2.ClampMagnitude(steer, GetComponent<SteeringManager>().fmax);

			GetComponent<Rigidbody2D>().AddForce( steer );
		}
		else
		{
			Vector2 v_desejada = direcao_norm * GetComponent<SteeringManager>().vmax;

			Debug.Log(v_desejada);

			//	STEER = V_DESEJADA - V_ATUAL
			Vector2 steer = v_desejada - GetComponent<Rigidbody2D>().velocity;

			//	nao deixamos a forca passar de fmax
			steer = Vector2.ClampMagnitude(steer, GetComponent<SteeringManager>().fmax);

			GetComponent<Rigidbody2D>().AddForce( steer );
		}
	}
		
}
