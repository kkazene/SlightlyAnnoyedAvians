using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

	public Rigidbody2D ball;
	public float releaseTime = 0.15f;
	private bool clickedOn = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (clickedOn) {
			ball.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
	}

	void OnMouseDown () {
		//spring.enabled = false;
		ball.isKinematic = true;
		clickedOn = true;		
	}

	void OnMouseUp () {
		//spring.enabled = true;
		ball.isKinematic = false;
		clickedOn = false;
		StartCoroutine(Release());
	}

	IEnumerator Release () {
		yield return new WaitForSeconds(releaseTime);

		GetComponent<SpringJoint2D>().enabled = false;
		this.enabled = false;
	}
}
