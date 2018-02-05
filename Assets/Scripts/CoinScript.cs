using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D colInfo)
	{
		Destroy(gameObject);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
