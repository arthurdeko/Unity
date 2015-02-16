using UnityEngine;
using System.Collections;

public class ProjectileBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter ( Collision other ) {
		if (other.collider.name == "target") {
						Destroy (gameObject);
			Destroy (other.gameObject);
				}
	}


}
