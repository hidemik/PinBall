using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private int totalscore = 0;
	private GameObject scoreText;

	// Use this for initialization
	void Start () {
		this.scoreText = GameObject.Find ("ScoreText");
	}
	
	// Update is called once per frame
	void Update () {
		this.scoreText.GetComponent<Text> ().text = "Score: " + this.totalscore;
	}

	void OnCollisionEnter (Collision other){
		if (other.gameObject.tag == "SmallStarTag") {
			this.totalscore += 10;
		} else if (other.gameObject.tag == "LargeStarTag") {
			this.totalscore += 20;
		} else if (other.gameObject.tag == "SmallCloudTag") {
			this.totalscore += 50;
		} else if (other.gameObject.tag == "LargeCloudTag") {
			this.totalscore += 100;
		}
	}
	}
