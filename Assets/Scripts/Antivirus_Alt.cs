using UnityEngine;
using System.Collections;

public class Antivirus_Alt : MonoBehaviour {
	public GameObject node1;
	public GameObject node2;
	public GameObject target;
	public Transform antivirus;
	public Transform virus;
	public bool NodeSet1 = true;
	public bool NodeSet2 = false;
	public float knockSpeed = -1f;
	
	// Use this for initialization
	void Start () {
		node1.SetActive(true);
		node2.SetActive(false);
	}

	void Update () {
		//virus.position = Vector3.MoveTowards(virus.position, transform.position, knockSpeed);
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "target" && NodeSet1 == true){
			Debug.Log ("Fail");
			node2.SetActive(true);
			target.transform.parent = node2.transform;
			target.transform.localPosition = Vector3.zero;
			target.transform.parent = null;
			Node1();
		}
		else if (other.tag == "target" && NodeSet2 == true){
			node1.SetActive(true);
			target.transform.parent = node1.transform;
			target.transform.localPosition = Vector3.zero;
			target.transform.parent = null;
			Node2();
		}
		if (other.tag == "virus"){
			Knock();
		}
	}

	void Node1 () {
		Debug.Log ("Node1 Off");
		NodeSet1 = false;
		node1.SetActive(false);
		NodeSet2 = true;
	}
	
	void Node2 () {
		Debug.Log ("Node2 Off");
		NodeSet2 = false;
		node2.SetActive(false);
		NodeSet1 = true;
	}	

	void Knock() {
		virus.position = Vector3.MoveTowards(virus.position, transform.position, knockSpeed);
	}
}
