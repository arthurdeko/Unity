using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Aimer : MonoBehaviour {

	public float bulletSpeed = 100000;
	public int mouseButton = 0;
	public Text firedDisplay;
	public Text hitDisplay;
	public Text missDisplay;
	public Text ratioDisplay;
	
	public float scanRate = 20f;

	private float fired = 0;
	private float hitCount = 0;
	private float miss = 0;
	private float ratio = 0;

	void Start () {

		firedDisplay.text = "0";
	}

	private RaycastHit isHit() {
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		Physics.Raycast (transform.position, fwd, out hit);
		return hit;
	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit = isHit ();
		if (Input.GetMouseButtonDown(mouseButton) ) {
			fired++;
			firedDisplay.text = fired.ToString();

			//stats.updateScore();
			if ( Screen.showCursor )
			{
				Screen.showCursor = false;
			}
			if ( hit.collider.tag == "Target" ) {
				hitCount++;
				hitDisplay.text = hitCount.ToString();
				hit.collider.rigidbody.AddForceAtPosition (new Vector3(0,0,-bulletSpeed), hit.point);
			} else {
				miss++;
				missDisplay.text = miss.ToString();
			}
			ratio = (hitCount / fired) * 100;
			ratioDisplay.text = ratio + " %";

		}

		if (Input.GetMouseButtonDown (1)) {
			Screen.showCursor = true;
		}

	}

}
