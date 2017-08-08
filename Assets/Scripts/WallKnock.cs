using UnityEngine;
using System.Collections;

public class WallKnock : MonoBehaviour {
	//public Transform wall;
	public Transform virus;
	public float knockSpeed = -1f;
	// Use this for initialization
	void Start () {
		//wall
	}
	void OnTriggerEnter (Collider other) {
		if (other.tag == "wall"){
			Knock(other.transform);
	}
	}
	void Knock(Transform wall) {
		virus.position = Vector3.MoveTowards(virus.position, wall.position, knockSpeed);
}
}