using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour {

	public float larguraPista;
	public float avanco;
	public Vector2 lineStart;
	public Vector2 lineEnd;

	public List<Vector2> waypoints;
	protected int startIndex;

	public float waypointArrivalDistance;

	// Use this for initialization
	void Start () {
		larguraPista = 0.1f;
		avanco = 0.3f;
		waypointArrivalDistance = 2.5f;
		startIndex = 0;

		//	Pegando a lista de waypoints da cena
		List<GameObject> scene_waypoints = GameObject.Find("Path").GetComponent<Path>().wayPoints;
		for(int i=0; i<scene_waypoints.Count; i++) {
			waypoints.Add(new Vector2(scene_waypoints[i].transform.position.x, scene_waypoints[i].transform.position.y));
		}

		lineStart = waypoints[0];
		lineEnd = waypoints[1];
	}

	// Update is called once per frame
	void Update ()
	{
		Vector2 position2d = new Vector2(transform.position.x, transform.position.y);
		float d = GetComponent<SteeringManager>().calcDistanceToLine(
			position2d, 
			lineStart, 
			lineEnd);

		if(d > larguraPista)
		{
			Vector2 v_desejada = GetComponent<SteeringManager>().pointToProjection_vector_advanced(
				position2d, 
				lineStart, 
				lineEnd,
				avanco);

			v_desejada.Normalize();

			v_desejada = v_desejada * GetComponent<SteeringManager>().vmax;

			//	STEER = V_DESEJADA - V_ATUAL
			Vector2 steer = v_desejada - GetComponent<Rigidbody2D>().velocity; 

			//	nao deixamos a forca passar de fmax
			steer = Vector2.ClampMagnitude(steer, GetComponent<SteeringManager>().fmax);

			GetComponent<Rigidbody2D>().AddForce( steer );
		}

		if( Vector2.Distance(position2d, lineEnd) < waypointArrivalDistance)
		{
			startIndex++;
			if(startIndex == waypoints.Count)
			{
				startIndex = 0;
			}
			lineStart = waypoints[startIndex];
			if(startIndex == waypoints.Count - 1) {
				lineEnd = waypoints[0];
			}
			else {
				lineEnd = waypoints[startIndex + 1];
			}

		}

		//Debug.Log("Distance = " + d);
	}
		
}
