using UnityEngine;
using System.Collections;

public class Ball : Thing, IDestructable {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Create () {
		Debug.Log("Ball Created");
	}

	public void Remove () {
        Debug.Log("Ball Removed");
	}
}
