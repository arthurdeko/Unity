using UnityEngine;
using System.Collections;

public class basicAI : MonoBehaviour {

	public float speed = 1000f;
	public Rigidbody bullet;
	public float bulletSpeed;
	private Vector3 targetPosition;
	private Vector3 aimedPoint;
	
	public float scanRate = 20f;

	// Use this for initialization
	void Start () {
	}

	Rigidbody Fire (Vector3 point) {
		Rigidbody bulletInstance = Instantiate( bullet, GetComponent<Rigidbody>().transform.position, GetComponent<Rigidbody>().transform.rotation) as Rigidbody;
		bulletInstance.AddForce (point * bulletSpeed);
		return bulletInstance;
	}

	void Aim (Rigidbody target) {
		Vector3 currentPosition = GetComponent<Rigidbody>().transform.position;
		Vector3 targetVelocity = target.GetRelativePointVelocity (currentPosition);
		aimedPoint = (target.position + targetVelocity) * bulletSpeed;

	}


	// Update is called once per frame
	void Update () {

		//Scan ();
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		if (Physics.Raycast (transform.position, fwd, out hit)) {
			if (hit.collider.name == "target") {
				Aim (hit.rigidbody);
				Fire (aimedPoint);

			}
		}
	}



}
