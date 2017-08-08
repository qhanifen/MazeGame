using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	public float moveSpeed = 1f;
	public AudioClip [] boops;
	AudioSource audio;
	public bool step = true;
	public GameObject Virus;
	public float smooth = 2.0F;
	public float tiltAngle = 30.0F;
	Animator anim;
	int moving = Animator.StringToHash("Walking");
	int sit = Animator.StringToHash("Idle");
	
	// Use this for initialization
	void Start () {

		audio = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();;
	}

	void Update () {
		float tiltY = Input.GetAxis("Mouse X") * -tiltAngle;
		float tiltX = Input.GetAxis("Mouse Y") * tiltAngle;
		Quaternion target = Quaternion.Euler(tiltX, 0, tiltY);
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
		if (Input.GetAxisRaw("Mouse X") !=0){
			transform.position += new Vector3(Input.GetAxisRaw("Mouse X"), 0, 0) * moveSpeed * Time.deltaTime;
			anim.ResetTrigger (sit);
			anim.SetTrigger (moving);
		}
		if (Input.GetAxisRaw("Mouse Y") !=0){
			transform.position += new Vector3(0 ,0 ,Input.GetAxisRaw("Mouse Y")) * moveSpeed * Time.deltaTime;
			anim.ResetTrigger (sit);
			anim.SetTrigger (moving);

		}
		if (Input.GetAxisRaw("Mouse X")==0){
			anim.ResetTrigger (moving);
			anim.SetTrigger (sit);
		}
		if (Input.GetAxisRaw("Mouse X")==0){
			anim.ResetTrigger (moving);
			anim.SetTrigger (sit);
		}
		if (Input.GetAxisRaw("Mouse Y") !=0 && step == true){
			Step ();
			StartCoroutine(Sound());
		}
}
	void Step () {
		audio.clip = boops[Random.Range(0,boops.Length)];
		audio.Play();
	}
	IEnumerator Sound () {
		step = false;
		yield return new WaitForSeconds(1);
		step = true;
	}
}