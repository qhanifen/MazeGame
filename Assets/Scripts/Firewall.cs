using UnityEngine;
using System.Collections;

public class Firewall : MonoBehaviour {
	public Transform firewall;
	public Transform virus;
	public float knockSpeed = -2f;
	// Use this for initialization

	void OnTriggerEnter(Collider other){
	if (other.tag == "virus"){
		Knock();
	}
	}

	void Knock() {
		virus.position = Vector3.MoveTowards(virus.position, transform.position, knockSpeed);
	}

}
