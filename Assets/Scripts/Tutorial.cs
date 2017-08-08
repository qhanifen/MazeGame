using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {
	public GameObject hurry;
	public GameObject how;
	public GameObject dam;
	public GameObject prompt;
	public bool hit = false;
	// Use this for initialization
	void Start () {
		hurry.SetActive (false);
		how.SetActive (false);
		dam.SetActive (false);
		prompt.SetActive (false);
		//Hurry ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space") && hit == true){
			Time.timeScale = 1F;
			prompt.SetActive (false);
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "virus"){
			Time.timeScale = 0F;
			prompt.SetActive (true);
			hit = true;
			//StartCoroutine(Prompt());
		//if (Input.GetKeyDown("space")){
			//Time.timeScale = 1F;
			//prompt.SetActive (false);
		//}
	}
	}

	IEnumerator Prompt () {
		Time.timeScale = 0F;
		prompt.SetActive (true);
		yield return new WaitForSeconds(5);
		Time.timeScale = 1F;
		prompt.SetActive (false);
	}

	public IEnumerator HowTo () {
		Time.timeScale = 0F;
		how.SetActive (true);
		yield return new WaitForSeconds(5);
		Time.timeScale = 1F;
		how.SetActive (false);
	}
	
	public IEnumerator Dam () {
		Time.timeScale = 0F;
		dam.SetActive (true);
		yield return new WaitForSeconds(5);
	}
	
	public IEnumerator Hurry () {
		Time.timeScale = 0F;
		hurry.SetActive (true);
		yield return new WaitForSeconds(5);
		hurry.SetActive (false);
		how.SetActive (true);
		yield return new WaitForSeconds(5);
		how.SetActive (false);
		Time.timeScale = 1F;
	}
}
