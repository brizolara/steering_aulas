using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringManager : MonoBehaviour {

	public float vmax = 5.0f;
	public Vector2 lineStart = new Vector2(-0.0681f, 0.002f);
	public Vector2 lineEnd = new Vector2(0.065f, -0.005f);

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update ()
	{
		float d = calcDistanceToLine(
			new Vector2(transform.position.x, transform.position.y), 
			lineStart, 
			lineEnd);

		Debug.Log(lineStart.y + " " + transform.position.y + " " + lineEnd.y);
		Debug.Log("Distance = " + d);
	}

	float calcDistanceToLine(Vector2 point, Vector2 lineStart, Vector2 lineEnd)
	{
		//	Vetor que vai de start a point
		Vector2 startToPoint = point - lineStart;

		//	Vetor que vai de start a end
		Vector2 startToEnd = lineEnd - lineStart;

		//	Calculando a projecao de point na linha
		Vector3 aux_startToPoint = new Vector3(startToPoint.x, startToPoint.y);
		Vector3 aux_startToEnd = new Vector3(startToEnd.x, startToEnd.y);
		aux_startToEnd.Normalize();
		Vector3 aux_projPointInLine = Vector3.Project(aux_startToPoint, aux_startToEnd);
		Vector2 projPointInLine = new Vector2(aux_projPointInLine.x, aux_projPointInLine.y);

		//	Calculamos atraves do triangulo formado pelos 3 vetores
		Vector2 pointToProjection = startToPoint - projPointInLine;

		return pointToProjection.magnitude;
	}
}
