using UnityEngine;
using System.Collections;

public class Throw : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    GetComponent<Rigidbody>().AddForce(new Vector3(0,1000,-5000));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
