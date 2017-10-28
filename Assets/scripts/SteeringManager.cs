using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringManager : MonoBehaviour {

	public float vmax;
	public float fmax;

	// Use this for initialization
	void Start () {
		vmax = 4.0f;
		fmax = 0.75f;
	}

	// Update is called once per frame
	void Update ()
	{

	}

	public Vector2 pointToProjection_vector(Vector2 point, Vector2 lineStart, Vector2 lineEnd)
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
		Vector2 pointToProjection = projPointInLine - startToPoint;

		return pointToProjection;
	}

	public Vector2 pointToProjection_vector_advanced(Vector2 point, Vector2 lineStart, Vector2 lineEnd, float avanco)
	{
		Vector2 startToEnd = lineEnd - lineStart;
		startToEnd.Normalize();
		startToEnd = startToEnd * avanco;

		Vector2 poinToProjection = pointToProjection_vector(point, lineStart, lineEnd);

		return poinToProjection + startToEnd;
	}

	public float calcDistanceToLine(Vector2 point, Vector2 lineStart, Vector2 lineEnd)
	{
		return pointToProjection_vector(point, lineStart, lineEnd).magnitude;
	}
}
