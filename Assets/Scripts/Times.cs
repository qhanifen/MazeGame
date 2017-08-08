using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Times : MonoBehaviour {
	
	Text txt;
	public Virus times;
	public float tim;
	GameObject virus;
	
	// Use this for initialization
	void Start () {
		virus = GameObject.Find("Virus");
		times = virus.GetComponent<Virus>();
		//tim = times.timer;
		txt = gameObject.GetComponent<Text>(); 
		//txt.text="Time : " + tim;
	}
	
	// Update is called once per frame
	void Update () {
		tim = times.timer;
		txt.text="Time : " + (int)tim;  
		//tim = PlayerPrefs.GetInt("TOTALSCORE"); 
		//PlayerPrefs.SetInt("SHOWSTARTSCORE",tim); 
	}
}