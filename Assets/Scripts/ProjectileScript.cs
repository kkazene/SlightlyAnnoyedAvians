using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

	public float maxDist = 3.0f;
	public LineRenderer frontLine;
	public LineRenderer backLine;
	public Rigidbody2D ball;

	private SpringJoint2D spring;
	private CircleCollider2D circle;
	private Ray mouseRay;
	private Ray leftCatapultRay;
	private float maxDistSqr;
	private float circleRadius;
	private Transform catapult;
	private bool clickedOn;
	private Vector2 prevVelocity;


	void Awake () {
		spring = GetComponent<SpringJoint2D>();
		circle = GetComponent<CircleCollider2D>();
		ball = GetComponent<Rigidbody2D>();
		catapult = spring.connectedBody.transform;
	}
	// Use this for initialization
	void Start () {
		/*LineRendererSetup();
		mouseRay = new Ray(catapult.position, Vector3.zero);
		leftCatapultRay = new Ray(frontLine.transform.position, Vector3.zero);
		maxDistSqr = maxDist * maxDist;
		circleRadius = circle.radius;*/
	}
	
	// Update is called once per frame
	void Update () {
		/*if (clickedOn)
			Drag();
		if (spring != null) {
			if (!ball.isKinematic && prevVelocity.sqrMagnitude > ball.velocity.sqrMagnitude) {
				Destroy (spring);
				ball.velocity = prevVelocity;
			}
			if (!clickedOn)
				prevVelocity = ball.velocity;

			LineRendererUpdate();

		} else {
			frontLine.enabled = false;
			backLine.enabled = false;
		}
		*/
	}

	void LineRendererSetup () {
		/*frontLine.SetPosition(0, frontLine.transform.position);
		backLine.SetPosition(0, backLine.transform.position);

		frontLine.sortingLayerName = "Foreground";
		backLine.sortingLayerName = "Foreground";

		frontLine.sortingOrder = 3;
		backLine.sortingOrder = 1; */
	}

	void LineRendererUpdate () {
		/*Vector2 catapultToProjectile = transform.position - frontLine.transform.position;
		leftCatapultRay.direction = catapultToProjectile;
		Vector3 holdPoint = leftCatapultRay.GetPoint(catapultToProjectile.magnitude + circleRadius);
		frontLine.SetPosition(1, holdPoint);
		backLine.SetPosition(1, holdPoint); */
	}

	void onMouseDown () {
		Debug.Log("mouse down");
		spring.enabled = false;
		ball.isKinematic = false;
		clickedOn = true;		
	}

	void onMouseUp () {
		Debug.Log("mouse up");
		spring.enabled = true;
		ball.isKinematic = false;
		clickedOn = false;	
	}

	void Drag () {
		Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 catapultPoint = mousePoint - catapult.position;

		if (mousePoint.sqrMagnitude > maxDistSqr) {
			mouseRay.direction = catapultPoint;
			mousePoint = mouseRay.GetPoint(maxDist);
		}
		mousePoint.z = 0f;
		transform.position = mousePoint;
	}
}
