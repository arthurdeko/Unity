using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private Ball firstBall; 

	// Use this for initialization
	void Start () {

         Debug.Log("Game Started");

         firstBall=new Ball();
         firstBall.Create();
	}
	
	// Update is called once per frame
	void Update () {
			float h = Input.GetAxis("Horizontal");
			if ( h > 0 ) {
				firstBall.Remove();
			}
	}
}
