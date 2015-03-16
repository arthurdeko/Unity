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
	public Transform bulletMark;
	public float maxShots = 100;

	private float fired = 0;
	private float hitCount = 0;
	private float miss = 0;
	private float ratio = 0;

	void Start () {
		firedDisplay.text = "0";
		StartCoroutine ("Gun");
	}

	void FireGun() {
        if ( fired > maxShots ) {
			Application.LoadLevel("g");
		}
		GetComponent<AudioSource>().Play ();
		Core.HideCursor ();		
		fired++;
		firedDisplay.text = fired.ToString ();

		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		if ( Physics.Raycast (transform.position, fwd, out hit) ) {
			if (hit.collider.tag == "Target") {
				hitCount++;
				hitDisplay.text = hitCount.ToString ();
				hit.collider.GetComponent<Rigidbody>().AddForceAtPosition (-hit.collider.transform.forward * bulletSpeed, hit.point);
				
			}
		} else {
			miss++;
			missDisplay.text = miss.ToString ();
		}
		
		ratio = (hitCount / fired) * 100;
		ratioDisplay.text = ratio + " %";
		
		
	}
	
	IEnumerator Gun() {
		while (transform.position.y < 100000) {

			if (Input.GetMouseButtonDown (mouseButton)) {
				FireGun();
			}

			if (Input.GetMouseButtonDown (1)) {
					Core.UnhideCursor ();
			}

			yield return null;
		}
		yield return null;

	}

}
