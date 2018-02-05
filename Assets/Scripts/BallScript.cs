using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour {

	public Rigidbody2D ball;
	public Rigidbody2D hook;
	public float releaseTime = 0.15f;
	public float maxDist = 3f;
	public static int GamePoints = 0;
	private bool clickedOn = false;

	public GameObject nextBall;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (clickedOn) {
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (Vector3.Distance(mousePos, hook.position) > maxDist)
				ball.position = hook.position + (mousePos - hook.position).normalized * maxDist;
			else
				ball.position = mousePos;
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

	void OnTriggerEnter2D (Collider2D other ) {
		if (other.gameObject.CompareTag("Collectible")) {
			Destroy(other.gameObject);
			GamePoints++;
			Debug.Log("Total points: ");
			Debug.Log(GamePoints);
		}
	}

	IEnumerator Release () {
		yield return new WaitForSeconds(releaseTime);

		GetComponent<SpringJoint2D>().enabled = false;
		this.enabled = false;

		yield return new WaitForSeconds(2f);
		if (nextBall != null) {
			nextBall.SetActive(true);
		} else {
			Debug.Log("Game over");
			Debug.Log("Total points: ");
			Debug.Log(GamePoints);
			EnemyScript.EnemiesAlive = 0;
			GamePoints = 0;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
