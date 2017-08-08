using UnityEngine;
using System.Collections;

public class Antivirus : MonoBehaviour {
	public GameObject node1;
	public GameObject node2;
	public GameObject node3;
	public GameObject node4;
	public GameObject target;
	public Transform antivirus;
	public Transform virus;
	public bool NodeSet1 = true;
	public bool NodeSet2 = false;
	public bool NodeSet3 = false;
	public bool NodeSet4 = false;
	public float knockSpeed = -2f;

	// Use this for initialization
	void Start () {
		node1.SetActive(true);
		node2.SetActive(false);
		node3.SetActive(false);
		node4.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		//target.transform.parent = node1.transform;
		//target.transform.localPosition = Vector3.zero;
		//target.transform.parent = null;
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "target" && NodeSet1 == true){
			node2.SetActive(true);
			target.transform.parent = node2.transform;
			target.transform.localPosition = Vector3.zero;
			target.transform.parent = null;
			Node1();
		}
		else if (other.tag == "target" && NodeSet2 == true){
			node3.SetActive(true);
			target.transform.parent = node3.transform;
			target.transform.localPosition = Vector3.zero;
			target.transform.parent = null;
			Node2();
		}
		else if (other.tag == "target" && NodeSet3 == true){
			node4.SetActive(true);
			target.transform.parent = node4.transform;
			target.transform.localPosition = Vector3.zero;
			target.transform.parent = null;
			Node3();
		}
		else if (other.tag == "target" && NodeSet4 == true){
			node1.SetActive(true);
			target.transform.parent = node1.transform;
			target.transform.localPosition = Vector3.zero;
			target.transform.parent = null;
			Node4();
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
		NodeSet3 = true;
	}

	void Node3 () {
		Debug.Log ("Node3 Off");
		NodeSet3 = false;
		node3.SetActive(false);
		NodeSet4 = true;
	}

	void Node4 () {
		Debug.Log ("Node4 Off");
		NodeSet4 = false;
		node4.SetActive(false);
		NodeSet1 = true;
	}

	void Knock(){
		virus.position = Vector3.MoveTowards(virus.position, transform.position, knockSpeed);
	}
}
