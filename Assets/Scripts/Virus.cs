using UnityEngine;
using System.Collections;

public class Virus : MonoBehaviour {

	public float timer = 300;
	public float knockSpeed = -1f;
	public GameObject virus;
	public bool invulnerable = false;
	public bool move = true;
	public Rigidbody grav;
	public AudioClip hurt;
	AudioSource audio;
	public float hp = 3;
	public GameObject Hp1;
	public GameObject Hp2;
	public GameObject Hp3;
	public GameObject hud;
	public PlayerMove stun;
	public float height = .75f;
	public GameObject gameover;
	Animator anim;
	int damHash = Animator.StringToHash("Dead");
	int moving = Animator.StringToHash("Walking");
	int sit = Animator.StringToHash("Idle");

	void Awake () {
		stun = GetComponent<PlayerMove>();
		grav = GetComponent<Rigidbody>();
	}

	void Start () {
		stun.enabled = false;
		virus = GameObject.Find("Virus");
		audio = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();
		gameover.SetActive (false);
		StartCoroutine(waitToStart());
	}
	

	void OnTriggerEnter(Collider other) {
		if (other.tag == "antivirus" && invulnerable == false){
			if (timer <= 0){
				Debug.Log ("Fail");
			}
			else {
				timer -= 100;
				move = false;
				invulnerable = true;
				Damage ();
				audio.clip = hurt;
				audio.Play();
			}
		}
		else {
			Debug.Log ("No Hit");
		}
		if (other.tag == "firewall" && invulnerable == false){
			if (timer <= 0){
				Debug.Log ("Fail");
			}
			else {
				timer -= 50;
				move = false;
				invulnerable = true;
				Damage ();
				audio.clip = hurt;
				audio.Play();
			}
		}
		if (other.tag == "wall" && invulnerable == false){
			timer -= 50;
			move = false;
			invulnerable = true;
			StartCoroutine(Wall());
		}

		else {
			Debug.Log ("No Hit");
	}
		if (other.tag == "ende"){
			Application.LoadLevel ("Medium");
			hud.SetActive (false);
		}
		if (other.tag == "endt"){
			Application.LoadLevel ("Easy");
			hud.SetActive (false);
		}
		if (other.tag == "endm"){
			Application.LoadLevel ("Hard");
			hud.SetActive (false);
		}
		if (other.tag == "endh"){
			Application.LoadLevel ("Title");
			hud.SetActive (false);
		}
	}


	void Update () {
		timer -= Time.deltaTime;
		Debug.Log((int)timer);
		if (move = false){
			stun.enabled = false;
		}
		if (timer <= 0){
			StartCoroutine(Dead());
	}
	}

	IEnumerator Invulnerability () {
		Debug.Log ("Invulnerable");
		stun.enabled = false;
		yield return new WaitForSeconds(2);
		invulnerable = false;
		move = true;
		stun.enabled = true;
		transform.position = new Vector3(transform.position.x, height, transform.position.z);
		Debug.Log ("Vulnerable");
	}

	IEnumerator Wall () {
		stun.enabled = false;
		yield return new WaitForSeconds(1);
		invulnerable = false;
		move = true;
		stun.enabled = true;
		transform.position = new Vector3(transform.position.x, height, transform.position.z);
	}

	public void Damage () {
		hp -= 1;
		if (hp == 2){
			Hp1.SetActive(false);
			StartCoroutine(Invulnerability());
		}
		else if (hp == 1){
			Hp2.SetActive(false);
			StartCoroutine(Invulnerability());
		}
		else if (hp == 0){
			Hp3.SetActive(false);
			StartCoroutine(Dead());
		}
	}
	IEnumerator Dead () {
		transform.position = new Vector3(transform.position.x, height, transform.position.z);
		anim.ResetTrigger (sit);
		anim.ResetTrigger (moving);
		move = false;
		stun.enabled = false;
		virus.GetComponent<Collider>().enabled = false;
		anim.SetTrigger (damHash);
		yield return new WaitForSeconds(10);
		gameover.SetActive (true);
		yield return new WaitForSeconds(5);
		Application.LoadLevel ("Title");
	}

	IEnumerator waitToStart () {
		yield return new WaitForSeconds(2);
		stun.enabled = true;
}
}




	